using FluentValidation.Results;

namespace Domain.Exception;

public class OpenApiValidationException : ApplicationException
{
    public List<string> ValdationErrors { get; set; }

    public OpenApiValidationException(string error)
    {
        ValdationErrors ??= new List<string>();
        ValdationErrors.Add($"validation error :- {error}");
    }
    public OpenApiValidationException(ValidationResult validationResult)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }

    public OpenApiValidationException(List<ValidationFailure> validationFailures)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationFailures)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}
