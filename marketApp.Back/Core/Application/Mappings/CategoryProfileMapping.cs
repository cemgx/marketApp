using AutoMapper;
using marketApp.Back.Core.Application.Dto;
using marketApp.Back.Core.Domain;

namespace marketApp.Back.Core.Application.Mappings
{
    public class CategoryProfileMapping : Profile
    {
        public CategoryProfileMapping() 
        { 
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}