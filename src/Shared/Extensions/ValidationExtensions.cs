using FluentValidation;

namespace Shared.Extensions;

public static class ValidationExtensions
{
    public static Errors ToErrors(this ValidationResult validationResult)
    {
        var errors = validationResult.Errors
            .Select(validationError => Error.VALIDATION(
                validationError.ErrorMessage,
                validationError.PropertyName));

        return errors.ToList();
    }

    public static IRuleBuilderOptions<T, string> MustBeValidIanaTimeZone<T>(
        this IRuleBuilder<T, string> rule)
            => rule.Must(Shared.Validation.TimeZoneValidator.BeValidIanaCodeZone)
                .WithMessage("Invalid IANA timezone");
}
