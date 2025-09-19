using CafeMenuProject.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// Category entity configuration
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

            Property(c => c.IsDeleted)
                .IsRequired();

            Property(c => c.CreatedDate)
                .IsRequired();
        }

        #endregion
    }
}
