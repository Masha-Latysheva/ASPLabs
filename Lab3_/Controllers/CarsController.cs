using System;
using System.Linq;
using Lab3_.Data;
using Lab3_.Infrastructure;
using Lab3_.Infrastructure.Filters;
using Lab3_.Models;
using Lab3_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))] // Фильтр ресурсов
    [ExceptionFilter] // Фильтр исключений
    public class CarsController : Controller
    {
        private readonly LogisticContext _context;
        private readonly int pageSize = 10; // количество элементов на странице
        private CarViewModel _operation = new() { Mark = "" };

        public CarsController(LogisticContext context)
        {
            _context = context;
        }

        // GET: Operations
        [SetToSession("SortState")] //Фильтр действий для сохранение в сессию состояния сортировки
        public IActionResult Index(SortState sortOrder, int page = 1)
        {
            // Считывание данных из сессии
            var sessionOperation = HttpContext.Session.Get("Car");
            var sessionSortState = HttpContext.Session.Get("SortState");
            if (sessionOperation != null)
                _operation = Transformations.DictionaryToObject<CarViewModel>(sessionOperation);
            if (sessionSortState != null)
                if ((sessionSortState.Count > 0) & (sortOrder == SortState.No))
                    sortOrder = (SortState)Enum.Parse(typeof(SortState), sessionSortState["sortOrder"]);

            // Сортировка и фильтрация данных
            IQueryable<Car> fuelsContext = _context.Cars;
            fuelsContext = Sort_Search(fuelsContext, sortOrder, _operation.Mark ?? "");

            // Разбиение на страницы
            var count = fuelsContext.Count();
            fuelsContext = fuelsContext.Skip((page - 1) * pageSize).Take(pageSize);

            // Формирование модели для передачи представлению
            _operation.SortViewModel = new SortViewModel(sortOrder);
            var cars = new CarsViewModel
            {
                Cars = fuelsContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
                CarViewModel = _operation
            };
            return View(cars);
        }

        // Post: Operations
        [HttpPost]
        [SetToSession("Car")] //Фильтр действий для сохранение в сессию параметров отбора
        public IActionResult Index(CarViewModel operation, int page = 1)
        {
            // Считывание данных из сессии
            var sessionSortState = HttpContext.Session.Get("SortState");
            var sortOrder = new SortState();
            if (sessionSortState.Count > 0)
                sortOrder = (SortState)Enum.Parse(typeof(SortState), sessionSortState["sortOrder"]);

            // Сортировка и фильтрация данных
            IQueryable<Car> fuelsContext = _context.Cars;
            fuelsContext = Sort_Search(fuelsContext, sortOrder, operation.Mark ?? "");
            // Разбиение на страницы
            var count = fuelsContext.Count();
            fuelsContext = fuelsContext.Skip((page - 1) * pageSize).Take(pageSize);
            // Формирование модели для передачи представлению
            operation.SortViewModel = new SortViewModel(sortOrder);
            var cars = new CarsViewModel
            {
                Cars = fuelsContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
                CarViewModel = operation
            };

            return View(cars);
        }

        // Сортировка и фильтрация данных
        private IQueryable<Car> Sort_Search(IQueryable<Car> operations, SortState sortOrder, string markSearchTankType)
        {
            switch (sortOrder)
            {
                case SortState.WeightAsc:
                    operations = operations.OrderBy(s => s.CarryingWeight);
                    break;
                case SortState.WeightDesc:
                    operations = operations.OrderByDescending(s => s.CarryingWeight);
                    break;
                case SortState.VolumeAsc:
                    operations = operations.OrderBy(s => s.CarryingVolume);
                    break;
                case SortState.VolumeDesc:
                    operations = operations.OrderByDescending(s => s.CarryingVolume);
                    break;
            }

            operations = operations
                .Include(t => t.Organization)
                .Where(t => t.Mark.ToLower().Contains(markSearchTankType.ToLower()))
                .AsNoTracking();

            return operations;
        }
    }
}