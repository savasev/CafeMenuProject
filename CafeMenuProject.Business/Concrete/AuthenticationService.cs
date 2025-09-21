using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IRepository<User> _userRepository;

        #endregion

        #region Constructor

        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Utilities

        private string ComputeHash(string password, string salt)
        {
            using (var sha = System.Security.Cryptography.SHA512.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);

                var hash = sha.ComputeHash(bytes);

                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        #endregion

        #region Methods

        public async Task<bool> ValidateLoginAsync(string username, string password)
        {
            var user = await _userRepository.Table.Where(u => u.Username == username).FirstOrDefaultAsync();
            if (user == null)
                return false;

            var salt = user.SaltPassword;
            var storedHash = user.HashPassword;

            var inputHash = ComputeHash(password, salt);

            return string.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
