using CafeMenuProject.Business.Abstract;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public UserController(IUserService userService)
        {
            _userService = userService;
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
