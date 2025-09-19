using CafeMenuProject.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// Product property entity configuration
    /// </summary>
    public class ProductPropertyConfiguration : EntityTypeConfiguration<ProductProperty>
    {
        #region Construction

        public ProductPropertyConfiguration()
        {
            HasKey(c => c.ProductPropertyId);
        }

        #endregion
    }
}
