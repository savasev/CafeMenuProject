using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.WebUI.Areas.Admin.Models;
using CafeMenuProject.WebUI.Areas.Admin.Models.Product;
using CafeMenuProject.WebUI.Filters;
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
        private readonly IPropertyService _propertyService;
        private readonly IProductPropertyService _productPropertyService;

        #endregion

        #region Ctor

        public ProductController(ICategoryService categoryService,
            IProductService productService,
            IPropertyService propertyService,
            IProductPropertyService productPropertyService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _propertyService = propertyService;
            _productPropertyService = productPropertyService;
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

        private async Task<EditProductModel> PrepareEditProductModelAsync(Product product, EditProductModel model = null)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (model == null)
            {
                model = new EditProductModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,
                    ImagePath = product.ImagePath,
                    Price = product.Price,
                };
            }

            model.AvailableCategories = (await _categoryService.GetAllCategoriesAsync()).Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName,
            }).ToList();

            return model;
        }

        private async Task<DataTableResult<ProductPropertyViewModel>> PrepareProductPropertyDataTableResultAsync(ProductPropertySearchModel searchModel)
        {
            var products = await _productService.GetAllProductPropertyDtosAsync(productId: searchModel.ProductId,
                pageIndex: searchModel.PageIndex,
                pageSize: searchModel.PageSize);

            var result = new DataTableResult<ProductPropertyViewModel>
            {
                Draw = searchModel.Draw,
                RecordsTotal = products.TotalCount,
                RecordsFiltered = products.TotalCount,
                Data = products.Select(x => new ProductPropertyViewModel
                {
                    ProductPropertyId = x.ProductPropertyId,
                    PropertyId = x.PropertyId,
                    Key = x.Key,
                    Value = x.Value,
                }).ToList()
            };

            return result;
        }

        private EditProductPropertyModel PrepareEditProductPropertyModel(EditProductPropertyModel model, ProductProperty productProperty, Property property)
        {
            if (productProperty == null)
                throw new ArgumentNullException(nameof(productProperty));

            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (model == null)
            {
                model = new EditProductPropertyModel
                {
                    ProductPropertyId = productProperty.ProductPropertyId,
                    Key = property.Key,
                    Value = property.Value,
                };
            }

            return model;
        }

        #endregion

        #region Methods

        #region Product methods

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

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProductModel model, bool continueEditing)
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

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = product.ProductId });
            }

            model = await PrepareCreateProductModelAsync(model);

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.IsDeleted)
                return RedirectToAction("List");

            var model = await PrepareEditProductModelAsync(product);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProductModel model, bool continueEditing)
        {
            var product = await _productService.GetProductByIdAsync(model.ProductId);
            if (product == null || product.IsDeleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                product.ProductName = model.ProductName;
                product.CategoryId = model.CategoryId;
                product.Price = model.Price;
                product.ImagePath = model.ImagePath;

                await _productService.UpdateProductAsync(product);

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = product.ProductId });
            }

            model = await PrepareEditProductModelAsync(product, model);

            return View(model);
        }

        #endregion

        #region Delete

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.IsDeleted)
                return Json(new { success = false, message = "Ürün bulunamadı" });

            await _productService.DeleteProductAsync(product);

            return Json(new { success = true });
        }

        #endregion

        #endregion

        #region Product property methods

        public async Task<ActionResult> ProductProperty(int id)
        {
            var productProperty = await _productPropertyService.GetProductPropertyByIdAsync(id);
            if (productProperty == null)
                return Json(new { success = false, message = "Ürün özellik bulunamadı" }, JsonRequestBehavior.AllowGet);

            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
                return Json(new { success = false, message = "Ürün özellik bulunamadı" }, JsonRequestBehavior.AllowGet);

            var model = PrepareEditProductPropertyModel(null, productProperty, property);
            var html = RenderPartialViewToString("_EditProductProperty", model);

            return Json(new { success = true, html = html }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ProductPropertyList(ProductPropertySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var dataTableResult = await PrepareProductPropertyDataTableResultAsync(searchModel);

            return new JsonCamelCaseResult { Data = dataTableResult, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductProperty(CreateProductPropertyModel model)
        {
            var product = await _productService.GetProductByIdAsync(model.ProductId);
            if (product == null || product.IsDeleted)
                return Json(new { success = false, message = "Ürün bulunamadı" });

            if (ModelState.IsValid)
            {
                var property = new Property
                {
                    Key = model.Key,
                    Value = model.Value,
                };

                await _propertyService.InsertPropertyAsync(property);

                var productProperty = new ProductProperty
                {
                    ProductId = model.ProductId,
                    PropertyId = property.PropertyId,
                };

                await _productPropertyService.InsertProductPropertyAsync(productProperty);

                return Json(new { success = true });
            }

            var errors = string.Join("<br/>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

            return Json(new { success = false, message = errors });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProductProperty(int id)
        {
            var productProperty = await _productPropertyService.GetProductPropertyByIdAsync(id);
            if (productProperty == null)
                return Json(new { success = false, message = "Ürün özellik bulunamadı" });

            await _productPropertyService.DeleteProductPropertyAsync(productProperty);

            return Json(new { success = true });
        }

        #endregion

        #endregion
    }
}
