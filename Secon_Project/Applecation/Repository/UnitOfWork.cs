using Domain.Entity;
using Infrastrucure;


namespace Applecation.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private  TenderContext _dbContext;
        public IRepository<T> GetRepository { get; set; }
        public UnitOfWork(TenderContext dbContext,IRepository<T>repository)
        {
            _dbContext = dbContext;
           GetRepository = repository;

        }


        public void Dispose()
        {
            _dbContext.Dispose();

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
