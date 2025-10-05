using System.Collections.Generic;

namespace CafeMenuProject.Core.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string HashPassword { get; set; }

        public string SaltPassword { get; set; }

        //public virtual ICollection<Product> Products { get; set; }

        //public virtual ICollection<Category> Categories { get; set; }
    }
}
