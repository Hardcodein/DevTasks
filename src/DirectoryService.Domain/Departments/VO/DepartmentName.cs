namespace DirectoryService.Domain.Departments.VO;

public record DepartmentName
{
    private DepartmentName(string valueName)
    {
        Value = valueName;
    }

    public string Value { get; }

    public static Result<DepartmentName,Error> Create(string valueName)
    {
        if (valueName.Length < 3 || valueName.Length > 150 || string.IsNullOrWhiteSpace(valueName))
            return GeneralErrors.ValueIsInvalid(nameof(DepartmentName));

        var departmentName = new DepartmentName(valueName);

        return departmentName;
    }

    #region For Ef core
    private DepartmentName()
    {

    }
    #endregion
}