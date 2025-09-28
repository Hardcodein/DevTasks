namespace DevTasks.Domain.Department.Relations.VO.DepartmentLocation;

public record DepartmentLocationId
{
    private DepartmentLocationId(Guid valueId)
    {
        ValueId = valueId;
    }
    public Guid ValueId { get;}

    public static DepartmentLocationId Create() => new(Guid.NewGuid());
}