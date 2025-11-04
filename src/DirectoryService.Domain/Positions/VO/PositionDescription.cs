namespace DirectoryService.Domain.Positions.VO;

public class PositionDescription
{
    private PositionDescription(string descriptionValue)
    {
        Value = descriptionValue;
    }

    public string? Value { get; }

    public static Result<PositionDescription, Error> Create(string descriptionValue)
    {
        if (string.IsNullOrWhiteSpace(descriptionValue) || descriptionValue.Length <= 1000)
            return GeneralErrors.ValueIsInvalid(nameof(DepartmentLocation));

        var positionDescription = new PositionDescription(descriptionValue);

        return positionDescription;
    }

    #region For Ef core
    private PositionDescription()
    {

    }
    #endregion
}