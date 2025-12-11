using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Repository
{
    public interface IUnitOfWork<T>:IDisposable where T : class
    {
        IRepository<T> GetRepository { get; set; }
        Task<int> SaveChangesAsync();
    }
}
