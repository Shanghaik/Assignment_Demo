using Data.ModelsClass;
using DependencyInjectionDemo.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanphamsService _sanphamsService;
        public HomeController(ILogger<HomeController> logger, ISanphamsService sanphamsService)
        {
            _logger = logger;
            _sanphamsService = sanphamsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _sanphamsService.GetAllSanPham());
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}