namespace DirectoryService.Domain.Departments.Relations.VO.DepartmentPosition;

public record DepartmentPositionId
{
    private DepartmentPositionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DepartmentPositionId Create() => new(Guid.NewGuid());
    public static DepartmentPositionId Create(Guid id) => new(id);

    #region For Ef core
    private DepartmentPositionId()
    {
        
    }
    #endregion
}