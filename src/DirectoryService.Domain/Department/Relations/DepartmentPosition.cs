namespace DevTasks.Domain.Department.Relations;

public class DepartmentPosition
{
    private DepartmentPosition(DepartmentPositionId id, Guid departmentId, Guid positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }
    public DepartmentPositionId Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid PositionId { get; private set; }

    public static Result<DepartmentPosition> Create(Guid departmentId, Guid positionId)
    {
        if (departmentId  == Guid.Empty || positionId == Guid.Empty)
            return Result.Failure<DepartmentPosition>("Department ID or position ID cannot be empty.");

        var id = DepartmentPositionId.Create();
        
        var departmentPosition  = new DepartmentPosition(id, departmentId, positionId);
        
        return Result.Success(departmentPosition);
    }
}