using CafeMenuProject.Business.Abstract;
using CafeMenuProject.WebUI.Areas.Admin.Models;
using CafeMenuProject.WebUI.Areas.Admin.Models.ExchangeRate;
using CafeMenuProject.WebUI.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        #region Fields

        private readonly ITcmbService _tcmbService;

        #endregion

        #region Ctor

        public HomeController(ITcmbService tcmbService)
        {
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

        #endregion
    }
}
