using CafeMenuProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Category service interface
    /// </summary>
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);
        
        Task InsertCategoryAsync(Category category);
        
        Task UpdateCategoryAsync(Category category);
        
        Task DeleteCategoryAsync(Category category);
    }
}
