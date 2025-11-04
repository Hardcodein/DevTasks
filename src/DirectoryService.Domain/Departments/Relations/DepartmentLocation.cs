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

    public static Result<DepartmentLocation, Error> Create(DepartmentId departmentId, LocationId locationId)
    {
        if (departmentId.Value == Guid.Empty || locationId.Value == Guid.Empty)
            return GeneralErrors.ValueIsInvalid(nameof(DepartmentLocation));

        var id = DepartmentLocationId.Create();

        var departmentLocation = new DepartmentLocation(id, departmentId, locationId);

        return departmentLocation;
    }

    #region For Ef core
    private DepartmentLocation()
    {

    }
    #endregion
}