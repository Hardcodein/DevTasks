using Microsoft.Extensions.Configuration;

namespace DevTasks.Infrastructure;

public class DirectoryServiceDbContext: DbContext
{
    private IConfiguration _configuration;
    public DbSet<Department> Departments => Set<Department>();
    
    public DbSet<Location> Locations => Set<Location>();
    
    public DbSet<Position> Positions => Set<Position>();
    
    public DbSet<DepartmentLocation> DepartmentLocations => Set<DepartmentLocation>();

    public DbSet<DepartmentPosition> DepartmentPositions => Set<DepartmentPosition>();
    
    public DirectoryServiceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("dir_service_db_connect"));
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole()));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }
}