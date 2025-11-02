namespace Shared;

public record Error
{
    public string Code { get; init; }

    public string Message { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; init; }

    public string? InvalidField { get; init; }

    [JsonConstructor]
    public Error(
        string code,
        string message,
        ErrorType type,
        string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }

    public static Error NOT_FOUND(string message)
        => new(InnerErrorConstants.NOT_FOUND, message, ErrorType.NOT_FOUND);

    public static Error VALIDATION(string message, string? invalidField = null)
        => new(InnerErrorConstants.VALIDATION, message, ErrorType.VALIDATION, invalidField);

    public static Error CONFLICT(string message)
        => new(InnerErrorConstants.CONFLICT, message, ErrorType.CONFLICT);

    public static Error FAILURE(string message)
        => new(InnerErrorConstants.FAILURE, message, ErrorType.FAILURE);

    public static Error UNAUTHORIZED(string message)
        => new(InnerErrorConstants.UNAUTHORIZED, message, ErrorType.UNAUTHORIZED);

    public static Error FORBIDDEN(string message)
        => new(InnerErrorConstants.FORBIDDEN, message, ErrorType.FORBIDDEN);

    public Errors ToErrors() => new([this]);

}

public enum ErrorType
{
    NOT_FOUND = 404,
    VALIDATION = 400,
    CONFLICT = 409,
    FAILURE = 500,
    UNAUTHORIZED = 401,
    FORBIDDEN = 403,
}
