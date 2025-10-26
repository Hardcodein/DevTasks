namespace DirectoryService.Infrastructure.Persistence.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly DirectoryServiceDbContext _dbContext;

    private readonly ILogger<LocationsRepository> _logger;

    public LocationsRepository(DirectoryServiceDbContext dbContext, ILogger<LocationsRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> CreateAsync(Location location, CancellationToken token = default)
    {
        try
        {
            await _dbContext.Locations.AddAsync(location, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation($"Add new location in DB. Id = {location.Id.Value}");

            return location.Id.Value;
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error adding location entities to the database. {ex.Message}");

            return Guid.Empty;
        }
    }
}
