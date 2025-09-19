using CafeMenuProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        Task<IList<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task InsertUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);
    }
}
