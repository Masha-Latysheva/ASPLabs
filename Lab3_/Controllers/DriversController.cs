using System.Threading.Tasks;
using Lab3_.Data;
using Lab3_.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))]
    public class DriversController : Controller
    {
        private readonly LogisticContext _context;

        public DriversController(LogisticContext context)
        {
            _context = context;
        }

        // GET: Fuels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drivers.AsNoTracking().ToListAsync());
        }
    }
}