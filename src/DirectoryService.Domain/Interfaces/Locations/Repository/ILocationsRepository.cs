namespace DirectoryService.Domain.Interfaces.Locations.Repository;

public interface ILocationsRepository
{
    Task<Result<Guid, Errors>> CreateAsync(Location location, CancellationToken token = default);
}
