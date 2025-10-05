using CafeMenuProject.Core.Abstract;
using System;
using System.Collections.Generic;

namespace CafeMenuProject.Core.Entities
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

        public DateTime CreatedDate { get; set; }

        public int CreatorUserId { get; set; }

        //public virtual ICollection<Product> Products { get; set; }

        //public virtual User CreatorUser { get; set; }
    }
}
