using CafeMenuProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public interface IProductService
    {
        Task<IList<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task InsertProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(Product product);
    }
}
