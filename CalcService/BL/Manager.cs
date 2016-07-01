using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcService.DAL;
using CalcService.Models;

namespace CalcService.BL
{
    public class Manager: IManager
    {
        private readonly List<BaseOperation> operations;
        public IConversionRateLoader ConversionRateLoader { get; set; }

        public Manager()
        {
            //should be loaded via IoC container
            operations = new List<BaseOperation>()
            {
                new Addition(),
                new Subtraction(),
                new Multiplication(),
                new Division()
            };
            //should be via IoC
            ConversionRateLoader = new ConversionRateLoader();
        }

        public double Calculate(CalculateDto dto)
        {
            Validate(dto);
            var operation = operations.FirstOrDefault(o => o.OperationId == dto.Operation);
            double result = 0;
            if (operation != null)
                result = operation.PerformAction(dto.OperandA, dto.OperandB);
            return result;
        }

        public double ConvertToCurrency(ConversionDto dto)
        {
            Validate(dto);
            var conversionRates = ConversionRateLoader.GetCurrencyRates(dto.FromCurrency);
            return dto.Amount * conversionRates.Rates[dto.ToCurrency];
        }

        public Dictionary<string, int> GetOperations()
        {
            return operations.ToDictionary(operation => operation.OperationSign, operation => operation.OperationId);
        }

        private void Validate(CalculateDto dto)
        {
            if (dto == null)
                throw new ArgumentException("DTO is empty");
            //omitted
        }

        private void Validate(ConversionDto dto)
        {
            if (dto == null)
                throw new ArgumentException("DTO is empty");
            //omitted
        }
    }
}