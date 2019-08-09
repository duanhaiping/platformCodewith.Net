using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Infrastructure.DataBaseContext
{
    public interface IRepositoryContext : ITransactionProcessor
    {
        DbContext Context { get; }
        void Initialize();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Save();
    }

}
