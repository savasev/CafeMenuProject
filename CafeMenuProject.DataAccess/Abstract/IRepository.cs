using CafeMenuProject.Core;
using System;
using System.Data.SqlClient;
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

        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool getOnlyTotalCount = false);

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<(bool isSuccess, string message)> InsertWithSpAsync(string storedProcedureName, params SqlParameter[] parameters);

        Task<(bool isSuccess, string message)> UpdateWithSpAsync(string storedProcedureName, params SqlParameter[] parameters);

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        #endregion
    }
}
