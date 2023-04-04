namespace SkillMap.Validator.Models;

public class ValidationError
{
    public string Code { get; set; }
    public object[] Parameters { get; set; }
}
