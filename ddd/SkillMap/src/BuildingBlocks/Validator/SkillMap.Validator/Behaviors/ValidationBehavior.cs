namespace SkillMap.Validator.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
        {
            return next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(errors => errors != null)
            .ToLookup(failure => failure.PropertyName)
            .ToDictionary(
                failures => $"{char.ToLowerInvariant(failures.Key[0])}{failures.Key.Substring(1)}",
                failures => failures.Select(failure => new ValidationError
                {
                    Code = failure.ErrorCode,
                    Parameters = failure.FormattedMessagePlaceholderValues?.Select(x => x.Value).ToArray()
                }).ToArray());

        if (errors.Count != 0)
        {
            //TODO: Refactoring
            throw new FluentValidation.ValidationException(errors.ToString());
        }

        return next();
    }
}
