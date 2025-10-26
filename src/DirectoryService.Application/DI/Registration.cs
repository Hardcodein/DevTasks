namespace DirectoryService.Application.DI;

public static class Registration
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services
            .AddValidators()
            .AddCommands();
    }

    private static IServiceCollection AddCommands(this IServiceCollection services)
    {
        return services.AddScoped<CreateLocationCommandHandler>();
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssembly(typeof(Registration).Assembly);
    }
}
