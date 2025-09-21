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
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.IsDeleted)
                .HasColumnAnnotation("DefaultValue", false);

            Property(x => x.CreatedDate)
                .IsRequired();
        }

        #endregion
    }
}
