using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Infrastructure.DataBaseRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
       
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression = null, params string[] includePath);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression = null, params string[] includePath);
        TEntity Find(params object[] keyValues);
        void Delete(TEntity entity);
        void DeleteByKey(params object[] keyValues);
        void Update(TEntity entity);
        void Add(TEntity entity);
        IList<TEntity> LoadPageList<TKey>(out long count, int pageIndex, int pageSize, Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, TKey>> orderBy = null, bool ascending = true, params string[] includePath);
    }
}
