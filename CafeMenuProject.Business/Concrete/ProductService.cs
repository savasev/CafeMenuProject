using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Business.Concrete.Dtos;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<IPagedList<ProductPropertyDto>> GetAllProductPropertyDtosAsync(int productId,
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            var productProperties = await _productPropertyRepository.GetAllPagedAsync(query =>
            {
                query = query.Where(x => x.ProductId == productId);

                return query.OrderBy(x => x.ProductPropertyId);

            }, pageIndex, pageSize);

            if (!productProperties.Any())
                return new PagedList<ProductPropertyDto>(new List<ProductPropertyDto>(), pageIndex, pageSize, productProperties.TotalCount);

            var propertyIds = productProperties.Select(x => x.PropertyId).ToList();

            var properties = await _propertyRepository.Table
                .Where(p => propertyIds.Contains(p.PropertyId))
                .ToListAsync();

            var propertyDict = properties.ToDictionary(p => p.PropertyId);

            var dtoList = productProperties.Select(pp => new ProductPropertyDto
            {
                ProductPropertyId = pp.ProductPropertyId,
                ProductId = pp.ProductId,
                PropertyId = pp.PropertyId,
                Key = propertyDict.ContainsKey(pp.PropertyId) ? propertyDict[pp.PropertyId].Key : null,
                Value = propertyDict.ContainsKey(pp.PropertyId) ? propertyDict[pp.PropertyId].Value : null
            }).ToList();

            return new PagedList<ProductPropertyDto>(dtoList,
                productProperties.PageIndex,
                productProperties.PageSize,
                productProperties.TotalCount);
        }

        #endregion
    }
}
