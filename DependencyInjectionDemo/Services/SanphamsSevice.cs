using Data.ModelsClass;
using DependencyInjectionDemo.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DependencyInjectionDemo.Services
{
    public class SanphamsSevice : ISanphamsService
    {

        public async Task<IEnumerable<Sanpham>> GetAllSanPham()
        {
            List<Sanpham> sanphams = new List<Sanpham>();
            var httpClient = new HttpClient(); //tạo 1 http Client để call API
            var response = await httpClient.GetAsync("https://localhost:7262/api/Sanphams/get-all-sanpham");
            //Lấy dữ liệu từ file Json -Cài nuget Newtonsoft.json
            //Đọc ra 1 file Json
            string sanphamResponse = await response.Content.ReadAsStringAsync();
            //Lấy ra list object từ string json
            sanphams = JsonConvert.DeserializeObject<List<Sanpham>>(sanphamResponse);
            return sanphams.ToList();
        }

        public Task<IActionResult> RemoveSanPham(Guid id)
        {
            var httpClient = new HttpClient(); //tạo 1 http Client để call API
            //var response = await httpClient.DeleteAsync("https://localhost:7262/api/Sanphams/delete-sanpham-{id}");
            httpClient.BaseAddress = new Uri("http://localhost:7262/api/");
            var deleteTask = httpClient.DeleteAsync("Sanphams/delete-" + id.ToString());
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return null;
            }
            return null;
        }

        public IActionResult UpdateSanpham(Sanpham sp)
        {
            throw new NotImplementedException();
        }

        public Task<Sanpham> AddNewSanpham(Sanpham sp) // Implement Interface
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7262/api/Sanphams/");

            //HTTP POST (FromJsonbody)
            var postTask = client.PostAsJsonAsync<Sanpham>("create", sp);
            postTask.Wait();

            return Task.FromResult(sp);
        }

        Task<IActionResult> ISanphamsService.UpdateSanpham(Sanpham sp)
        {
            throw new NotImplementedException();
        }
    }
}
