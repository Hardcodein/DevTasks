namespace Shared;

public class GeneralErrors
{
    public static Error ResourceNotFound(string resourceName)
        => Error.NOT_FOUND($"Requested resource '{resourceName}' was not found");

    public static Error InvalidEmail(string fieldName = "email")
        => Error.VALIDATION($"Field '{fieldName}' must be a valid email address");

    public static Error PasswordTooWeak()
        => Error.VALIDATION($"Password does not meet security requirements");

    public static Error EntityExists(string entityName, string field, object value)
        => Error.CONFLICT($"{entityName} with {field}. {value} is exists");

    public static Error InternalServerError(string operation)
        => Error.CONFLICT($"Internal Server Error in {operation}");

    public static Error AuthenticationRequired()
        => Error.UNAUTHORIZED($"Authentication is required to access this resource");

    public static Error AccessDenied()
        => Error.FORBIDDEN($"You don't have permission to perform this action");
}
