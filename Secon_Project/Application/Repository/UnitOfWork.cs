using Infrastrucure;


namespace Application.Repository
{

    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly TenderContext context;
        public UnitOfWork(TenderContext context) {
            this.context = context;
        }
        public IReposotiry<T> Repository { get; }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
