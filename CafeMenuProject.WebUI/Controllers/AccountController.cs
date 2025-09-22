using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.WebUI.Areas.Admin.Validators.User;
using CafeMenuProject.WebUI.Helpers;
using CafeMenuProject.WebUI.Models;
using CafeMenuProject.WebUI.Validators;
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
            #region Validation

            var validator = new UserRegisterValidator();
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }

            #endregion

            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username,
            };

            var (isSuccess, message) = await _userService.InsertUserWithSpAsync(user, model.Password);
            if (!isSuccess)
            {
                ModelState.AddModelError("Username", message);

                return View(model);
            }

            return RedirectToAction("Login");
        }

        #endregion

        #endregion
    }
}
