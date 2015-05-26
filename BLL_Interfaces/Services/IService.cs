using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Interface.Services
{
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> GetAllEntities();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> p);
        void Create(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}
