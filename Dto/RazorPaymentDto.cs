namespace server.Dto;

public class RazorPaymentDto
{
    public string PaymentId { get; set; }  // Razorpay Payment ID
    public string OrderId { get; set; }    // Razorpay Order ID
    public string Signature { get; set; }  // Razorpay Signature
    public int UserId { get; set; }       
    public decimal Amount { get; set; }
}
