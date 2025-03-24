using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dto;
using server.Entities;
using server.Interface.Service;

namespace server.Service
{
    public class CartService : ICartService
    {
        private readonly DataContex _context;

        public CartService(DataContex context)
        {
            _context = context;
        }

        public async Task<CartDto> AddToCart(AddToCartDto request)
        {
            var cart = await GetUserCartAsync(request.UserId);
            var product = await _context.products.FindAsync(request.ProductId);

            if (product == null)
                throw new Exception("Product not found");

            var cartItem = await _context.ShopcartItems
                .FirstOrDefaultAsync(item => item.CartId == cart.Id && item.ProductId == request.ProductId);

            if (cartItem != null)
            {
                cartItem.Quantity += request.Quantity;
                cartItem.ModifiedDate = DateTime.UtcNow;
                cartItem.ModifiedBy = request.UserId;
            }
            else
            {
                cartItem = new ShoppingCartItem
                {
                    CartId = cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = request.UserId,
                    ModifiedBy = request.UserId,
                    IsDeleted = false
                };
                _context.ShopcartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return await GetUserCartAsync(request.UserId);
        }

        public async Task<CartDto> UpdateCartItemQuantity(UpdateCartItemDto request)
        {
            var cartItem = await _context.ShopcartItems
                .Include(item => item.Cart)
                .FirstOrDefaultAsync(item => item.Id == request.CartItemId && item.Cart.UserId == request.UserId && !item.IsDeleted);

            if (cartItem == null)
                throw new Exception("Cart item not found");

            if (request.Quantity <= 0)
            {
                await RemoveFromCart(request.CartItemId);
            }
            else
            {
                cartItem.Quantity = request.Quantity;
                cartItem.ModifiedDate = DateTime.UtcNow;
                cartItem.ModifiedBy = request.UserId;
                await _context.SaveChangesAsync();
            }

            return await GetUserCartAsync(request.UserId);
        }

        public async Task<CartDto> RemoveFromCart(int cartItemId)
        {
            var cartItem = await _context.ShopcartItems
                .Include(item => item.Cart)
                .FirstOrDefaultAsync(item => item.Id == cartItemId && !item.IsDeleted);

            if (cartItem == null)
                throw new Exception("Cart item not found");

            cartItem.IsDeleted = true;
            cartItem.ModifiedDate = DateTime.UtcNow;
            cartItem.ModifiedBy = cartItem.Cart.UserId;
            await _context.SaveChangesAsync();

            return await GetUserCartAsync(cartItem.Cart.UserId);
        }

        public async Task<CartDto> GetUserCartAsync(int userId)
        {
            var cart = await _context.Shopcarts
                .Include(c => c.Items)
                    .ThenInclude(item => item.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);

            if (cart == null)
            {
                // Create new cart if it doesn't exist
                cart = new ShoppingCart
                {
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = userId.ToString(),
                    ModifiedBy = userId.ToString(),
                    IsDeleted = false
                };
                _context.Shopcarts.Add(cart);
                await _context.SaveChangesAsync();
            }

            return MapToCartDto(cart);
        }

        public async Task<CartDto> GetCartByIdAsync(int cartId)
        {
            var cart = await _context.Shopcarts
                .Include(c => c.Items)
                    .ThenInclude(item => item.Product)
                .FirstOrDefaultAsync(c => c.Id == cartId && !c.IsDeleted);

            if (cart == null)
                throw new Exception("Cart not found");

            return MapToCartDto(cart);
        }

        public async Task<CartDto> GetCartByUserIdAsync(int userId)
        {
            return await GetUserCartAsync(userId);
        }

        public async Task<decimal> GetCartTotalAsync(int userId)
        {
            var cart = await GetUserCartAsync(userId);
            return cart.TotalAmount;
        }

        public async Task<bool> IsCartEmptyAsync(int userId)
        {
            var cart = await GetUserCartAsync(userId);
            return !cart.Items.Any();
        }

        public async Task<int> GetCartItemCountAsync(int userId)
        {
            var cart = await GetUserCartAsync(userId);
            return cart.Items.Count;
        }

        public async Task<CartDto> ClearCartAsync(int userId)
        {
            var cart = await _context.Shopcarts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);

            if (cart == null)
            {
                throw new Exception("Cart not found");
            }

            // Soft delete all cart items
            foreach (var item in cart.Items)
            {
                item.IsDeleted = true;
                item.ModifiedDate = DateTime.UtcNow;
                item.ModifiedBy = userId;
            }

            // Soft delete the cart
            cart.IsDeleted = true;
            cart.ModifiedDate = DateTime.UtcNow;
            cart.ModifiedBy = userId.ToString();

            await _context.SaveChangesAsync();

            // Return empty cart
            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = new List<CartItemDto>(),
                TotalAmount = 0,
                TotalDiscount = 0,
                OriginalTotal = 0
            };
        }

        private CartDto MapToCartDto(ShoppingCart cart)
        {
            if (cart == null)
                return null;

            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items?.Select(item => new CartItemDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.Product?.Name ?? string.Empty,
                    ProductImage = item.Product?.Thumbnail?.Url ?? string.Empty,
                    Quantity = item.Quantity,
                    Price = item.Product?.NewPrice ?? 0,
                    OriginalPrice = item.Product?.OriginalPrice ?? 0,
                    Subtotal = item.TotalPriceAfterDiscount,
                    TotalDiscount = item.TotalDiscount
                }).ToList() ?? new List<CartItemDto>(),
                TotalAmount = cart.TotalPriceAfterDiscount,
                TotalDiscount = cart.TotalDiscount,
                OriginalTotal = cart.TotalPrice
            };
        }
    }
}