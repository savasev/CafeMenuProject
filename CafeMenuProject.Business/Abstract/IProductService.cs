using CafeMenuProject.Business.Concrete.Dtos;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public interface IProductService
    {
        Task<IPagedList<Product>> GetAllProductsAsync(string productName = "",
            int? categoryId = null,
            int pageIndex = 0,
            int pageSize = int.MaxValue);

        Task<Product> GetProductByIdAsync(int id);

        Task InsertProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(Product product);

        Task<IPagedList<ProductPropertyDto>> GetAllProductPropertyDtosAsync(int productId,
            int pageIndex = 0,
            int pageSize = int.MaxValue);
    }
}
