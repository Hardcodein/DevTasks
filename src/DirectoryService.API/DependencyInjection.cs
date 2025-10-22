namespace DirectoryService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
         services.AddWebDependencies();

         return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddControllers();

        return services;
    }
}
