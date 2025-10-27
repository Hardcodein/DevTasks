namespace DirectoryService.Application.Locations.Command;

public class CreateLocationCommandValidation : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidation()
    {
        RuleFor(c => c.request)
            .NotNull();

        RuleFor(c => c.request.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is required");

        RuleFor(c => c.request.Address)
            .NotNull().WithMessage("Address is null")
            .SetValidator(new AdrdressDTOValidator());

        RuleFor(c => c.request.TimeZone)
            .NotNull().WithMessage("TimeZone is null ")
            .NotEmpty().WithMessage("TimeZone is required")
            .Must(TimeZoneValidator.BeValidIanaCodeZone).WithMessage("Invalid time zone identifier");
    }
}
