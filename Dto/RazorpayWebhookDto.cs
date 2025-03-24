namespace server.Dto;

public class RazorpayWebhookDto
{
    public string PaymentId { get; set; }
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Signature { get; set; }
}
