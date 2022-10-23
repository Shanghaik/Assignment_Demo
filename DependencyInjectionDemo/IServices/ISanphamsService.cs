using Data.ModelsClass;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.IServices
{
    public interface ISanphamsService
    {
        Task<IEnumerable<Sanpham>> GetAllSanPham();
        Task<Sanpham> AddNewSanpham(Sanpham sp);
        Task<IActionResult> RemoveSanPham(Guid id);
        Task<IActionResult> UpdateSanpham(Sanpham sp);
    }
}
