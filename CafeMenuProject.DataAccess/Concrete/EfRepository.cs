using CafeMenuProject.Core;
using CafeMenuProject.Core.Abstract;
using CafeMenuProject.DataAccess.Abstract;
using CafeMenuProject.DataAccess.Context;
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

        #region Utilities

        private IQueryable<TEntity> AddDeletedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted)
                return query;

            if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) == null)
                return query;

            return query.OfType<ISoftDeletedEntity>().Where(x => !x.IsDeleted).OfType<TEntity>();
        }

        #endregion

        #region Methods

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

        public async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null)
        {
            var query = Table;
            if (func != null)
                query = func(query);

            return await query.ToListAsync();
        }

        public async Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool getOnlyTotalCount = false,
            bool includeDeleted = true)
        {
            var query = AddDeletedFilter(Table, includeDeleted);

            query = func != null ? func(query) : query;

            pageSize = Math.Max(pageSize, 1);

            var count = await query.CountAsync();

            var data = new List<TEntity>();

            if (!getOnlyTotalCount)
                data.AddRange(await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());

            return new PagedList<TEntity>(data, pageIndex, pageSize, count);
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

        #region Properties

        public IQueryable<TEntity> Table => _context.Set<TEntity>().AsNoTracking();

        #endregion
    }
}
