using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMenuProject.Core
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    [Serializable]
    public class PagedList<TEntity> : List<TEntity>, IPagedList<TEntity>
    {
        #region Constructor

        public PagedList(IList<TEntity> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            pageSize = Math.Max(pageSize, 1);

            TotalCount = totalCount ?? source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(totalCount != null ? source : source.Skip(pageIndex * pageSize).Take(pageSize));
        }

        #endregion

        #region Properties

        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;

        #endregion
    }
}
