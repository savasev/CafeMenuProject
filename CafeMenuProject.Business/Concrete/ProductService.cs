using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System;
using System.Linq;
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

        public async Task<IPagedList<Product>> GetAllProductsAsync(string productName = "",
            int? categoryId = null,
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _productRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrWhiteSpace(productName))
                    query = query.Where(x => x.ProductName.Contains(productName));

                if (categoryId > 0)
                    query = query.Where(x => x.CategoryId == categoryId);

                query = query.Where(x => !x.IsDeleted);

                query = query.OrderBy(x => x.ProductId);

                return query;

            }, pageIndex, pageSize);
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
