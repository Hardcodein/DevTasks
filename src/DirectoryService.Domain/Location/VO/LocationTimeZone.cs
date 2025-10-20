namespace DevTasks.Domain.Location.VO;

public record LocationTimeZone
{
    private LocationTimeZone(string  ianaCode)
    {
        Ianacode = ianaCode;
    }

    public string Ianacode { get; }

    public static Result<LocationTimeZone> Create(string country,string city)
    {
        if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city))
            return Result.Failure<LocationTimeZone>("Country or City is required in order to create a location timezone");
        
        var ianaCode = $"{country}/{city}";

        var locationTimeZone = new LocationTimeZone(ianaCode);
        
        return Result.Success(locationTimeZone);
    }
    
    #region For Ef core
    private LocationTimeZone()
    {
        
    }
    #endregion
}