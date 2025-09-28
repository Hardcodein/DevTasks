namespace DevTasks.Domain.Department.VO;

public record DepartmentName
{
    private DepartmentName(string valueName)
    {
        Value = valueName;
    }
    
    public string Value { get;}

    public static Result<DepartmentName> Create(string valueName)
    {
        if(valueName.Length < 3 || valueName.Length > 150 || string.IsNullOrWhiteSpace(valueName))
            return Result.Failure<DepartmentName>("Department name must be between 3 and 150 characters");
        
        var departmentName = new DepartmentName(valueName);
        
        return Result.Success(departmentName);
    }
}