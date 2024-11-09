using AutoMapper;
using marketApp.Back.Core.Application.Dto;
using marketApp.Back.Core.Domain;

namespace marketApp.Back.Core.Application.Mappings
{
    public class ProductProfileMapping : Profile
    {
        public ProductProfileMapping()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
