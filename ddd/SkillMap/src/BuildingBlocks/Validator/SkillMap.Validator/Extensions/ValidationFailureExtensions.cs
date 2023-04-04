namespace SkillMap.Validator.Extensions;

public static class ValidationFailureExtensions
{
    //TODO: Refactoring
    public static string MapToErrorMessage(this List<ValidationFailure> validationFailures)
    {
        var result = "Errors:";

        validationFailures.ForEach(failure =>
        {
            result += failure.ErrorMessage + string.Empty;
        });

        return result;
    }
}
