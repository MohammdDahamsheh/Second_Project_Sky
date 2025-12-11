using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IReposotiry<T> Repository { get; }
        Task<int> SaveChangesAsync();
    }
}
