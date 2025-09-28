using System.Runtime.CompilerServices;
using DevTasks.Domain.Department.Relations;

namespace DevTasks.Domain.Department;

public class Department
{
    public Department(
        DepartmentId departmentId,
        DepartmentName departmentName,
        DepartmentIdentifier departmentIdentifier,
        DepartmentId? parentDepartmentId,
        DepartmentPath departmentPath,
        short depth,
        List<DepartmentLocation> locations,
        List<DepartmentPosition> positions)
    {
        Id = departmentId;
        Name = departmentName;
        Identifier = departmentIdentifier;
        ParentId = parentDepartmentId;
        Path = departmentPath;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
        _locations = locations;
        _positions = positions;
    }

    public DepartmentId Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public DepartmentIdentifier Identifier { get; private set; }
    public DepartmentId? ParentId { get; private set; }
    public DepartmentPath Path { get; private set; }
    public short Depth { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    private List<Department> _children = [];

    private List<DepartmentLocation> _locations;

    private List<DepartmentPosition> _positions;

    public IReadOnlyList<Department> Children => _children;

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Position => _positions;

    public static Result<Department> Create(
        DepartmentName departmentName,
        DepartmentIdentifier departmentIdentifier,
        Department? departmentParent,
        IEnumerable<Guid> departmentLocationIds,
        IEnumerable<Guid> departmentPositionIds)
    {
        var modelId = DepartmentId.Create();
        var modelPath = DepartmentPath.ChangePath(departmentName.Value, departmentParent).Value;
        
        short depth;

        if (departmentParent != null)
        {
            depth =  (short)(departmentParent.Depth + 1);
        }
        else
        {
            depth = 0;
        }

        var locations = departmentLocationIds.Select(l => DepartmentLocation.
            Create(modelId.Value, l).Value).ToList();
        
        var positions = departmentPositionIds.Select(p => DepartmentPosition.
            Create(modelId.Value, p).Value).ToList();
        
        var department = new Department(
            modelId, 
            departmentName, 
            departmentIdentifier,
            departmentParent?.Id,
            modelPath,
            depth,
            locations,
            positions);
        
        return Result.Success(department);
    }
}