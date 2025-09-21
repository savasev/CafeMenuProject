using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
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
        private readonly IRepository<ProductProperty> _productPropertyRepository;
        private readonly IRepository<Property> _propertyRepository;

        #endregion

        #region Ctor

        public ProductService(IRepository<Product> productRepository,
            IRepository<ProductProperty> productPropertyRepository,
            IRepository<Property> propertyRepository)
        {
            _productRepository = productRepository;
            _productPropertyRepository = productPropertyRepository;
            _propertyRepository = propertyRepository;
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

        public async Task<IPagedList<Property>> GetAllProductPropertiesAsync(int productId,
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _propertyRepository.GetAllPagedAsync(query =>
            {
                if (productId > 0)
                {
                    query = from q in query
                            join productProductRepo in _productPropertyRepository.Table on q.PropertyId equals productProductRepo.PropertyId
                            where productProductRepo.ProductId == productId
                            select q;
                }

                query = query.OrderBy(x => x.PropertyId);

                return query;

            }, pageIndex, pageSize);
        }

        #endregion
    }
}
