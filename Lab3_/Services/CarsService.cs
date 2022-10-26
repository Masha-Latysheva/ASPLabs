using System.Linq;
using Lab3_.Data;
using Lab3_.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Lab3_.Services
{
    // Класс выборки 10 записей из таблиц 
    public class CarsService : ICarsService
    {
        private readonly LogisticContext _context;

        public CarsService(LogisticContext context)
        {
            _context = context;
        }

        public HomeViewModel GetHomeViewModel(int numberRows = 10)
        {
            var organizations = _context.Organizations.Take(numberRows).ToList();
            var drivers = _context.Drivers.Take(numberRows).ToList();

            var operations = _context.Cars
                .Include(t => t.Organization)
                .Select(t => new CarViewModel
                {
                    CarryingVolume = t.CarryingVolume,
                    CarryingWeight = t.CarryingWeight,
                    Id = t.Id,
                    Mark = t.Mark,
                    Organization = t.Organization.Name
                })
                .Take(numberRows)
                .ToList();

            var homeViewModel = new HomeViewModel
            {
                Drivers = drivers,
                Organizations = organizations,
                Cars = operations
            };
            return homeViewModel;
        }
    }
}