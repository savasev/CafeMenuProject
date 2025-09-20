using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.WebUI.Areas.Admin.Models;
using CafeMenuProject.WebUI.Areas.Admin.Models.Product;
using CafeMenuProject.WebUI.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        #region Fields

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public ProductController(ICategoryService categoryService,
            IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        #endregion

        #region Utilities

        private async Task<ProductSearchModel> PrepareProductSearchModelAsync(ProductSearchModel searchModel = null)
        {
            if (searchModel == null)
                searchModel = new ProductSearchModel { PageSize = 15 };

            searchModel.AvailableCategories = (await _categoryService.GetAllCategoriesAsync()).Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return searchModel;
        }

        private async Task<DataTableResult<ProductViewModel>> PrepareProductDataTableResultAsync(ProductSearchModel searchModel)
        {
            var products = await _productService.GetAllProductsAsync(productName: searchModel.ProductName,
                categoryId: searchModel.CategoryId,
                pageIndex: searchModel.PageIndex,
                pageSize: searchModel.PageSize);

            var result = new DataTableResult<ProductViewModel>
            {
                Draw = searchModel.Draw,
                RecordsTotal = products.TotalCount,
                RecordsFiltered = products.TotalCount,
                Data = products.Select(x => new ProductViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    CategoryId = x.CategoryId,
                    ImagePath = x.ImagePath,
                    Price = x.Price,
                    CreatedDate = x.CreatedDate.ToString("g"),
                }).ToList()
            };

            return result;
        }

        private async Task<CreateProductModel> PrepareCreateProductModelAsync(CreateProductModel model = null)
        {
            if (model == null)
                model = new CreateProductModel();

            model.AvailableCategories = (await _categoryService.GetAllCategoriesAsync()).Select(x => new SelectListItem
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

        public async Task<ActionResult> List()
        {
            var searchModel = await PrepareProductSearchModelAsync();

            return View(searchModel);
        }

        [HttpPost]
        public async Task<ActionResult> ProductList(ProductSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var dataTableResult = await PrepareProductDataTableResultAsync(searchModel);

            return new JsonCamelCaseResult { Data = dataTableResult, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion

        #region Create

        public async Task<ActionResult> Create()
        {
            var model = await PrepareCreateProductModelAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = model.ProductName,
                    CategoryId = model.CategoryId,
                    Price = model.Price,
                    ImagePath = model.ImagePath,
                    CreatorUserId = 1,
                    CreatedDate = DateTime.Now,
                };

                await _productService.InsertProductAsync(product);

                return RedirectToAction("List");
            }

            model = await PrepareCreateProductModelAsync(model);

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
