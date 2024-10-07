namespace AmountToString.Models
{
    public class AmountModel
    {
        public decimal Amount { get; set; }
        public string AmountInWords { get; set; } = string.Empty;
    }
}
