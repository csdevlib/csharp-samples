namespace SkillMap.SharedKernel.Domain.Criterias;

public class Filters
{
    public List<Filter> Values { get; init; }

    public Filters(List<Filter> filters)
    {
        Values = filters;
    }

    public static Filters? FromValues(List<Dictionary<string, string>> filters)
    {
        if (filters == null) return null;

        return new Filters(filters.Select(Filter.FromValues).ToList());
    }
}
