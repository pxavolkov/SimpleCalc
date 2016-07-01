using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using CalcService.Models;
using Newtonsoft.Json;

namespace CalcService.DAL
{
    public class ConversionRateLoader: IConversionRateLoader
    {
        private const string CurrencyRateServiceUrl = "http://api.fixer.io/latest?base={0}";

        public CurrencyRates GetCurrencyRates(string baseCurrency)
        {
            string jsonResult;

            var request = (HttpWebRequest)WebRequest.Create(string.Format(CurrencyRateServiceUrl, baseCurrency));
            try
            {
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, Encoding.UTF8);
                    jsonResult = reader.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<CurrencyRates>(jsonResult);
                    return result;
                }
            }
            catch (WebException ex)
            {
                //log error
                return null;
            }
        }
    }
}