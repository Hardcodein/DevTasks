namespace DirectoryService.Domain.Positions;

public class Position
{
    public Position(
        PositionId positionId,
        PositionName positionName,
        PositionDescription positionDescription,
        IEnumerable<DepartmentPosition> departments)
    {
        Id = positionId;
        Name = positionName;
        Description = positionDescription;
        IsActive = true;
        _departments = [.. departments];
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public PositionId Id { get; private set; }

    public PositionName Name { get; private set; }

    public PositionDescription Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<DepartmentPosition> _departments;

    public IReadOnlyList<DepartmentPosition> Departments => _departments;

    public static Result<Position> Create(
        string positionName,
        string positionDescription,
        IEnumerable<DepartmentPosition> departments)
    {
        var id = PositionId.Create();

        var name = PositionName.Create(positionName).Value;

        var description = PositionDescription.Create(positionDescription).Value;

        var position = new Position(id, name, description, departments);

        return Result.Success(position);
    }

    #region For Ef core
    private Position()
    {

    }
    #endregion
}