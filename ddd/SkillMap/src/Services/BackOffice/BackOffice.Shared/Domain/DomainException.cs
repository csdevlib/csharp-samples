using BackOffice.Shared.Exceptions;

namespace BackOffice.Shared.Domain
{
    public class DomainException : BaseExeption
    {
        public DomainException(string description) : base(description)
        {
        }
    }
}
