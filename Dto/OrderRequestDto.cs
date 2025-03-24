namespace server.Dto;

public class OrderRequestDto
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string ShippingAddress { get; set; }
}
