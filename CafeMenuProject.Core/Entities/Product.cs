using CafeMenuProject.Core.Abstract;
using System;
using System.Collections.Generic;

namespace CafeMenuProject.Core.Entities
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product : ISoftDeletedEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatorUserId { get; set; }

        //public virtual Category Category { get; set; }

        //public virtual ICollection<ProductProperty> ProductProperties { get; set; }

        //public virtual User CreatorUser { get; set; }
    }
}
