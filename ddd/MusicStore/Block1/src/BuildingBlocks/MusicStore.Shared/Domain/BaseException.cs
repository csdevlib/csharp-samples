
namespace MusicStore.Shared.Domain
{
    public abstract class BaseException : Exception
    {
        public string Code { get; }
        public string Description { get; }
        public object[] Parameters { get; }

        protected BaseException(string code, object[] parameters)
            : base($"code: {code}, parameters: {string.Join(",", parameters)}")
        {
            Code = code;
            Parameters = parameters;
        }

        protected BaseException(string code, string description)
            : base($"code: {code}, description: {description}")
        {
            Code = code;
            Description = description;
        }

        protected BaseException(string code) : base($"code: {code}")
        {
            Code = code;
        }

        protected BaseException() : base()
        {
        }

        protected BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}