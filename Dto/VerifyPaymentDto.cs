namespace server.Dto;

public class VerifyPaymentDto
{
    public string PaymentId { get; set; }
    public string OrderId { get; set; }
    public string Signature { get; set; }
    public int UserId { get; set; }  // User ID from your system
    public decimal Amount { get; set; }
}
