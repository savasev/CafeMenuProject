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
            HasKey(x => x.ProductId);

            Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            Property(x => x.IsDeleted)
                .HasColumnAnnotation("DefaultValue", false);

            Property(x => x.CreatedDate)
                .HasColumnAnnotation("DefaultValueSql", "GETDATE()");
        }

        #endregion
    }
}
