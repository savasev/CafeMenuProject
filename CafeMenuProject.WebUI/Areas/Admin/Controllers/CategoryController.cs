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
