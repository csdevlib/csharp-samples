namespace MusicStore.Shared.Domain.Bus.Event
{
    public class DomainException : BaseException
    {
        public DomainException(string code) : base(code)
        {
        }

        public DomainException(string code, params object[] parameters) : base(code, parameters)
        {
        }

        public DomainException(string code, string description) : base(code, description)
        {
        }

        protected DomainException() : base()
        {
        }

        protected DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}