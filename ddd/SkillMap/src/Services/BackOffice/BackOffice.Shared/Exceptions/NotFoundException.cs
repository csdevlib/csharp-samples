namespace BackOffice.Shared.Exceptions
{
    public class NotFoundException : BaseExeption
    {
        public NotFoundException(string description) : base(description)
        {
        }
    }
}
