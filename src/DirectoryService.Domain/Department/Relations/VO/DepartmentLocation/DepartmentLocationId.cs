namespace DirectoryService.Domain.Department.Relations.VO.DepartmentLocation;

public record DepartmentLocationId
{
    private DepartmentLocationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DepartmentLocationId Create() => new(Guid.NewGuid());
    public static DepartmentLocationId Create(Guid id) => new(id);

    #region For Ef core
    private DepartmentLocationId()
    {
        
    }
    #endregion

}