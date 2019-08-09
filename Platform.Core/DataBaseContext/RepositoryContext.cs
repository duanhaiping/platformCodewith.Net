using Platform.Infrastructure.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.DataBaseContext
{
    public abstract class RepositoryContext : IRepositoryContext
    {
        protected abstract System.Data.Entity.DbContext GetContext();

        public System.Data.Entity.DbContext Context
        {
            get
            {
                return GetContext();
            }
        }
        public void Add<T>(T entity) where T : class
        {
            if (Context != null)
            {
                Context.Set<T>().Add(entity);
            }

        }

        public void BeginTransaction()
        {
            if (Context != null && Context.Database.CurrentTransaction == null)
            {
                Context.Database.BeginTransaction();
            }

        }

        public void Commit()
        {
            if (Context != null && Context.Database.CurrentTransaction != null)
            {
                Context.Database.CurrentTransaction.Commit();
            }

        }

        public void Delete<T>(T entity) where T : class
        {
            if (Context != null)
            {
                Context.Set<T>().Remove(entity);
            }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            if (Context != null && Context.Database.CurrentTransaction != null)
            {
                Context.Database.CurrentTransaction.Rollback();
            }
        }

        public void Save()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        public void Update<T>(T entity) where T : class
        {
            if (Context!= null )
            {
                Context.Set<T>().Attach(entity);
                Context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public virtual void Dispose()
        {
            if (Context != null)
            {
                if (Context.Database.CurrentTransaction != null)
                {
                    Context.Database.CurrentTransaction.Dispose();
                }

                if (Context.Database.Connection.State != System.Data.ConnectionState.Closed)
                {
                    Context.Database.Connection.Close();
                }
                Context.Dispose();
            }
        }
    }
}
