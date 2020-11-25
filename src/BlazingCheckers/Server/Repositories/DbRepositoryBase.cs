using BlazingCheckers.Server.Data;
using BlazingCheckers.Server.Data.Entities;
using System.Linq;

namespace BlazingCheckers.Server.Repositories
{
    public class DbRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected readonly BlazingCheckersContext _context;
        protected IQueryable<TEntity> _baseQuery;

        public DbRepositoryBase(BlazingCheckersContext context)
        {
            _context = context;
            _baseQuery = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _baseQuery;
        }

        public virtual TEntity GetById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual bool Delete(object id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges() >= 1;
        }
    }
}
