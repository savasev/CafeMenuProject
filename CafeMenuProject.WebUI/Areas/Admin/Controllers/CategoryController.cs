using CafeMenuProject.Business.Abstract;
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

        #region Methods

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            ViewBag.Title = "Kategoriler";

            return View();
        }

        #endregion
    }
}
