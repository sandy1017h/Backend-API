using System.ComponentModel.DataAnnotations;

namespace server.Entities;

public class PaymentTransaction
{
    [Key]
    public int Id { get; set; }  // Auto-increment Primary Key

    public int UserId { get; set; }  // Foreign Key: User ID from your system

    [Required]
    public string PaymentId { get; set; } // Razorpay Payment ID

    [Required]
    public string OrderId { get; set; } // Razorpay Order ID

    [Required]
    public decimal Amount { get; set; } // Payment Amount

    [Required]
    public string Status { get; set; } // Status: "Success" or "Failed"

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp
}
