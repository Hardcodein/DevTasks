using Npgsql;

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

    public async Task<Result<Guid, Errors>> CreateAsync(Location location, CancellationToken token = default)
    {
        try
        {
            await _dbContext.Locations.AddAsync(location, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Add new location in DB. Id = {LocationId}", location.Id.Value);

            return location.Id.Value;
        }
        catch(PostgresException ex) when (ex.SqlState == "23505")
        {
            _logger.LogWarning("Duplicate location detected. {Detail}", ex.Detail);

            return GeneralErrors.EntityExists(nameof(Location), ex.ConstraintName ?? "unknown", " ").ToErrors();
        }
        catch (Exception ex)
        {
            _logger.LogWarning("Error adding location entities to the database. {Message}", ex.Message);

            return GeneralErrors.SaveIsFailed(nameof(Location)).ToErrors();
        }
    }
}
