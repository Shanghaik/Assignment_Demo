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
    }
}
