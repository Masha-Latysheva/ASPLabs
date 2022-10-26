using System.Linq;
using Lab3_.Data;
using Lab3_.Infrastructure.Filters;
using Lab3_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_.Controllers
{
    [ExceptionFilter]
    [TypeFilter(typeof(TimingLogAttribute))]
    public class HomeController : Controller
    {
        private readonly LogisticContext _db;

        public HomeController(LogisticContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            const int numberRows = 10;
            var organizations = _db.Organizations.AsNoTracking().Take(numberRows).ToList();
            var drivers = _db.Drivers.AsNoTracking().Take(numberRows).ToList();
            var cars = _db.Cars
                .Include(t => t.Organization)
                .Select(t => new CarViewModel
                {
                    Id = t.Id,
                    CarryingVolume = t.CarryingVolume,
                    CarryingWeight = t.CarryingWeight,
                    Mark = t.Mark,
                    Organization = t.Organization.Name
                })
                .Take(numberRows)
                .ToList();

            var homeViewModel = new HomeViewModel
            {
                Drivers = drivers,
                Organizations = organizations,
                Cars = cars
            };

            return View(homeViewModel);
        }
    }
}