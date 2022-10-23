using Data.DbContexts;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    // : đầu tiên là kế thừa, : sau là xác định kiểu của TEntity
    public class AllRepositories<TEntity> : IRepositories<TEntity> where TEntity : class
    {
        private readonly CuahangDbContext _dbContext;
        public DbSet<TEntity> Entities { get; set; }
        
        public AllRepositories(CuahangDbContext cuahangDbContext)
        {
            this._dbContext = cuahangDbContext;
            this.Entities =  _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddOneAsyn(TEntity entity)
        {
            await this.Entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();  
            return entity;
        }

        public async Task<TEntity> AddManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.AddOneAsyn(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }

        public async Task<dynamic> DeleteOneAsyn(dynamic id)
        {
            var entity = Entities.FindAsync(id);
            dynamic x = Entities.Remove(entity).Entity;
            return x;
        }

        public async Task<TEntity> DeleteManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.DeleteOneAsyn(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<TEntity> UpdateOneAsyn(TEntity entity)
        {
            return Entities.Update(entity).Entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.UpdateOneAsyn(item));
            }
            return (IEnumerable<TEntity>)result;
        }
    }
}
