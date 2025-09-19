using CafeMenuProject.DataAccess.Abstract;
using CafeMenuProject.DataAccess.Context;
using CafeMenuProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMenuProject.DataAccess.Concrete
{
    /// <summary>
    /// Represents an entity framework repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion

        #region Ctor

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public IQueryable<TEntity> Query(bool includeDeleted = false)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

            if (!includeDeleted && typeof(ISoftDeletedEntity).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.OfType<ISoftDeletedEntity>()
                             .Where(e => !e.IsDeleted)
                             .OfType<TEntity>();
            }

            return query;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity is ISoftDeletedEntity softDeleted)
            {
                softDeleted.IsDeleted = true;
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Set<TEntity>().Remove(entity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter = null)
        {
            var query = Query();
            if (filter != null)
                query = filter(query);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity is ISoftDeletedEntity softDeleted && softDeleted.IsDeleted)
                return null;

            return entity;
        }

        public async Task InsertAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
