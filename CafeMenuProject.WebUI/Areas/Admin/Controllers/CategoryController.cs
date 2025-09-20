using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.WebUI.Areas.Admin.Models;
using CafeMenuProject.WebUI.Areas.Admin.Models.Categories;
using CafeMenuProject.WebUI.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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

        private async Task<EditCategoryModel> PrepareEditCategoryModelAsync(Category category, EditCategoryModel model = null)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (model == null)
            {
                model = new EditCategoryModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    ParentCategoryId = category.ParentCategoryId,
                };
            }

            model.AvailableParentCategories = (await _categoryService.GetAllCategoriesAsync()).Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName,
            }).ToList();

            return model;
        }

        private async Task<DataTableResult<CategoryViewModel>> PrepareCategoryDataTableResultAsync(CategorySearchModel searchModel)
        {
            var pagedCategories = await _categoryService.GetAllCategoriesAsync(categoryName: searchModel.CategoryName,
                pageIndex: searchModel.PageIndex,
                pageSize: searchModel.PageSize);

            var result = new DataTableResult<CategoryViewModel>
            {
                Draw = searchModel.Draw,
                RecordsTotal = pagedCategories.TotalCount,
                RecordsFiltered = pagedCategories.TotalCount,
                Data = pagedCategories.Select(x => new CategoryViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    CreatedDate = x.CreatedDate.ToString("g"),
                }).ToList()
            };

            return result;
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
            return View(new CategorySearchModel { PageSize = 15 });
        }

        [HttpPost]
        public async Task<ActionResult> CategoryList(CategorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var dataTableResult = await PrepareCategoryDataTableResultAsync(searchModel);

            return new JsonCamelCaseResult { Data = dataTableResult, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion

        #region Create

        public async Task<ActionResult> Create()
        {
            var model = await PrepareCreateCategoryModelAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName,
                    ParentCategoryId = model.ParentCategoryId,
                    CreatorUserId = 1,
                };

                await _categoryService.InsertCategoryAsync(category);

                return RedirectToAction("List");
            }

            model = await PrepareCreateCategoryModelAsync(model);

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null || category.IsDeleted)
                return RedirectToAction("List");

            var model = await PrepareEditCategoryModelAsync(category);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditCategoryModel model)
        {
            var category = await _categoryService.GetCategoryByIdAsync(model.CategoryId);
            if (category == null || category.IsDeleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                category.CategoryName = model.CategoryName;
                category.ParentCategoryId = model.ParentCategoryId;

                await _categoryService.UpdateCategoryAsync(category);

                return RedirectToAction("List");
            }

            model = await PrepareEditCategoryModelAsync(category, model);

            return View(model);
        }

        #endregion

        #region Delete

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null || category.IsDeleted)
                return Json(new { success = false, message = "Kategori bulunamadı" });

            await _categoryService.DeleteCategoryAsync(category);

            return Json(new { success = true });
        }

        #endregion

        #endregion
    }
}
