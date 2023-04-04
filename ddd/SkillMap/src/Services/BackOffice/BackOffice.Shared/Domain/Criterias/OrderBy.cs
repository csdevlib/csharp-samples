using BackOffice.Shared.Domain.ValueObjects;

namespace BackOffice.Shared.Domain.Criterias
{
    public class OrderBy : StringValueObject
    {
        public OrderBy(string value) : base(value)
        {
        }
    }
}
