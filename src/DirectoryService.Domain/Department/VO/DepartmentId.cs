namespace DevTasks.Domain.Department.VO;

public record DepartmentId
{
    private DepartmentId(Guid valueId)
    {
        Value = valueId;
    }
    public Guid Value { get; }
    
    public static DepartmentId Create() => new(Guid.NewGuid());
}