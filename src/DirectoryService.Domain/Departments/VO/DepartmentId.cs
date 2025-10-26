namespace DirectoryService.Domain.Departments.VO;

public record DepartmentId
{
    private DepartmentId(Guid valueId)
    {
        Value = valueId;
    }

    public Guid Value { get; }

    public static DepartmentId Create() => new(Guid.NewGuid());
    public static DepartmentId Create(Guid valueId) => new(valueId);

    #region For Ef core
    private DepartmentId()
    {
        
    }
    #endregion
}