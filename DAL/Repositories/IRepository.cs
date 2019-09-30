using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace DesafioPagueVeloz.DAL.Repositories
{
    public interface IRepository<TModel, TPK>
    {
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> where = null,
                                   Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
                                   Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null);
        TModel GetById(TPK id);
        void Attach(TModel entity);
        void Add(TModel entity);
        void Add(IEnumerable<TModel> entities);
        void Update(TModel entity);
        void Update(IEnumerable<TModel> entities);
        void Delete(TModel entity);
        void Delete(IEnumerable<TModel> entities);
        void Delete(TPK id);
    }

    public interface IRepository<TModel> : IRepository<TModel, int>
    {
    }
}
