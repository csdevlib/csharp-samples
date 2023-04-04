namespace SkillMap.Validator.Interfaces;

public interface IAbstractDomainValidator<T> where T : class
{
    IEnumerable<BrokenRule> BrokenRules { get; }
    bool IsValid { get; }
    void AddDomainValidators(IEnumerable<WrapperAbstractValidator<T>> validator);
    void ValidateRules(T instance);
}
