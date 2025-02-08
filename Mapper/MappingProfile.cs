using AutoMapper;
using server.Dto;
using server.Entities;

namespace server.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Image, ImageDtoRes>();
            CreateMap<CreateProductReq, Product>()
                .ForMember(x => x.Thumbnail, opt => opt.Ignore());
            CreateMap<CreateBrandReq,Brand>()
                .ForMember(x => x.Image, opt => opt.Ignore());
            CreateMap<CreateCategoryReq, Category>()
                .ForMember(x => x.Image, opt => opt.Ignore());
            CreateMap<Category,CategoryResDto>();
            CreateMap<Brand,BrandResDto>();
            CreateMap<Product,ProductResDto>();
            CreateMap<WishlistItem, WishListItemResDto>();

            CreateMap<ShoppingCartItem, ShoppingCartItemResDto>();
            CreateMap<ShoppingCart, ShoppingCartResDto>();
        }
    }
}