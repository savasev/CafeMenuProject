using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Models;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;

        #endregion

        #region Ctor

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #endregion

        #region Methods

        #region Login

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }



        #endregion

        #endregion
    }
}