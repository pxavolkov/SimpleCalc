using System.Collections.Generic;
using System.Web.Http;
using CalcService.BL;
using CalcService.Models;

namespace CalcService.Controllers
{
    public class CalculationController : ApiController
    {
        public IManager Manager { get; set; }

        public CalculationController()
        {
            //Should be injected via dependency injection
            Manager = new Manager();
        }

        public Dictionary<string, int> GetOperations()
        {
            return Manager.GetOperations();
        }

        public double Post([FromBody]CalculateDto dto)
        {
            return Manager.Calculate(dto);
        }

    }
}
