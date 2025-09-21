using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly IRepository<User> _userRepository;

        #endregion

        #region Ctor

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteUserAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
        }

        public async Task<IPagedList<User>> GetAllUsersAsync(string username = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _userRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrWhiteSpace(username))
                    query = query.Where(x => x.Username.Contains(username));

                query = query.OrderBy(x => x.UserId);

                return query;

            }, pageIndex, pageSize);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task InsertUserAsync(User user)
        {
            await _userRepository.InsertAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task<(bool isSuccess, string message)> InsertUserWithSpAsync(User user, string password)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", user.Name ?? (object)DBNull.Value),
                new SqlParameter("@Surname", user.Surname ?? (object)DBNull.Value),
                new SqlParameter("@Username", user.Username ?? (object)DBNull.Value),
                new SqlParameter("@Password", password ?? (object)DBNull.Value),
            };

            return await _userRepository.InsertWithSpAsync("EXEC dbo.sp_InsertUser @Name, @Surname, @Username, @Password", parameters);
        }

        public async Task<(bool isSuccess, string message)> UpdateUserWithSpAsync(User user, string password)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@Name", user.Name ?? (object)DBNull.Value),
                new SqlParameter("@Surname", user.Surname ?? (object)DBNull.Value),
                new SqlParameter("@Username", user.Username ?? (object)DBNull.Value),
                new SqlParameter("@Password", password ?? (object)DBNull.Value),
            };

            return await _userRepository.InsertWithSpAsync("EXEC dbo.sp_UpdateUser @UserId, @Name, @Surname, @Username, @Password", parameters);
        }

        #endregion
    }
}
