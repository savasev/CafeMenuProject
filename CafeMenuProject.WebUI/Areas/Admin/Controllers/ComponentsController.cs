using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Areas.Admin.Models.Property;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class ComponentsController : Controller
    {
        #region Fields

        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public ComponentsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Methods

        [ChildActionOnly]
        public async Task<ActionResult> ProductProperyWidget(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null || product.IsDeleted)
                return Content(string.Empty);

            return PartialView("_ProductProperyWidget", new PropertySearchModel { ProductId = productId, PageSize = 15 });
        }

        #endregion
    }
}
