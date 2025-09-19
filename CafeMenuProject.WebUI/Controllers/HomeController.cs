using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Entities;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        #region Ctor

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        public async Task<ActionResult> Index()
        {
            await _categoryService.InsertCategoryAsync(new Category
            {
                CategoryName = "Test Kategori 1",
                CreatorUserId = 1,
                ParentCategoryId = null,
                CreatedDate = DateTime.Now,
            });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}