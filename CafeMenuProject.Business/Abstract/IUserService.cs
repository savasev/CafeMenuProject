using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        Task<IPagedList<User>> GetAllUsersAsync(string username = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue);

        Task<User> GetUserByIdAsync(int id);

        Task InsertUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);

        Task<(bool isSuccess, string message)> InsertUserWithSpAsync(User user, string password);

        Task<(bool isSuccess, string message)> UpdateUserWithSpAsync(User user, string password);
    }
}
