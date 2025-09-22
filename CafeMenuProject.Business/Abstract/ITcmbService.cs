using CafeMenuProject.Business.Concrete.Dtos;
using System.Collections.Generic;

namespace CafeMenuProject.Business.Abstract
{
    /// <summary>
    /// TCMB service interface
    /// </summary>
    public interface ITcmbService
    {
        IList<ExchangeRateDto> GetExchangeRateDtos();
    }
}
