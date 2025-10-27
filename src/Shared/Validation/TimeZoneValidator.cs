namespace Shared.Validation;

public static class TimeZoneValidator
{
    public static bool BeValidIanaCodeZone(string timeZone)
    {
        if (string.IsNullOrWhiteSpace(timeZone))
            return false;

        var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

        return tz is not null;
    }

}
