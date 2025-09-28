namespace DevTasks.Domain.Location;

public class Location 
{
    public Location(
        LocationId locationId,
        LocationName locationName,
        LocationAddress locationAddress,
        LocationTimeZone locationTimeZone)
    {
        Id = locationId;
        Name = locationName;
        Address = locationAddress;
        Timezone = locationTimeZone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }
    public LocationId Id { get; private set; }
    public LocationName Name { get; private set; }
    public LocationAddress Address { get; private set; }
    public LocationTimeZone? Timezone { get; private set; }
    public bool IsActive { get;  private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

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
        
        var address  = LocationAddress.Create(mailIndex,city,district,street,numberofHouse).Value;

        var timezone = LocationTimeZone.Create(country, city).Value;
        
        var location = new Location(id, name, address, timezone);

        return Result.Success(location);
    }
}