namespace DirectoryService.Domain.Departments.VO;

public record DepartmentPath
{
    private DepartmentPath(string pathValue)
    {
        Value = pathValue;
    }

    public string Value { get; }

    public static Result<DepartmentPath, Error> ChangePath(string departmentName, Department? parent)
    {
        if (string.IsNullOrWhiteSpace(departmentName))
            return GeneralErrors.ValueIsInvalid(nameof(DepartmentPath));

        string path = parent is not null
            ? $"{departmentName}\\{parent.Name}"
            : $"{departmentName}";

        var departmentPath = new DepartmentPath(path);

        return departmentPath;
    }

    #region For Ef core
    private DepartmentPath()
    {

    }
    #endregion
}