using CalcService.Models;

namespace CalcService.DAL
{
    /// <summary>
    /// Class for access to conversion rate service
    /// </summary>
    public interface IConversionRateLoader
    {
        /// <summary>
        /// Loads currency rates
        /// </summary>
        /// <param name="baseCurrency">Base currency for rates</param>
        /// <returns>Rates for list of currencies</returns>
        CurrencyRates GetCurrencyRates(string baseCurrency);

    }
}
