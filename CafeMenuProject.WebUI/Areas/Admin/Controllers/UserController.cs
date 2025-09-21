using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.WebUI.Areas.Admin.Models;
using CafeMenuProject.WebUI.Areas.Admin.Models.User;
using CafeMenuProject.WebUI.Areas.Admin.Validators.User;
using CafeMenuProject.WebUI.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
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

        #region Utilities

        private async Task<DataTableResult<UserViewModel>> PrepareUserDataTableResultAsync(UserSearchModel searchModel)
        {
            var users = await _userService.GetAllUsersAsync(username: searchModel.Username,
                pageIndex: searchModel.PageIndex,
                pageSize: searchModel.PageSize);

            var result = new DataTableResult<UserViewModel>
            {
                Draw = searchModel.Draw,
                RecordsTotal = users.TotalCount,
                RecordsFiltered = users.TotalCount,
                Data = users.Select(x => new UserViewModel
                {
                    UserId = x.UserId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Username = x.Username,
                }).ToList()
            };

            return result;
        }

        private CreateUserModel PrepareCreateUserModel(CreateUserModel model = null)
        {
            if (model == null)
                model = new CreateUserModel();

            return model;
        }

        private EditUserModel PrepareEditUserModel(EditUserModel model, User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (model == null)
            {
                model = new EditUserModel
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.Username,
                };
            }

            return model;
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
            return View(new UserSearchModel { PageSize = 15 });
        }

        [HttpPost]
        public async Task<ActionResult> UserList(UserSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var dataTableResult = await PrepareUserDataTableResultAsync(searchModel);

            return new JsonCamelCaseResult { Data = dataTableResult, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion

        #region Create

        public ActionResult Create()
        {
            var model = PrepareCreateUserModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserModel model)
        {
            #region Validation

            var validator = new CreateUserValidator();
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                model = PrepareCreateUserModel(model);
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
                ViewBag.ErrorMessage = message;

                model = PrepareCreateUserModel(model);

                return View(model);
            }

            return RedirectToAction("List");
        }

        #endregion

        #region Edit

        public async Task<ActionResult> Edit(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return RedirectToAction("List");

            return View(PrepareEditUserModel(null, user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserModel model)
        {
            var user = await _userService.GetUserByIdAsync(model.UserId);
            if (user == null)
                return RedirectToAction("List");

            #region Validation

            var validator = new EditUserValidator();
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                model = PrepareEditUserModel(model, user);
                return View(model);
            }

            #endregion

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Username = model.Username;

            var (isSuccess, message) = await _userService.UpdateUserWithSpAsync(user, model.Password);
            if (!isSuccess)
            {
                ViewBag.ErrorMessage = message;

                model = PrepareEditUserModel(model, user);

                return View(model);
            }

            return RedirectToAction("List");
        }

        #endregion

        #region Delete

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return Json(new { success = false, message = "Kullanıcı bulunamadı" });

            await _userService.DeleteUserAsync(user);

            return Json(new { success = true });
        }

        #endregion

        #endregion
    }
}
