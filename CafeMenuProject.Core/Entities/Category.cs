using CafeMenuProject.Core.Abstract;
using System;

namespace CafeMenuProject.Core.Entites
{
    /// <summary>
    /// Category entity
    /// </summary>
    public class Category : ISoftDeletedEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? ParentCategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime  CreatedDate { get; set; }

        public int CreatorUserId { get; set; }
    }
}
