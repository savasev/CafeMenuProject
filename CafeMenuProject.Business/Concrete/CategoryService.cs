using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System;
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

        #endregion

        #region Ctor

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync(query =>
            {
                return query.Where(x => !x.IsDeleted);
            });
        }

        public async Task<IPagedList<Category>> GetAllCategoriesAsync(string categoryName,
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _categoryRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrWhiteSpace(categoryName))
                    query = query.Where(c => c.CategoryName.Contains(categoryName));
                
                query = query.Where(x => !x.IsDeleted);

                return (Task<IQueryable<Category>>)query.OrderBy(c => c.CategoryId);

            }, pageIndex, pageSize);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task InsertCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.Now;

            await _categoryRepository.InsertAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        #endregion
    }
}
