using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Helpers;
using CafeMenuProject.WebUI.Models;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authenticationService.ValidateLoginAsync(model.Username, model.Password);
            var user = result.user;

            if (!result.isValidated || user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(model);
            }

            AuthHelper.SignIn(user.UserId, user.Username);

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Logout

        public ActionResult Logout()
        {
            AuthHelper.SignOut();

            return RedirectToAction("Login");
        }

        #endregion

        #endregion
    }
}
