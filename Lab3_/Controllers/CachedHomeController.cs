using Lab3_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Lab3_.Controllers
{
    // Выборка кэшированых данных из IMemoryCache
    public class CachedHomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public CachedHomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            //считывание данных из кэша
            var homeViewModel = _memoryCache.Get<HomeViewModel>("Cars 10");
            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }
    }
}