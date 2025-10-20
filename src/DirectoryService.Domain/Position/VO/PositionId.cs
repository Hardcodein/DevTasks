namespace DevTasks.Domain.Position.VO;

public record PositionId
{
    private PositionId(Guid valueId)
    {
        Value = valueId;
    }
    public Guid Value { get; }
    
    public static PositionId Create() => new(Guid.NewGuid());
    public static PositionId Create(Guid id) => new(id);
    
    #region For Ef core
    private PositionId()
    {
        
    }
    #endregion

}