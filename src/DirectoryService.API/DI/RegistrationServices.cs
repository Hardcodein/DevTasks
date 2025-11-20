namespace DirectoryService.API.DI;

public static class RegistrationServices
{
    public static IServiceCollection AddWebAppDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddWebDependencies();
        services.AddInfrastructureLayer(configuration);
        services.AddApplicationLayer();
        services.AddSeriologLogging(configuration);

        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddOpenApiInfo();
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        return services;
    }

    private static IServiceCollection AddSeriologLogging(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSerilog((sp, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(sp)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("ServiceName", "DirectoryService"));

        return services;
    }

    private static IServiceCollection AddOpenApiInfo(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DirectoryService API",
                Contact = new OpenApiContact
                {
                    Name = "drunk",
                    Email = "mymail.com",
                },
            });
        });

        return services;
    }

}
