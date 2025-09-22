using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// Product property service
    /// </summary>
    public class ProductPropertyService : IProductPropertyService
    {
        #region Fields

        private readonly IRepository<ProductProperty> _productPropertyRepository;

        #endregion

        #region Ctor

        public ProductPropertyService(IRepository<ProductProperty> productPropertyRepository)
        {
            _productPropertyRepository = productPropertyRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteProductPropertyAsync(ProductProperty productProperty)
        {
            await _productPropertyRepository.DeleteAsync(productProperty);
        }

        public async Task<ProductProperty> GetProductPropertyByIdAsync(int id)
        {
            return await _productPropertyRepository.GetByIdAsync(id);
        }

        public async Task InsertProductPropertyAsync(ProductProperty productProperty)
        {
            await _productPropertyRepository.InsertAsync(productProperty);
        }

        public async Task UpdateProductPropertyAsync(ProductProperty productProperty)
        {
            await _productPropertyRepository.UpdateAsync(productProperty);
        }

        #endregion
    }
}
