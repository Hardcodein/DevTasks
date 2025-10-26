namespace DirectoryService.Domain.Locations.VO;

public record LocationName
{
    private LocationName(string valueName)
    {
        Value = valueName;
    }

    public string Value { get; }

    public static Result<LocationName> Create(string valueName)
    {
        if(valueName.Length < 3 || valueName.Length > 120 || string.IsNullOrWhiteSpace(valueName))
            return Result.Failure<LocationName>("Location name must be between 3 and 120 characters");

        var locationName = new LocationName(valueName);

        return Result.Success(locationName);
    }

    #region For Ef core
    private LocationName()
    {
        
    }
    #endregion
}