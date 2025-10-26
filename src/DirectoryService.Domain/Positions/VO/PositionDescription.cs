namespace DirectoryService.Domain.Positions.VO;

public class PositionDescription
{
    private PositionDescription(string descriptionValue)
    {
        Value = descriptionValue;
    }

    public string? Value { get; }

    public static Result<PositionDescription> Create(string descriptionValue)
    {
        if (string.IsNullOrWhiteSpace(descriptionValue) || descriptionValue.Length <= 1000)
            return Result.Failure<PositionDescription>($"Description value is invalid");

        var positionDescription = new PositionDescription(descriptionValue);

        return Result.Success(positionDescription);
    }

    #region For Ef core
    private PositionDescription()
    {

    }
    #endregion
}