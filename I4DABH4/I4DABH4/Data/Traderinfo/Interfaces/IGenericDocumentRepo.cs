using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace I4DABH4.Data.Traderinfo
{
    public interface IGenericDocumentRepo<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(string id);
        List<TEntity> Get(TEntity entity);
        IEnumerable<List<TEntity>> GetAll();
        IEnumerable<List<TEntity>> Find(Expression<Func<List<TEntity>, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entity); 

    }
}
