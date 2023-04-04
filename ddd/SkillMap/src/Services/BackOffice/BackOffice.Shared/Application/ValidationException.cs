using BackOffice.Shared.Exceptions;

namespace BackOffice.Shared.Application
{
    public class ValidationException : BaseExeption
    {
        public ValidationException(Dictionary<string, ValidationError[]> errors)
            : base("See the details in the errors array") => Errors = errors;

        public IDictionary<string, ValidationError[]> Errors { get; }
    }
}
