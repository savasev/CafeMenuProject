namespace CafeMenuProject.WebUI.Areas.Admin.Models.ExchangeRate
{
    /// <summary>
    /// Exchange rate model
    /// </summary>
    public class ExchangeRateModel
    {
        #region Properties

        public string CurrencyCode { get; set; }

        public decimal? ForexBuying { get; set; }

        public decimal? ForexSelling { get; set; }

        public decimal? BanknoteBuying { get; set; }

        public decimal? BanknoteSelling { get; set; }

        #endregion
    }
}
