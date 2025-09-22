using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Areas.Admin.Models.Category;
using CafeMenuProject.WebUI.Areas.Admin.Models.ExchangeRate;
using CafeMenuProject.WebUI.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        #region Fields

        private readonly ICategoryService _categoryService;
        private readonly ITcmbService _tcmbService;

        #endregion

        #region Ctor

        public HomeController(ICategoryService categoryService,
            ITcmbService tcmbService)
        {
            _categoryService = categoryService;
            _tcmbService = tcmbService;
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ExchangeRates()
        {
            var exchangeRates = _tcmbService.GetExchangeRateDtos().Select(x => new ExchangeRateModel
            {
                CurrencyCode = x.CurrencyCode,
                ForexBuying = x.ForexBuying,
                ForexSelling = x.ForexSelling,
                BanknoteBuying = x.BanknoteBuying,
                BanknoteSelling = x.BanknoteSelling,
            }).ToList();

            return new JsonCamelCaseResult { Data = exchangeRates, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public async Task<ActionResult> CategoriesWithProductCount()
        {
            var categories = (await _categoryService.GetCategoryWithProductCountDtosAsync())
                .Select(x => new CategoryWithProductCountModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    TotalProductCount = x.TotalProductCount,
                }).ToList();

            return new JsonCamelCaseResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion
    }
}
