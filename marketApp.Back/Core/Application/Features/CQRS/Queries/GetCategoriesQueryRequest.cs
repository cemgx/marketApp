using marketApp.Back.Core.Application.Dto;
using MediatR;

namespace marketApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
