using Application.Services.Categories.Interface;
using AutoMapper;
using Domain.Records.Response.Categories;
using MediatR;

namespace Application.Queries.Categories.GetCategories;

public record GetCategoriesQuery : IRequest<CategoriesResponse>;



public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, CategoriesResponse>
{
    private readonly ICategoriesService _categoriesService;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ICategoriesService categoriesService, IMapper mapper)
    {
        _categoriesService = categoriesService;
        _mapper = mapper;
    }
    public async Task<CategoriesResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<CategoriesResponse>(await _categoriesService.GetCategoriesAsync());
    }
}
