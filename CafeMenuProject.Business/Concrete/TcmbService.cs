using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Business.Concrete.Dtos;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// TCMB service interface
    /// </summary>
    public class TcmbService : ITcmbService
    {
        #region Constants

        private const string Url = "https://www.tcmb.gov.tr/kurlar/today.xml";

        #endregion

        #region Utilities

        private decimal? TryParseDecimal(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            input = input.Trim().Replace("\u00A0", "").Replace(" ", "").Replace(",", ".");

            if (decimal.TryParse(input, NumberStyles.Number | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var value))
                return value;

            return null;
        }

        #endregion

        #region Methods

        public IList<ExchangeRateDto> GetExchangeRateDtos()
        {
            var doc = XDocument.Load(Url);

            var result = doc.Descendants("Currency")
                .Where(x => x.Attribute("Kod") != null
                    && x.Element("ForexSelling") != null
                    && x.Element("ForexBuying") != null
                    && x.Element("BanknoteBuying") != null
                    && x.Element("BanknoteSelling") != null)
                .Select(x => new ExchangeRateDto
                {
                    CurrencyCode = x.Attribute("Kod").Value,
                    ForexBuying = TryParseDecimal(x.Element("ForexBuying")?.Value),
                    ForexSelling = TryParseDecimal(x.Element("ForexSelling")?.Value),
                    BanknoteBuying = TryParseDecimal(x.Element("BanknoteBuying")?.Value),
                    BanknoteSelling = TryParseDecimal(x.Element("BanknoteSelling")?.Value)
                })
                .ToList();

            return result;
        }

        #endregion
    }
}
