namespace server.Entities;

public class Orders
{
    public int Id { get; set; }  // Your internal order ID (Auto-increment)
    public string RazorpayOrderId { get; set; } // Razorpay provided Order ID
    public string UserId { get; set; } // User placing the order
    public decimal Amount { get; set; }
    public string Status { get; set; }  // "Pending", "Paid", "Shipped", "Delivered"
    public string PaymentId { get; set; } // Razorpay Payment ID
    public string ShippingAddress { get; set; }
    public DateTime OrderDate { get; set; }
}
