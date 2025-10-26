namespace DirectoryService.Domain.Locations;

public class Location
{
    public Location(
        LocationId locationId,
        LocationName locationName,
        LocationAddress locationAddress,
        LocationTimeZone locationTimeZone,
        IEnumerable<DepartmentLocation> departments)
    {
        Id = locationId;
        Name = locationName;
        Address = locationAddress;
        Timezone = locationTimeZone;
        IsActive = true;
        _departments = [.. departments];
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public LocationId Id { get; private set; }

    public LocationName Name { get; private set; }

    public LocationAddress Address { get; private set; }

    public LocationTimeZone? Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<DepartmentLocation> _departments;

    public IReadOnlyList<DepartmentLocation> Departments => _departments;

    public static Result<Location> Create(
        string locationName,
        string mailIndex,
        string country,
        string city,
        string district,
        string street,
        string numberofHouse)
    {
        var id = LocationId.Create();

        var name = LocationName.Create(locationName).Value;

        var address = LocationAddress.Create(mailIndex, country, city, district, street, numberofHouse).Value;

        var timezone = LocationTimeZone.Create(country, city).Value;

        IEnumerable<DepartmentLocation> departments = new List<DepartmentLocation>();

        var location = new Location(id, name, address, timezone, departments);

        return Result.Success(location);
    }

    #region For Ef core
    private Location()
    {

    }
    #endregion
}