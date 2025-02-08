using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interface.Service;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartItemController(ICartService cartService)
        {
            this.cartService = cartService;
            
        }
        [HttpDelete("{userId}/{cartItemId}")]
        public async Task<ActionResult<ResponseDto>> DeleteCartItem(int userId,int cartItemId)
        {
            ResponseDto responseDto = new ResponseDto();
            await cartService.RemoveCartItem(userId,cartItemId);
            return Ok(responseDto.success("Item removed successfully"));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> UpdateCartItem([FromBody] UpdateCartItemRequest item)
        {
            ResponseDto responseDto = new ResponseDto();
            await cartService.UpdateCartItem(item.UserId,item.CartItemId,item.Quantity);
            return Ok(responseDto);
        }
    }
}