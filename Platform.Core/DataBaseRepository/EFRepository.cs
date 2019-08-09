using Platform.Common.Service;
using Platform.Infrastructure.DataBaseContext;
using Platform.Infrastructure.DataBaseRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.DataBaseRepository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IRepositoryContext mobjContext = null;

        public IRepositoryContext Context
        {
            get { return mobjContext; }
        }

       
        public EFRepository(string conTextName = "Default")
        {
            IRepositoryContext context = ServiceLocator.GetService<IRepositoryContext>(conTextName);
            if (context is IRepositoryContext)
            {
                mobjContext = context;
            }
            else
            {
                throw new NotSupportedException();
            }
          
        }

       

        public void Add(TEntity entity)
        {
            mobjContext.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            mobjContext.Delete(entity);
        }

        public void DeleteByKey(params object[] keyValues)
        {
            TEntity defaultEntity = this.Find(keyValues);
            if (defaultEntity != null)
                mobjContext.Delete<TEntity>(defaultEntity);
        }

        public TEntity Find(params object[] keyValues)
        {
             return mobjContext.Context.Set<TEntity>().Find(keyValues);
        }

        public TEntity FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression = null, params string[] includePath)
        {
            return mobjContext.Context.Set<TEntity>().FirstOrDefault(expression);
        }

        public IList<TEntity> LoadPageList<TKey>(out long count, int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<TEntity, bool>> expression = null, System.Linq.Expressions.Expression<Func<TEntity, TKey>> orderBy = null, bool ascending = true, params string[] includePath)
        {
            IQueryable<TEntity> defaultQuery = Query(expression, includePath);
            if (orderBy!=null)
            {
                if (ascending)
                {
                    defaultQuery = defaultQuery.OrderBy(orderBy);
                }
                else
                {
                    defaultQuery = defaultQuery.OrderByDescending(orderBy);
                }
            }
            count = defaultQuery.Count();
            defaultQuery = defaultQuery.Skip(pageIndex*pageSize).Take(pageSize);
            return defaultQuery.ToList();
        }

        public IQueryable<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression = null, params string[] includePath)
        {
            IQueryable<TEntity> defaultQuery = mobjContext.Context.Set<TEntity>().Where(expression);
            if (includePath!= null)
            {
                foreach (var item in includePath)
                {
                    defaultQuery.Include(item);
                }
            }
            return defaultQuery;
        }

        public void Update(TEntity entity)
        {
            mobjContext.Update(entity);
        }
    }
}
