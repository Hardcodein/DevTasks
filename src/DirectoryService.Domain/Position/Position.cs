namespace DevTasks.Domain.Position;

public class Position
{
    public Position(
        PositionId positionId,
        PositionName positionName,
        PositionDescription positionDescription)
    {
        Id = positionId;
        Name = positionName;
        Description = positionDescription;
        IsActive = true;
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
    public static Result<Position> Create(string positionName, string positionDescription)
    {
        var id = PositionId.Create();
        
        var name = PositionName.Create(positionName).Value;
        
        var description = PositionDescription.Create(positionDescription).Value;
        
        var position = new Position(id, name, description);
        
        return Result.Success(position);
    }
    
    #region For Ef core
    private Position()
    {
        
    }
    #endregion
}