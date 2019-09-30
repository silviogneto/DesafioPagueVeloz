using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DesafioPagueVeloz.DAL.Repositories
{
    public abstract class Repository<TModel, TPK> : IRepository<TModel, TPK> where TModel : class
    {
        public DbSet<TModel> DbSet { get; private set; }

        public Repository(DatabaseContext context)
        {
            DbSet = context.Set<TModel>();
        }

        public virtual IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> where = null,
                                                  Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
                                                  Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null)
        {
            var dbSet = DbSet.AsQueryable();

            if (include != null)
                dbSet = include(dbSet);

            if (where != null)
                dbSet = dbSet.Where(where);

            if (orderBy != null)
                dbSet = orderBy(dbSet);

            return dbSet;
        }

        public abstract TModel GetById(TPK id);

        public void Attach(TModel entity) => DbSet.Attach(entity);

        public virtual void Add(TModel entity) => DbSet.Add(entity);

        public virtual void Add(IEnumerable<TModel> entities) => DbSet.AddRange(entities);

        public virtual void Update(TModel entity) => DbSet.Update(entity);

        public virtual void Update(IEnumerable<TModel> entities) => DbSet.UpdateRange(entities);

        public virtual void Delete(TModel entity) => DbSet.Remove(entity);

        public virtual void Delete(IEnumerable<TModel> entities) => DbSet.RemoveRange(entities);

        public void Delete(TPK id)
        {
            var entity = GetById(id);
            if (entity != null)
                Delete(entity);
        }
    }

    public abstract class Repository<TModel> : Repository<TModel, int> where TModel : class
    {
        public Repository(DatabaseContext context) : base(context)
        {
        }
    }
}
