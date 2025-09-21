using CafeMenuProject.Core.Entities;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public interface IAuthenticationService
    {
        Task<(bool isValidated, User user)> ValidateLoginAsync(string username, string password);
    }
}
