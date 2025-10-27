namespace DirectoryService.Domain.Departments;

public class Department
{
    public Department(
        DepartmentId departmentId,
        DepartmentName departmentName,
        DepartmentIdentifier departmentIdentifier,
        Department parentDepartment,
        DepartmentPath departmentPath,
        short depth,
        IEnumerable<DepartmentLocation> locations,
        IEnumerable<DepartmentPosition> positions)
    {
        Id = departmentId;
        Name = departmentName;
        Identifier = departmentIdentifier;
        Parent = parentDepartment;
        Path = departmentPath;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        _locations = locations.ToList();
        _positions = positions.ToList();
    }

    public DepartmentId Id { get; private set; }

    public DepartmentName Name { get; private set; }

    public DepartmentIdentifier Identifier { get; private set; }

    public Department? Parent { get; private set; }

    public DepartmentPath Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<Department> _children = [];

    private List<DepartmentLocation> _locations;

    private List<DepartmentPosition> _positions;

    public IReadOnlyList<Department> Children => _children;

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    public static Result<Department> Create(
        DepartmentName departmentName,
        DepartmentIdentifier departmentIdentifier,
        Department? departmentParent,
        IEnumerable<DepartmentLocation> departmentLocations,
        IEnumerable<DepartmentPosition> departmentPositions)
    {
        var modelId = DepartmentId.Create();
        var modelPath = DepartmentPath.ChangePath(departmentName.Value, departmentParent).Value;

        short depth;

        if (departmentParent != null)
        {
            depth = (short)(departmentParent.Depth + 1);
        }
        else
        {
            depth = 0;
        }

        var department = new Department(
            modelId, 
            departmentName, 
            departmentIdentifier,
            departmentParent!,
            modelPath,
            depth,
            departmentLocations,
            departmentPositions);

        return Result.Success(department);
    }

    #region For Ef core
    private Department()
    {
        
    }
    #endregion
}