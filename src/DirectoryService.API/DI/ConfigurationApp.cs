namespace DirectoryService.API.DI;

public static class ConfigurationApp
{
    public static IApplicationBuilder ConfigureWebApp(this WebApplication application)
    {
        application.AddSwaggerUI();
        application.AddMiddlewares();

        return application;
    }

    private static WebApplication AddMiddlewares(this WebApplication application)
    {
        application.UseExceptionMiddleware();
        application.UseSerilogRequestLogging();
        application.UseRouting();
        application.UseHttpLogging();
        application.MapControllers();

        return application;
    }

    private static WebApplication AddSwaggerUI(this WebApplication application)
    {
        application.UseSwagger();
        application.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "DirectoryService API v1");
        });

        return application;
    }
}
