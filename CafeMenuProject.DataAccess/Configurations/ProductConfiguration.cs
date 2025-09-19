using CafeMenuProject.Core.Entities;
using CafeMenuProject.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// Product entity configuration
    /// </summary>
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        #region Constructor

        public ProductConfiguration()
        {
            HasKey(p => p.ProductId);

            Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            Property(p => p.IsDeleted)
                .HasColumnAnnotation("DefaultValue", false);

            Property(p => p.CreatedDate)
                .HasColumnAnnotation("DefaultValueSql", "GETDATE()");
        }

        #endregion
    }
}
