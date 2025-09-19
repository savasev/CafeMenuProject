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
            HasKey(c => c.PropertyId);
        }

        #endregion
    }
}
