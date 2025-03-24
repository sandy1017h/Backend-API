namespace server.Dto;

public class UpdateCartItemDto
{
    public int UserId { get; set; }
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
} 