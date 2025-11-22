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

    public static Result<DepartmentPosition,Error> Create(DepartmentId departmentId, PositionId positionId)
    {
        if (departmentId.Value == Guid.Empty || positionId.Value == Guid.Empty)
            return GeneralErrors.ValueIsInvalid(nameof(DepartmentLocation));

        var id = DepartmentPositionId.Create();

        var departmentPosition = new DepartmentPosition(id, departmentId, positionId);

        return departmentPosition;
    }

    #region For Ef core
    private DepartmentPosition()
    {

    }
    #endregion
}