using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class ComponentsController : Controller
    {
        #region Fields



        #endregion

        #region Ctor

        public ComponentsController()
        {
            
        }

        #endregion

        #region Methods

        [ChildActionOnly]
        public ActionResult ProductProperyWidget(int productId)
        {
            return PartialView("_ProductProperyWidget");
        }

        #endregion
    }
}
