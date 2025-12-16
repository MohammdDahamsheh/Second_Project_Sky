using Infrastrucure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private TenderContext context;
        private readonly DbSet<T> dbSet;
        public Repository(TenderContext context) { 
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities =await dbSet.ToListAsync();
            if (entities == null||entities.Count==0)
            {
                throw new Exception("No data found");
            }
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("No data found");
            }
            return entity;
        }

        public  bool UpdateAsync(T entity)
        {
             dbSet.Update(entity);
            return true;
        }
    }
}
