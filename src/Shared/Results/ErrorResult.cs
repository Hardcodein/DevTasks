namespace Shared.Results;

public sealed class ErrorResult : IResult
{

    private readonly Errors _errors;

    public ErrorResult(Error error)
    {
        _errors = error.ToErrors();
    }

    public ErrorResult(Errors errors)
    {
        _errors = errors;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        if (!_errors.Any())
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return httpContext.Response.WriteAsJsonAsync(Envelope.Error(_errors));
        }

        var errors = _errors
            .Select(x => x.Type)
            .Distinct();

        var statusCode = errors.Count() > 1
            ? StatusCodes.Status500InternalServerError
            : GetStatusCodeFromErrorType(errors.First());

        var envelope = Envelope.Error(_errors);

        httpContext.Response.StatusCode = statusCode;

        return httpContext.Response.WriteAsJsonAsync(envelope);

    }

    private static int GetStatusCodeFromErrorType(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.UNAUTHORIZED => StatusCodes.Status401Unauthorized,
            ErrorType.FORBIDDEN => StatusCodes.Status403Forbidden,
            ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            ErrorType.FAILURE => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

}
