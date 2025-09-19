using CafeMenuProject.Core.Entites;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// Represents the product configuration
    /// </summary>
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        #region Constructor

        public ProductConfiguration()
        {
            HasKey(c => c.ProductId);

            Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            Property(c => c.IsDeleted)
                .HasColumnAnnotation("DefaultValue", false);

            Property(c => c.CreatedDate)
                .HasColumnAnnotation("DefaultValueSql", "GETDATE()");
        }

        #endregion
    }
}
