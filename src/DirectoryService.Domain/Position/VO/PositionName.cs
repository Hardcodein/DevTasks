namespace DevTasks.Domain.Position.VO;

public record PositionName
{
    private PositionName(string valueName)
    {
        Value = valueName;
    }
    
    public string Value { get;}

    public static Result<PositionName> Create(string valueName)
    {
        if(valueName.Length < 3 || valueName.Length > 100 || string.IsNullOrWhiteSpace(valueName))
            return Result.Failure<PositionName>("Location name must be between 3 and 100 characters");
        
        var positionName = new PositionName(valueName);
        
        return Result.Success(positionName);
    }
    
    #region For Ef core
    private PositionName()
    {
        
    }
    #endregion
}