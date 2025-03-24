using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Interface.Service;
using server.Service;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IRazorpayService _razorpayService;

        public CartController(ICartService cartService, IRazorpayService razorpayService)
        {
            _cartService = cartService;
            _razorpayService = razorpayService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserCart(int userId)
        {
            var cart = await _cartService.GetUserCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto request)
        {
            var result = await _cartService.AddToCart(request);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDto request)
        {
            var result = await _cartService.UpdateCartItemQuantity(request);
            return Ok(result);
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            var result = await _cartService.RemoveFromCart(cartItemId);
            return Ok(result);
        }

        [HttpGet("count/{userId}")]
        public async Task<IActionResult> GetCartItemCount(int userId)
        {
            var count = await _cartService.GetCartItemCountAsync(userId);
            return Ok(count);
        }

        [HttpGet("total/{userId}")]
        public async Task<IActionResult> GetCartTotal(int userId)
        {
            var total = await _cartService.GetCartTotalAsync(userId);
            return Ok(total);
        }

        [HttpGet("empty/{userId}")]
        public async Task<IActionResult> IsCartEmpty(int userId)
        {
            var isEmpty = await _cartService.IsCartEmptyAsync(userId);
            return Ok(isEmpty);
        }

        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout(int userId)
        {
            var cart = await _cartService.GetUserCartAsync(userId);
            if (cart == null || !cart.Items.Any())
            {
                return BadRequest("Cart is empty");
            }

            var razorpayOrder = _razorpayService.CreateRayorPayOrder(cart.TotalAmount, "INR");

            return Ok(new
            {
                OrderId = razorpayOrder.OrderId,
                Amount = razorpayOrder.Amount,
                Currency = razorpayOrder.Currency
            });
        }
    }
}
