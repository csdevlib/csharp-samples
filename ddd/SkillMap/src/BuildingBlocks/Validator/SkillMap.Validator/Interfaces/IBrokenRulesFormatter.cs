namespace SkillMap.Validator.Interfaces;

public interface IBrokenRulesFormatter
{
    string Format(IEnumerable<BrokenRule> brokenRules);
}
