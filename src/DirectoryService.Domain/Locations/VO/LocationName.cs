namespace DirectoryService.Domain.Locations.VO;

public record LocationName
{
    private LocationName(string valueName)
    {
        Value = valueName;
    }

    public string Value { get; }

    public static Result<LocationName, Error> Create(string valueName)
    {
        if (valueName.Length < 3 || valueName.Length > 120 || string.IsNullOrWhiteSpace(valueName))
            return GeneralErrors.ValueIsInvalid(nameof(LocationName));

        var locationName = new LocationName(valueName);

        return locationName;
    }

    #region For Ef core
    private LocationName()
    {

    }
    #endregion
}