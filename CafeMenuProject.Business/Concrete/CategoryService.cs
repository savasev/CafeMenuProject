using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Business.Concrete.Dtos;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// Category service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        #endregion

        #region Ctor

        public CategoryService(IRepository<Category> categoryRepository,
            IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IPagedList<Category>> GetAllCategoriesAsync(string categoryName = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _categoryRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrWhiteSpace(categoryName))
                    query = query.Where(c => c.CategoryName.Contains(categoryName));

                query = query.Where(x => !x.IsDeleted);

                query = query.OrderBy(c => c.CategoryId);

                return query;

            }, pageIndex, pageSize);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _categoryRepository.InsertAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task<List<CategoryWithProductCountDto>> GetCategoryWithProductCountDtosAsync()
        {
            var categories = await _categoryRepository.GetAllPagedAsync(query =>
            {
                query = query.Where(x => !x.IsDeleted);
                query = query.OrderBy(c => c.CategoryId);
                return query;
            });

            var products = await _productRepository.GetAllPagedAsync(query =>
            {
                query = query.Where(x => !x.IsDeleted);
                query = query.OrderBy(p => p.ProductId);
                return query;
            });

            // Dictionary: CategoryId -> product count
            var productCounts = products.GroupBy(p => p.CategoryId).ToDictionary(g => g.Key, g => g.Count());

            var result = new List<CategoryWithProductCountDto>();

            /// <summary>
            /// Recursively calculates the total number of products for a category,
            /// including all its child categories, and adds the category to the result list.
            /// Parent is added first, then children, to maintain parent-first order.
            /// </summary>
            int CalculateTotalProducts(Category category)
            {
                // Own product count
                int total = productCounts.ContainsKey(category.CategoryId) ? productCounts[category.CategoryId] : 0;

                // Add parent first
                var dto = new CategoryWithProductCountDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    TotalProductCount = total
                };
                result.Add(dto);

                // Process children
                var childCategories = categories.Where(c => c.ParentCategoryId == category.CategoryId).OrderBy(c => c.CategoryId);

                foreach (var child in childCategories)
                {
                    total += CalculateTotalProducts(child);
                }

                // Update total including children
                dto.TotalProductCount = total;

                return total;
            }

            // Start from root categories sorted by ID
            foreach (var root in categories.Where(c => c.ParentCategoryId == null).OrderBy(c => c.CategoryId))
                CalculateTotalProducts(root);

            return result;
        }

        #endregion
    }
}
