namespace DevTasks.Domain.Department.Relations;

public class DepartmentLocation
{
    private DepartmentLocation(DepartmentLocationId id, Guid departmentId, Guid locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
    }
    public DepartmentLocationId Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }

    public static Result<DepartmentLocation> Create(Guid departmentId, Guid locationId)
    {
        if (departmentId  == Guid.Empty || locationId == Guid.Empty)
            return Result.Failure<DepartmentLocation>("Department ID or location ID cannot be empty.");

        var id = DepartmentLocationId.Create();
        
        var departmentLocation  = new DepartmentLocation(id, departmentId, locationId);
        
        return Result.Success(departmentLocation);
    }
}