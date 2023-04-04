using BackOffice.Shared.Domain.ValueObjects;

namespace BackOffice.Shared.Domain.Criterias
{
    public class FilterValue : StringValueObject
    {
        public FilterValue(string value) : base(value)
        {
        }
    }
}
