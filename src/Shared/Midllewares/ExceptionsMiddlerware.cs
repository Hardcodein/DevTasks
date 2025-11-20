namespace Shared.Midllewares;

public class ExceptionsMiddlerware
{
    private readonly RequestDelegate _next;

    public ExceptionsMiddlerware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var envelope = Envelope.Error(GeneralErrors.InternalServerError(ex.Message).ToErrors());

            await context.Response.WriteAsJsonAsync(envelope);
        }
    }

}

public static class ExceptionsMiddlerwareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionsMiddlerware>();
    }
}