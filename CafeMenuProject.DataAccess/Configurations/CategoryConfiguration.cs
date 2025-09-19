using CafeMenuProject.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// Represents the category configuration
    /// </summary>
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        #region Constructor

        public CategoryConfiguration()
        {
            HasKey(c => c.CategoryId);

            Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.IsDeleted)
                .HasColumnAnnotation("DefaultValue", false);

            Property(c => c.CreatedDate)
                .HasColumnAnnotation("DefaultValueSql", "GETDATE()");
        }

        #endregion
    }
}
