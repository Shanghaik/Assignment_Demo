using Data.ModelsClass;
using DependencyInjectionDemo.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text;
using Newtonsoft.Json;

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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _sanphamsService.GetSanPhamById(id));
        }

        public async Task<IActionResult> Details()
        {
            return View("VC");
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Sanpham sp)
        {
            return View(await _sanphamsService.AddNewSanpham(sp));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(string id)
        {
            Sanpham sp = new Sanpham();
            sp.Id = Guid.Parse(id);
            return View(sp);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] Sanpham sp)
        {
            //HttpClient client = new HttpClient();
            //var content = new StringContent(JsonConvert.SerializeObject(sp), Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("https://localhost:7262/api/Sanphams/update/" + sp.Id.ToString(), content);
            //string result = await response.Content.ReadAsStringAsync();
            await _sanphamsService.UpdateSanpham(sp);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Sanpham sp)
        {
            await _sanphamsService.RemoveSanPham(sp);
            return RedirectToAction("Index");
            //HttpClient client = new HttpClient();
            //var content = new StringContent(JsonConvert.SerializeObject(sp), Encoding.UTF8, "application/json");
            //var response = await client.GetAsync("https://localhost:7262/api/Sanphams/delete/" + sp.Id.ToString());
            //string result = await response.Content.ReadAsStringAsync();
            //return RedirectToAction("Index");
        }

    }
}