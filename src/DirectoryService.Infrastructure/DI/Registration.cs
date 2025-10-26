namespace DirectoryService.Infrastructure.DI;

public static class Registration
{

    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddRepositories()
            .AddDatabase(configuration);
    }

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(_ => new DirectoryServiceDbContext(configuration));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ILocationsRepository, LocationsRepository>();

        return services;
    }
}
