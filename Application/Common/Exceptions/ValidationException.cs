using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationError[] Errors { get; set; }

    public ValidationException(IEnumerable<ValidationFailure> errors)
    {
        Errors = errors.Select(
            x => new ValidationError { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }).ToArray();
    }
}