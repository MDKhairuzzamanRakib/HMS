using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IHmsRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task Save();
    }
}
