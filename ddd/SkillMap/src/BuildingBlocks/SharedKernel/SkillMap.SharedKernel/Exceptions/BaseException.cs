
namespace SkillMap.SharedKernel.Exceptions;

public abstract class BaseExeption : Exception
{
    public string Code { get; }
    public string Description { get; }
    public object[] Parameters { get; }

    protected BaseExeption(string code, object[] parameters)
        : base($"code: {code}, parameters: {string.Join(",", parameters)}")
    {
        Code = code;
        Parameters = parameters;
    }

    protected BaseExeption(string code, string description)
        : base($"code: {code}, description: {description}")
    {
        Code = code;
        Description = description;
    }

    protected BaseExeption(string code) : base($"code: {code}")
    {
        Code = code;
    }

    protected BaseExeption() : base()
    {
    }

    protected BaseExeption(string message, Exception innerException) : base(message, innerException)
    {
    }
}
