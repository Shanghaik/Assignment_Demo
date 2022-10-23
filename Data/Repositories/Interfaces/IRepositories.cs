using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    // Thực hiện 1 IRepositories chung cho tất cả các loại model
    public interface IRepositories<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; set; } // DBset tổng
        // Các phương thức Lấy dữ liệu
        Task<TEntity> GetAsync(Guid id); // Lấy 1
        Task<IEnumerable<TEntity>> GetAllAsync(); // Lấy tất
        // Các phương thức thêm
        Task<TEntity> AddOneAsyn(TEntity entity); // thêm 1
        Task<TEntity> AddManyAsyn(IEnumerable<TEntity> entity); // thêm một loạt
        // Các phương thức xóa
        Task<dynamic> DeleteOneAsyn(dynamic id);  // Xóa 1
        Task<TEntity> DeleteManyAsyn(IEnumerable<TEntity> entity); // Xóa 1 loạt
        // Các phương thức sửa
        Task<TEntity> UpdateOneAsyn(TEntity entity); // Sửa 1
        Task<IEnumerable<TEntity>> UpdateManyAsyn(IEnumerable<TEntity> entity); // Sửa 1 loạt

    }
}
