using Infrastrucure;
using Microsoft.EntityFrameworkCore;


namespace Application.Repository
{
    public class Reposotiry <T>: IReposotiry<T> where T : class
    {
        private readonly TenderContext context;
        private readonly DbSet<T> dbSet;
        public Reposotiry(TenderContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var list = await dbSet.ToListAsync();
            if(list == null || list.Count == 0)
            {
                throw new Exception("No data found");
            }
            return list;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return entity;
        }

        public bool Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }
    }
}
