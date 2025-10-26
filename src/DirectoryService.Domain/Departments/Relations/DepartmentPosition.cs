namespace DirectoryService.Domain.Departments.Relations;

public class DepartmentPosition
{
    private DepartmentPosition(
        DepartmentPositionId id,
        DepartmentId departmentId,
        PositionId positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public DepartmentPositionId Id { get; private set; }

    public DepartmentId DepartmentId { get; private set; }

    public PositionId PositionId { get; private set; }

    public static Result<DepartmentPosition> Create(DepartmentId departmentId, PositionId positionId)
    {
        if (departmentId.Value  == Guid.Empty || positionId.Value == Guid.Empty)
            return Result.Failure<DepartmentPosition>("Department ID or position ID cannot be empty.");

        var id = DepartmentPositionId.Create();

        var departmentPosition = new DepartmentPosition(id, departmentId, positionId);

        return Result.Success(departmentPosition);
    }

    #region For Ef core
    private DepartmentPosition()
    {
        
    }
    #endregion
}