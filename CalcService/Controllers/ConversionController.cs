using System.Web.Http;
using CalcService.BL;
using CalcService.Models;

namespace CalcService.Controllers
{
    public class ConversionController: ApiController
    {
        public IManager Manager { get; set; }
        public ConversionController()
        {
            //IoC container should be used to initialize dependency
            Manager = new Manager();
        }

        public double GetConversion([FromUri]ConversionDto dto)
        {
            return Manager.ConvertToCurrency(dto);
        }
    }
}