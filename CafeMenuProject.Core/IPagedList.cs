using System.Collections.Generic;

namespace CafeMenuProject.Core
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IPagedList<TEntity> : IList<TEntity>
    {
        /// <summary>
        /// Page index
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Page size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Total count
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Has previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Has next age
        /// </summary>
        bool HasNextPage { get; }
    }
}
