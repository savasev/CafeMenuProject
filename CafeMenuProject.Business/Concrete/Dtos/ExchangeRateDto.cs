namespace CafeMenuProject.Business.Concrete.Dtos
{
    /// <summary>
    /// Exchange rate dto
    /// </summary>
    public class ExchangeRateDto
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
