namespace SkillMap.SharedKernel.Domain.Criterias;

public class Criteria
{
    public Filters Filters { get; init; }
    public Order Order { get; init; }
    public int? Limit { get; init; }
    public int? Offset { get; init; }

    public Criteria(Filters filters, Order order, int? limit = null, int? offset = null)
    {
        Filters = filters;
        Order = order;
        Limit = limit;
        Offset = offset;
    }

    public bool HasFilters()
    {
        return Filters != null && Filters.Values.Any();
    }

    public bool HasOrder()
    {
        return Order != null && Order.OrderType != OrderType.NONE && string.IsNullOrEmpty(Order.OrderBy?.Value);
    }
}
