using AutoMapper;
using Domain.Records.Response.Categories;

namespace Application.Mappings.Categories;

public class CategoriesMapping : Profile
{
    public CategoriesMapping()
    {
        CreateMap<List<string>, CategoriesResponse>()
            .ForMember(opt => opt.categories, src => src.MapFrom(o => o));
    }
}
