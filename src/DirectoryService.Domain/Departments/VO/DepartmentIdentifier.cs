namespace DirectoryService.Domain.Departments.VO;

public record DepartmentIdentifier
{
    private DepartmentIdentifier(string valueIdentifier)
    {
        Value = valueIdentifier;
    }

    public string Value { get; }

    public static Result<DepartmentIdentifier, Error> Create(string valueIdentifier)
    {
        if (valueIdentifier.Length < 3 || valueIdentifier.Length > 150 || string.IsNullOrWhiteSpace(valueIdentifier) || !Regex.IsMatch(valueIdentifier, @"^[a-zA-Z]+$"))
            return GeneralErrors.ValueIsInvalid(nameof(DepartmentIdentifier));

        var departmentIdentifier = new DepartmentIdentifier(valueIdentifier);

        return departmentIdentifier;
    }

    #region For Ef core
    private DepartmentIdentifier()
    {

    }
    #endregion
}