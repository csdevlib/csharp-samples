namespace SkillMap.SharedKernel.Extensions.EntityFramework;

public static class EFConfigurationExtension
{
    private static readonly Func<char, string> AddUnderscoreBeforeCapitalLetter =
        x => char.IsUpper(x) ? "_" + x : x.ToString(CultureInfo.InvariantCulture);

    public static string ToDatabaseFormat(this string value)
    {
        return string.Concat(value.Select(AddUnderscoreBeforeCapitalLetter)).Substring(1).ToLowerInvariant();
    }
}
