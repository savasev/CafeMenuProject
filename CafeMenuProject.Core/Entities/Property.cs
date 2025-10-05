﻿using System.Collections.Generic;

namespace CafeMenuProject.Core.Entities
{
    /// <summary>
    /// Property entity
    /// </summary>
    public class Property
    {
        public int PropertyId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        //public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
