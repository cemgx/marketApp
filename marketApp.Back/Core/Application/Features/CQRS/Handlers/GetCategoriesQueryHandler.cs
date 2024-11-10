using AutoMapper;
using marketApp.Back.Core.Application.Dto;
using marketApp.Back.Core.Application.Features.CQRS.Queries;
using marketApp.Back.Core.Application.Interfaces;
using marketApp.Back.Core.Domain;
using MediatR;

namespace marketApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
