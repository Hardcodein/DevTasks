namespace DirectoryService.Domain.Interfaces.Locations.Repository;

public interface ILocationsRepository
{
    Task<Guid> CreateAsync(Location location, CancellationToken token = default);
}
