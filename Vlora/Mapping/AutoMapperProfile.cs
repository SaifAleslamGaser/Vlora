//using AutoMapper;
//using Vlora.Models.Domain;
//using Vlora.Models.DTOs;

//namespace Vlora.Mapping
//{
//    public class AutoMapperProfile : Profile
//    {
//        public AutoMapperProfile()
//        {
//            CreateMap<AddProductRequestDto, Product>();

//            CreateMap<Product, ProductDto>()
//                .ForMember(dest => dest.CategoryName,
//                           opt => opt.MapFrom(src => src.Category.Name));

//            CreateMap<UpdateProductRequestDto, Product>();
//        }
//    }
//}