namespace server.Dto;

public class PaymentOrder
{

    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
