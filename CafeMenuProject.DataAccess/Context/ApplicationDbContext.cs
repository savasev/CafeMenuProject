using CafeMenuProject.Core.Entites;
using CafeMenuProject.DataAccess.Configurations;
using System.Data.Entity;

namespace CafeMenuProject.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext() : base("CafeMenuDb")
        {
        }

        #endregion

        #region DbSets

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        #endregion

        #region Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new PropertyConfiguration());
            modelBuilder.Configurations.Add(new ProductPropertyConfiguration());
        }

        #endregion
    }
}
