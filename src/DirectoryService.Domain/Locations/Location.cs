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

    public static Result<Location, Error> Create(
        string locationName,
        string mailIndex,
        string country,
        string city,
        string district,
        string street,
        string numberofHouse,
        string timezone)
    {
        var id = LocationId.Create();

        var nameResult = LocationName.Create(locationName);
        if(nameResult.IsFailure)
            return nameResult.Error;

        var addressResult = LocationAddress.Create(mailIndex, country, city, district, street, numberofHouse);
        if(addressResult.IsFailure)
            return addressResult.Error;

        var timezoneResult = LocationTimeZone.Create(timezone);
        if(timezoneResult.IsFailure)
            return timezoneResult.Error;

        IEnumerable<DepartmentLocation> departments = [];

        var location = new Location(id, nameResult.Value, addressResult.Value, timezoneResult.Value, departments);

        return location;
    }

    #region For Ef core
    private Location()
    {

    }
    #endregion
}