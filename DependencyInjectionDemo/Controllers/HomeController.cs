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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _sanphamsService.GetAllSanPham());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Sanpham sp)
        {
            return View(await _sanphamsService.AddNewSanpham(sp));
        }

    }
}