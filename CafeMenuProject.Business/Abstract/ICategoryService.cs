using CafeMenuProject.Core;
using CafeMenuProject.Core.Entities;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// Category service interface
    /// </summary>
    public interface ICategoryService
    {
        Task<IPagedList<Category>> GetAllCategoriesAsync(string categoryName = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue);

        Task<Category> GetCategoryByIdAsync(int id);
        
        Task InsertCategoryAsync(Category category);
        
        Task UpdateCategoryAsync(Category category);
        
        Task DeleteCategoryAsync(Category category);
    }
}
