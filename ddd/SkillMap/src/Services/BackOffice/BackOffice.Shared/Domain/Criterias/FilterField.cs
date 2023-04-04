using BackOffice.Shared.Domain.ValueObjects;

namespace BackOffice.Shared.Domain.Criterias
{
    public class FilterField : StringValueObject
    {
        public FilterField(string value) : base(value)
        {
        }
    }
}
