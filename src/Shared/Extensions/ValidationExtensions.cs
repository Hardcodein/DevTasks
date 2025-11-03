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
}
