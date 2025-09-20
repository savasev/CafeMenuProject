using CafeMenuProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMenuProject.DataAccess.Abstract
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Methods

        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);

        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool getOnlyTotalCount = false,
            bool includeDeleted = true);

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        #endregion
    }
}
