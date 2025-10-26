namespace DirectoryService.Contracts.Locations.DTOs.Validators;

public class AdrdressDTOValidator : AbstractValidator<AddressDTO>
{
    public AdrdressDTOValidator()
    {
        RuleFor(a => a.MailIndex)
            .NotNull().WithMessage("MailIndex is null")
            .NotEmpty().WithMessage("MailIndex is required")
            .MaximumLength(20).WithMessage("MailIndex cannot exceed 20 characters");

        RuleFor(a => a.Country)
            .NotNull().WithMessage("Country is null")
            .NotEmpty().WithMessage("Country is required")
            .MaximumLength(50).WithMessage("City cannot exceed 100 characters");

        RuleFor(a => a.City)
            .NotNull().WithMessage("City is null")
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(50).WithMessage("City cannot exceed 100 characters");

        RuleFor(a => a.District)
            .NotNull().WithMessage("District is null")
            .NotEmpty().WithMessage("District is required")
            .MaximumLength(100).WithMessage("District cannot exceed 100 characters");

        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(200).WithMessage("Street cannot exceed 200 characters")
            .Matches(@"^[a-zA-Zа-яА-ЯёЁ0-9\s\.\-#,]+$").WithMessage("Street contains invalid characters");

        RuleFor(a => a.NumberofHouse)
            .NotNull().WithMessage("NumberofHouse is null")
            .NotEmpty().WithMessage("NumberofHouse is required")
            .MaximumLength(10).WithMessage("NumberofHouse cannot exceed 5 characters");
    }
}
