namespace DirectoryService.Domain.Locations.VO;

public record LocationAddress
{
    private LocationAddress(
        string mailIndex,
        string country,
        string city,
        string district,
        string street,
        string numberofHouse)
    {
        MailIndex = mailIndex;
        Country = country;
        City = city;
        District = district;
        Street = street;
        NumberofHouse = numberofHouse;
    }

    public string MailIndex { get; }
    public string Country { get; }
    public string City { get; }
    public string District { get; }
    public string Street { get; }
    public string NumberofHouse { get; }

    public static Result<LocationAddress> Create(
        string mailIndex,
        string country,
        string city,
        string district,
        string street,
        string numberofHouse)
    {
        if (string.IsNullOrWhiteSpace(mailIndex)
           || string.IsNullOrWhiteSpace(country)
           || string.IsNullOrWhiteSpace(city)
           || string.IsNullOrWhiteSpace(district)
           || string.IsNullOrWhiteSpace(street)
           || string.IsNullOrWhiteSpace(numberofHouse))
            return Result.Failure<LocationAddress>("Invalid address information.");

        var locationAddress = new LocationAddress(mailIndex, country, city, district, street, numberofHouse);

        return Result.Success(locationAddress);
    }
    #region For Ef core
    private LocationAddress()
    {

    }
    #endregion
}