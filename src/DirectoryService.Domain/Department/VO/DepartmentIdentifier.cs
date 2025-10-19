namespace DevTasks.Domain.Department.VO;

public record DepartmentIdentifier
{
    private DepartmentIdentifier(string valueIdentifier)
    {
        Value = valueIdentifier;
    }
    public string Value { get;}

    public static Result<DepartmentIdentifier> Create(string valueIdentifier)
    {
        if(valueIdentifier.Length < 3 || valueIdentifier.Length > 150 || string.IsNullOrWhiteSpace(valueIdentifier)||!Regex.IsMatch(valueIdentifier, @"^[a-zA-Z]+$"))
            return Result.Failure<DepartmentIdentifier>("No valid value identifier");
        
        var departmentIdentifier = new DepartmentIdentifier(valueIdentifier);
        
        return Result.Success(departmentIdentifier);
    }
    
    #region For Ef core
    private DepartmentIdentifier()
    {
        
    }
    #endregion
}