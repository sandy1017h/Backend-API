using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using server.Data;
using server.Dto;
using server.Entities;
using server.Interface.Service;
using System.Security.Cryptography;
using System.Text;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContex _context;
        private readonly IRazorpayService _razorpayService;
        private readonly ICartService _cartService;

        public OrderController(
            DataContex context,
            IRazorpayService razorpayService,
            ICartService cartService)
        {
            _context = context;
            _razorpayService = razorpayService;
            _cartService = cartService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDto request)
        {
            // Get user's cart
            var cart = await _cartService.GetUserCartAsync(request.UserId);
            if (cart == null || !cart.Items.Any())
            {
                return BadRequest("Cart is empty");
            }

            // Create Razorpay order
            var razorpayOrder = _razorpayService.CreateRayorPayOrder(cart.TotalAmount, "INR");

            // Create order in database
            var order = new server.Entities.Order
            {
                UserId = request.UserId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cart.TotalAmount,
                Status = OrderStatus.Pending,
                ShippingAddress = request.ShippingAddress,
                RazorpayOrderId = razorpayOrder.OrderId,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = request.UserId.ToString()
            };

            // Add order items
            order.OrderItems = cart.Items.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                Subtotal = item.Subtotal,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = request.UserId.ToString()
            }).ToList();

            // Save order
            // TODO: Add order to database

            return Ok(new
            {
                OrderId = order.Id,
                RazorpayOrderId = razorpayOrder.OrderId,
                Amount = razorpayOrder.Amount,
                Currency = razorpayOrder.Currency
            });
        }

        [HttpPost("verify-payment")]
        public async Task<IActionResult> VerifyPayment([FromBody] PaymentVerificationRequest request)
        {
            var isVerified = _razorpayService.VerifyPaymentSignature(
                request.OrderId,
                request.PaymentId,
                request.Signature
            );

            if (isVerified)
            {
                // TODO: Update order status in database
                // await _orderService.UpdateOrderStatus(request.OrderId, OrderStatus.Paid);

                // Clear user's cart
                await _cartService.ClearCartAsync(request.UserId);

                return Ok("Payment verified successfully");
            }

            return BadRequest("Payment verification failed");
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            // TODO: Implement GetUserOrders method
            return Ok(new List<server.Entities.Order>());
        }
    }
}