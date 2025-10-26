namespace DirectoryService.Domain.Departments.Relations;

public class DepartmentLocation
{
    private DepartmentLocation(
        DepartmentLocationId id,
        DepartmentId departmentId,
        LocationId locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    public DepartmentLocationId Id { get; private set; }

    public DepartmentId DepartmentId { get; private set; }

    public LocationId LocationId { get; private set; }

    public static Result<DepartmentLocation> Create(DepartmentId departmentId, LocationId locationId)
    {
        if (departmentId.Value  == Guid.Empty || locationId.Value == Guid.Empty)
            return Result.Failure<DepartmentLocation>("Department ID or location ID cannot be empty.");

        var id = DepartmentLocationId.Create();

        var departmentLocation = new DepartmentLocation(id, departmentId, locationId);

        return Result.Success(departmentLocation);
    }

    #region For Ef core
    private DepartmentLocation()
    {
        
    }
    #endregion
}