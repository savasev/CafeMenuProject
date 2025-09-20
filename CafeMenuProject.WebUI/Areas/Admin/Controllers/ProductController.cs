using CafeMenuProject.Business.Abstract;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        #region Fields

        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
