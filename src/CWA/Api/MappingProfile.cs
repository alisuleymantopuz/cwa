using Api.Models;
using AutoMapper;
using Domain;
using Domain.Pagination;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); 
            CreateMap<Product, ProductDetailDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, TagDetailsDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<ProductsTags, ProductTagsDto>().ReverseMap();
            CreateMap<ProductsTags, TagProductsDto>().ReverseMap();
            CreateMap<ProductsTags, CategorizationDto>().ReverseMap();
            CreateMap<TagParameters, TagsParametersInfo>().ReverseMap();
            CreateMap<ProductParameters, ProductParametersInfo>().ReverseMap();
        }
    }
}
