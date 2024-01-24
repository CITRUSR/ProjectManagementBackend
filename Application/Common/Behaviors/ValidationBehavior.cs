using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
{
    private readonly List<IValidator> _validators;

    public ValidationBehavior(List<IValidator> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var errors = _validators.Select(validator => validator.Validate(context))
            .Where(result => !result.IsValid)
            .SelectMany(failures => failures.Errors)
            .ToList();
        
        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}