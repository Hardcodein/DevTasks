namespace DevTasks.Domain.Department.VO;

public record DepartmentPath
{
    private DepartmentPath(string pathValue)
    {
        Value = pathValue;
    }

    public string Value { get; }

    public static Result<DepartmentPath> ChangePath(string departmentName, Department? parent)
    {
        if (string.IsNullOrWhiteSpace(departmentName))
            return Result.Failure<DepartmentPath>("Department Name cannot be empty");
        
        string path = parent is not null
            ? $"{departmentName}\\{parent.Name}"
            : $"{departmentName}";

        var departmentPath = new DepartmentPath(path);

        return Result.Success(departmentPath);
    }
    
    #region For Ef core
    private DepartmentPath()
    {
        
    }
    #endregion
}