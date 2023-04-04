using BackOffice.Shared.Exceptions;

namespace BackOffice.Shared.Application
{
    public class ApplicationException : BaseExeption
    {
        public ApplicationException(string description) : base(description)
        {
        }
    }
}
