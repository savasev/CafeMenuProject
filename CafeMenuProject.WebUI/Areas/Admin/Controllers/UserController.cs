using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.WebUI.Areas.Admin.Models;
using CafeMenuProject.WebUI.Areas.Admin.Models.User;
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
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Username = model.Username,
                };

                await _userService.InsertUserAsync(user);

                return RedirectToAction("List");
            }

            model = PrepareCreateUserModel(model);

            return View(model);
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
