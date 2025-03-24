namespace server.Dto;

public class RazorpayPaymentDto
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "INR";
}
