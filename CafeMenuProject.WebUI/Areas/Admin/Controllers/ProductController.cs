using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Areas.Admin.Models.Product;
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

        #endregion

        #region Create

        public ActionResult Create()
        {
            return View();
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
