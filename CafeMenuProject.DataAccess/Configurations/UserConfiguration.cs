using CafeMenuProject.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CafeMenuProject.DataAccess.Configurations
{
    /// <summary>
    /// User entity configuration
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        #region Constructor

        public UserConfiguration()
        {
            HasKey(c => c.UserId);
        }

        #endregion
    }
}
