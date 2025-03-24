using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using server.Dto;
using server.Interface.Service;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace server.Service;
public class RazorpayService: IRazorpayService
{
    private readonly string _keyId;
    private readonly string _keySecret;
    private readonly RazorpayClient _client;

    public RazorpayService(IConfiguration configuration)
    {
        _keyId = configuration["Razorpay:KeyId"];
        _keySecret = configuration["Razorpay:KeySecret"];
        _client = new RazorpayClient(_keyId, _keySecret);
    }

    // Create order in Razorpay
    //public PaymentOrder CreateOrder(decimal amount, string currency = "INR")
    //{
    //    // Convert amount to the smallest currency unit (e.g., paise for INR)
    //    var amountInSubunits = (int)(amount * 100);

    //    var client = new RazorpayClient(_key, _secret);

    //    var options = new Dictionary<string, object>
    //    {
    //        { "amount", amountInSubunits },
    //        { "currency", currency },
    //        { "payment_capture", 1 }  // Automatically capture payment after authorization
    //    };

    //    var order = client.Order.Create(options);
    //    return new PaymentOrder
    //    {
    //        OrderId = order["id"].ToString(),
    //        Amount = amount,
    //        Currency = currency
    //    };
    //}

    // Verify payment signature from Razorpay
    //    public bool VerifyPaymentSignature(string orderId, string paymentId, string signature)
    //    {
    //        var client = new RazorpayClient(_key, _secret);
    //        var attributes = new Dictionary<string, string>
    //        {
    //            { "razorpay_order_id", orderId },
    //            { "razorpay_payment_id", paymentId },
    //            { "razorpay_signature", signature }
    //        };

    //        try
    //        {
    //            Razorpay.Api.Utils.verifyPaymentSignature(attributes);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //}
    public PaymentOrder CreateRayorPayOrder(decimal amount, string currency)
    {
        var options = new Dictionary<string, object>
        {
            { "amount", (int)(amount * 100) }, // Convert to paise
            { "currency", currency },
            { "receipt", $"order_{DateTime.UtcNow.Ticks}" }
        };

        var order = _client.Order.Create(options);
        return new PaymentOrder
        {
            OrderId = order["id"],
            Amount = amount,
            Currency = currency
        };
    }

    public bool VerifyPaymentSignature(string orderId, string paymentId, string signature)
    {
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

    private string GenerateSignature(string payload, string secret)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
        byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

        using (var hmac = new HMACSHA256(keyBytes))
        {
            byte[] hash = hmac.ComputeHash(payloadBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower(); // Convert bytes to lowercase hex string
        }
    }

    public class RazorpayOrder
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}