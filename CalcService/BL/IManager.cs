using System.Collections.Generic;
using CalcService.Models;

namespace CalcService.BL
{
    /// <summary>
    /// Class for all BL operations
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Method to perform calculation
        /// </summary>
        /// <param name="dto">Data transfer object with operands and operation</param>
        /// <returns>Result of operation</returns>
        double Calculate(CalculateDto dto);
        /// <summary>
        /// Converts value from one currency to another
        /// </summary>
        /// <param name="dto">Data transfer object with amount and currencies</param>
        /// <returns>Result of conversion</returns>
        double ConvertToCurrency(ConversionDto dto);
        /// <summary>
        /// Loads dictionary of all operations
        /// </summary>
        /// <returns>Dictionary of all operations</returns>
        Dictionary<string, int> GetOperations();
    }
}
