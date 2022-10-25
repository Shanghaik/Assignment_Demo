using Data.ModelsClass;
using DependencyInjectionDemo.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

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


        public async Task<Sanpham> GetSanPhamById(Guid id)
        {
            Sanpham sanphams = new Sanpham();
            var httpClient = new HttpClient(); //tạo 1 http Client để call API
            var response = await httpClient.GetAsync("https://localhost:7262/api/Sanphams/get-"+id);
            //Lấy dữ liệu từ file Json -Cài nuget Newtonsoft.json
            //Đọc ra 1 file Json
            string sanphamResponse = await response.Content.ReadAsStringAsync();
            //Lấy ra list object từ string json
            sanphams = JsonConvert.DeserializeObject<Sanpham>(sanphamResponse);
            return sanphams;
        }
        public async Task<Sanpham> RemoveSanPham(Sanpham sp)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(sp), Encoding.UTF8, "application/json");
            var response = await client.GetAsync("https://localhost:7262/api/Sanphams/delete/" + sp.Id.ToString());
            string result = await response.Content.ReadAsStringAsync();
            return sp;
        }

        public async Task<Sanpham> UpdateSanpham(Sanpham sp)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(sp), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7262/api/Sanphams/update/" + sp.Id.ToString(), content);
            string result = await response.Content.ReadAsStringAsync();

            return sp;
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

        
    }
}
