using DirectoryService.Infrastructure.Persistence;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .WriteTo.Debug()
    .MinimumLevel.Information()
    .CreateBootstrapLogger();
try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    var environment = builder.Environment.EnvironmentName;

    builder.Services.AddWebAppDependencies(builder.Configuration);

    var app = builder.Build();

    app.ConfigureWebApp();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}