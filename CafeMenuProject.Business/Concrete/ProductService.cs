using CafeMenuProject.Business.Abstract;
using CafeMenuProject.DataAccess.Abstract;
using CafeMenuProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// Product service
    /// </summary>
    public class ProductService : IProductService
    {
        #region Fields

        private readonly IRepository<Product> _productRepository;

        #endregion

        #region Ctor

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteProductAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task InsertProductAsync(Product product)
        {
            await _productRepository.InsertAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        #endregion
    }
}
