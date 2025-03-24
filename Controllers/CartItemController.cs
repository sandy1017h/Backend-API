using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interface.Service;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartItemController(ICartService cartService)
        {
            _cartService = cartService;
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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserCart(int userId)
        {
            var result = await _cartService.GetUserCartAsync(userId);
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
    }
}