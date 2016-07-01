namespace CalcService.Models
{
    public class ConversionDto
    {
        public double Amount { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
    }
}