namespace DirectoryService.Domain.Locations.VO;

public record LocationTimeZone
{
    private LocationTimeZone(string ianaCode)
    {
        Ianacode = ianaCode;
    }

    public string Ianacode { get; }

    public static Result<LocationTimeZone, Error> Create(string country, string city)
    {
        if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city))
            return GeneralErrors.ValueIsInvalid(nameof(LocationTimeZone));

        var ianaCode = $"{country}/{city}";

        var locationTimeZone = new LocationTimeZone(ianaCode);

        return locationTimeZone;
    }

    #region For Ef core
    private LocationTimeZone()
    {

    }
    #endregion
}