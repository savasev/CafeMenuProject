using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.Unicode.GetBytes(password + salt);
                var hash = sha.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("X2"));

                return sb.ToString();
            }
        }

        #endregion

        #region Methods

        public async Task<(bool isValidated, User user)> ValidateLoginAsync(string username, string password)
        {
            var user = await _userRepository.Table
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();

            if (user == null)
                return (false, null);

            var inputHash = ComputeHash(password, user.SaltPassword);
            var isValid = string.Equals(inputHash, user.HashPassword, StringComparison.OrdinalIgnoreCase);

            return (isValid, user);
        }

        #endregion
    }
}
