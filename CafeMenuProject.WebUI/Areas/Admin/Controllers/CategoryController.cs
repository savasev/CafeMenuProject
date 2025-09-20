using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Areas.Admin.Models.Categories;
using CafeMenuProject.WebUI.Areas.Admin.Models.Products;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        #region Fields

        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region Utilities

        private async Task<CreateCategoryModel> PrepareCreateCategoryModelAsync(CreateCategoryModel model = null)
        {
            if (model == null)
                model = new CreateCategoryModel();

            model.AvailableParentCategories = (await _categoryService.GetAllCategoriesAsync()).Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName,
            }).ToList();

            return model;
        }

        #endregion

        #region Methods

        #region List

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        #endregion

        #region Create

        public async Task<ActionResult> Create()
        {
            var model = await PrepareCreateCategoryModelAsync();

            return View(model);
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            return View();
        }

        #endregion

        #region Delete

        public ActionResult Delete(int id)
        {
            return View();
        }

        #endregion

        #endregion
    }
}
