namespace SkillMap.Validator.Abstractions;

public abstract class AbstractDomainValidator<T> : IAbstractDomainValidator<T> where T : class
{
    protected readonly List<WrapperAbstractValidator<T>> _validators;

    protected readonly List<BrokenRule> _brokenRules;


    protected AbstractDomainValidator()
    {
        _validators = new List<WrapperAbstractValidator<T>>();

        _brokenRules = new List<BrokenRule>();
    }

    public IEnumerable<BrokenRule> BrokenRules => _brokenRules.AsReadOnly();

    public bool IsValid => !BrokenRules.Any();

    public void AddDomainValidators(IEnumerable<WrapperAbstractValidator<T>> validator) =>
               _validators.AddRange(validator);


    public void ValidateRules(T instance)
    {
        _validators.ForEach(v =>
        {
            var validationresult = v.Validate(instance);

            validationresult.Errors.ForEach(error => _brokenRules.Add(new BrokenRule(error.PropertyName,
                                                                                     error.ErrorMessage)));
        });
    }
}
