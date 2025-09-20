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
            HasKey(x => x.UserId);

            Property(x => x.Name)
                .HasMaxLength(50);

            Property(x => x.Surname)
                .HasMaxLength(50);

            Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.HashPassword)
                .IsRequired();

            Property(x => x.SaltPassword)
                .IsRequired();
        }

        #endregion
    }
}
