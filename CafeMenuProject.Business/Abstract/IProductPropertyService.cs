using CafeMenuProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Product property service interface
    /// </summary>
    public interface IProductPropertyService
    {
        Task<IList<ProductProperty>> GetAllProductPropertiesAsync();

        Task<ProductProperty> GetProductPropertyByIdAsync(int id);

        Task InsertProductPropertyAsync(ProductProperty productProperty);

        Task UpdateProductPropertyAsync(ProductProperty productProperty);

        Task DeleteProductPropertyAsync(ProductProperty productProperty);
    }
}
