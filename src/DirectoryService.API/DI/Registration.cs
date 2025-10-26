namespace DirectoryService.API.DI;

public static class Registration
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
