﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace I4DABH4.Data.Traderinfo
{
    public interface ICollectionRepo<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        TEntity Get(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindLatestOrDefault(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> StartsWith(string stringLikeWildcard);
        IQueryable<TEntity> ExposeSql(string sql);
        IQueryable<TEntity> Query();
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        

    }
}
