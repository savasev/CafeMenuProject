using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
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
        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public AccountController(IAuthenticationService authenticationService,
            IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        #endregion

        #region Methods

        #region Login

        public ActionResult Login()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel model)
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

            AuthHelper.SignIn(user);

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

        #region Register

        public ActionResult Register()
        {
            AuthHelper.SignOut();

            return View(new UserRegisterModel());
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username,
            };

            await _userService.InsertUserWithSpAsync(user, model.Password);

            return RedirectToAction("Login");
        }

        #endregion

        #endregion
    }
}
