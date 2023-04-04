using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Shared.Helpers
{
    public class UuidHelper : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var isValid = Guid.TryParse((string) value, out var result);

            if (isValid) return ValidationResult.Success;

            return new ValidationResult($"The field {value} is not a valid uuid");
        }
    }
}
