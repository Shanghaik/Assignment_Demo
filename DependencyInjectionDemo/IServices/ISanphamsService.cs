using Data.ModelsClass;

namespace DependencyInjectionDemo.IServices
{
    public interface ISanphamsService
    {
        Task<IEnumerable<Sanpham>> GetAllSanPham();
    }
}
