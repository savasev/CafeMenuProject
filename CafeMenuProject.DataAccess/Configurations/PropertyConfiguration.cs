using CafeMenuProject.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// Property entity configuration
    /// </summary>
    public class PropertyConfiguration : EntityTypeConfiguration<Property>
    {
        #region Constructor

        public PropertyConfiguration()
        {
            HasKey(x => x.PropertyId);

            Property(x => x.Key)
                .IsRequired();

            Property(x => x.Value)
                .IsRequired();
        }

        #endregion
    }
}
