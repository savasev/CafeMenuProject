using CafeMenuProject.DataAccess.Configurations;
using CafeMenuProject.Entities;
using System.Data.Entity;

namespace CafeMenuProject.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext() : base("name=CafeMenuDbConnection")
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
        }

        #endregion
    }
}
