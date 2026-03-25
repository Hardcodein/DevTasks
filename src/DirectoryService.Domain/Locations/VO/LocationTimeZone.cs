namespace DirectoryService.Domain.Locations.VO;

public record LocationTimeZone
{
    private LocationTimeZone(string ianaCode)
    {
        Ianacode = ianaCode;
    }

    public string Ianacode { get; }

    public static Result<LocationTimeZone, Error> Create(string ianaCode)
    {
        if (string.IsNullOrWhiteSpace(ianaCode))
            return GeneralErrors.ValueIsInvalid(nameof(LocationTimeZone));

        if(!IsValidIanaCode(ianaCode))
            return GeneralErrors.ValueIsInvalid(nameof(LocationTimeZone));

        return new LocationTimeZone(ianaCode);
    }

    private static bool IsValidIanaCode(string ianaCode)
    {
        try
        {
            TimeZoneInfo.FindSystemTimeZoneById(ianaCode);
            return true;
        }
        catch (TimeZoneNotFoundException)
        {
            return false;
        }
        catch (InvalidTimeZoneException)
        {
            return false;
        }
    }

    #region For Ef core
    private LocationTimeZone()
    {

    }
    #endregion
}