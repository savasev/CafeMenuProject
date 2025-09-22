using CafeMenuProject.Core.Entities;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Property service interface
    /// </summary>
    public interface IPropertyService
    {
        Task<Property> GetPropertyByIdAsync(int id);

        Task InsertPropertyAsync(Property property);

        Task UpdatePropertyAsync(Property property);

        Task DeletePropertyAsync(Property property);
    }
}
