using server.Dto;
using static server.Service.RazorpayService;

namespace server.Interface.Service;

public interface IRazorpayService
{
    PaymentOrder CreateRayorPayOrder(decimal amount, string currency);
    bool VerifyPaymentSignature(string orderId, string paymentId, string signature);

}
