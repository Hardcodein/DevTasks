namespace DirectoryService.Domain.Positions.VO;

public record PositionName
{
    private PositionName(string valueName)
    {
        Value = valueName;
    }

    public string Value { get; }

    public static Result<PositionName, Error> Create(string valueName)
    {
        if (valueName.Length < 3 || valueName.Length > 100 || string.IsNullOrWhiteSpace(valueName))
            return GeneralErrors.ValueIsInvalid(nameof(valueName));

        var positionName = new PositionName(valueName);

        return positionName;
    }

    #region For Ef core
    private PositionName()
    {

    }
    #endregion
}