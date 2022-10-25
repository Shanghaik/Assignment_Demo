using Data.ModelsClass;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.IServices
{
    public interface ISanphamsService
    {
        Task<IEnumerable<Sanpham>> GetAllSanPham();

        Task<Sanpham> GetSanPhamById(Guid id);
        Task<Sanpham> AddNewSanpham(Sanpham sp);
        Task<Sanpham> RemoveSanPham(Sanpham sp);
        Task<Sanpham> UpdateSanpham(Sanpham sp);
    }
}
