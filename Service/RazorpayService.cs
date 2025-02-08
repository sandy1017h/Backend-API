using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using System.Collections.Generic;

namespace server.Service;
public class RazorpayService
{
    private readonly string _key;
    private readonly string _secret;

    public RazorpayService(IConfiguration configuration)
    {
        _key = configuration["Razorpay:KeyId"];
        _secret = configuration["Razorpay:KeySecret"];
    }

    // Create order in Razorpay
    public PaymentOrder CreateOrder(decimal amount, string currency = "INR")
    {
        // Convert amount to the smallest currency unit (e.g., paise for INR)
        var amountInSubunits = (int)(amount * 100);

        var client = new RazorpayClient(_key, _secret);

        var options = new Dictionary<string, object>
        {
            { "amount", amountInSubunits },
            { "currency", currency },
            { "payment_capture", 1 }  // Automatically capture payment after authorization
        };

        var order = client.Order.Create(options);
        return new PaymentOrder
        {
            OrderId = order["id"].ToString(),
            Amount = amount,
            Currency = currency
        };
    }

    // Verify payment signature from Razorpay
    public bool VerifyPaymentSignature(string orderId, string paymentId, string signature)
    {
        var client = new RazorpayClient(_key, _secret);
        var attributes = new Dictionary<string, string>
        {
            { "razorpay_order_id", orderId },
            { "razorpay_payment_id", paymentId },
            { "razorpay_signature", signature }
        };

        try
        {
            Razorpay.Api.Utils.verifyPaymentSignature(attributes);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

public class PaymentOrder
{
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
