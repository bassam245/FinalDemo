using AutoMapper;
using FinalDemo.Dto;
using FinalDemo.Models;

namespace FinalDemo.Mapping
{
    public class Maperr : Profile
    {
        public  Maperr()
        {
            CreateMap<LoginDto, User>().ReverseMap()
                
                ;
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<UpdateStockDto, Product>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderStatusDto, Order>().ReverseMap();


        }
    }
}
