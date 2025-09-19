using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System.Collections.Generic;
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

        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
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

        #endregion
    }
}
