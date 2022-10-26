using System.Linq;
using Lab3_.Data;
using Lab3_.Infrastructure.Filters;
using Lab3_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_.Controllers
{
    public class CachedController : Controller
    {
        private readonly LogisticContext _context;

        public CachedController(LogisticContext context)
        {
            _context = context;
        }

        [TypeFilter(typeof(CacheResourceFilterAttribute))]
        public IActionResult Index()
        {
            const int numberRows = 10;
            var organizations = _context.Organizations.AsNoTracking().Take(numberRows).ToList();
            var drivers = _context.Drivers.AsNoTracking().Take(numberRows).ToList();
            var cars = _context.Cars
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
            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }
    }
}