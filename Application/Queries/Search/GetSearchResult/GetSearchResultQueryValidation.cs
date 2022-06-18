using FluentValidation;

namespace Application.Queries.Search.GetSearchResult;

public class GetSearchResultQueryValidation : AbstractValidator<GetSearchResultQuery>
{
    public GetSearchResultQueryValidation()
    {
        RuleFor(p => p.query)
             .NotEmpty()
             .NotNull()
             .WithMessage("{PropertyName} is required");
    }
}
