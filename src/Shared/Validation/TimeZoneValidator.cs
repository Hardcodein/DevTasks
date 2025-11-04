using System;

namespace Shared.Validation;

public static class TimeZoneValidator
{
    public static bool BeValidIanaCodeZone(string timeZone)
    {
        try
        {
            var tя = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return timeZone != null;
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

}
