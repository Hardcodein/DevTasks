namespace DevTasks.Domain.Department.Relations.VO.DepartmentPosition;

public record DepartmentPositionId
{
    private DepartmentPositionId(Guid valueId)
    {
        ValueId = valueId;
    }
    public Guid ValueId { get;}

    public static DepartmentPositionId Create() => new(Guid.NewGuid());
}