using System.Collections.Generic;

namespace CalcService.Models
{
    public class CurrencyRates
    {
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}