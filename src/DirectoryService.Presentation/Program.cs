using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DirectoryServiceDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DirectoryServiceDbContext>();

        // Или для миграций:
        context.Database.Migrate();
        
        Console.WriteLine("База данных создана успешно");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка при создании базы данных: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DirectoryService API v1");
    });
}

app.MapControllers();


app.Run();