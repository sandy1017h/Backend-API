using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using server.Dto;
using server.Interface.Service;
using server.Service;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
 

    // Endpoint to create Razorpay order
    //[HttpPost("create-order")]
    //public IActionResult CreateOrder([FromBody] decimal amount)
    //{
    //    var order = _razorpayService.CreateOrder(amount);
    //    return Ok(new { orderId = order.OrderId, amount = order.Amount, currency = order.Currency });
    //}

    //// Endpoint to verify Razorpay payment
    //[HttpPost("verify-payment")]
    //public IActionResult VerifyPayment([FromBody] PaymentVerificationRequest verificationRequest)
    //{
    //    var isVerified = _razorpayService.VerifyPaymentSignature(
    //        verificationRequest.OrderId,
    //        verificationRequest.PaymentId,
    //        verificationRequest.Signature
    //    );

    //    return isVerified ? Ok("Payment verified successfully") : BadRequest("Payment verification failed");
    //}

    private readonly IRazorpayService _razorpayService;

    public PaymentController(IRazorpayService razorpayService)
    {
        _razorpayService = razorpayService;
    }

    // ✅ Create Razorpay Order
    [HttpPost("create-order")]
    public IActionResult CreateOrder([FromBody] RazorpayPaymentDto paymentDto)
    {
        var order = _razorpayService.CreateRayorPayOrder(paymentDto.Amount, paymentDto.Currency);
        return Ok(order);
    }

    // ✅ Verify Razorpay Payment
    [HttpPost("verify-payment")]
    public IActionResult VerifyPayment([FromBody] PaymentVerificationRequest verificationRequest)
    {
        bool isVerified = _razorpayService.VerifyPaymentSignature(
            verificationRequest.OrderId,
            verificationRequest.PaymentId,
            verificationRequest.Signature
        );

        return isVerified ? Ok("Payment verified successfully") : BadRequest("Payment verification failed");
    }
}

public class PaymentVerificationRequest
{
    public string OrderId { get; set; }
    public string PaymentId { get; set; }
    public string Signature { get; set; }
    public int UserId { get; set; }
}
