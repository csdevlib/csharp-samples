namespace BackOffice.GraphApi.Exceptions
{
    public class CompanyNotFoundException : DomainException
    {
        public CompanyNotFoundException() { }

        public CompanyNotFoundException(string? message) : base(message) { }

        public CompanyNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
