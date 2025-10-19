namespace DevTasks.Domain.Location.VO;

public record LocationId
{
    private LocationId(Guid valueId)
    {
        Value = valueId;
    }
    public Guid Value { get; }
    
    public static LocationId Create() => new(Guid.NewGuid());
    public static LocationId Create(Guid id) => new(id);

    #region For Ef core
    private LocationId()
    {
        
    }
    #endregion
}