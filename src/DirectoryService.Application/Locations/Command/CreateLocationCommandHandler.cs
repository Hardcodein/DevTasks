namespace DirectoryService.Application.Locations.Command;

public class CreateLocationCommandHandler : ICommandHandler<Guid, CreateLocationCommand>
{
    public readonly ILocationsRepository _locationsRepository;

    public readonly IValidator<CreateLocationCommand> _validator;

    public readonly ILogger<CreateLocationCommandHandler> _logger;

    public CreateLocationCommandHandler(
        ILocationsRepository locationsRepository,
        IValidator<CreateLocationCommand> validator,
        ILogger<CreateLocationCommandHandler> logger)
    {
        _locationsRepository = locationsRepository;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result<Guid, Errors>> Handle(CreateLocationCommand command, CancellationToken token = default)
    {
        var validationResult = await _validator.ValidateAsync(command, token);
        if (!validationResult.IsValid)
            return validationResult.ToErrors();

        var locationResult = Location.Create(
            command.request.Name,
            command.request.Address.MailIndex,
            command.request.Address.Country,
            command.request.Address.City,
            command.request.Address.District,
            command.request.Address.Street,
            command.request.Address.NumberofHouse,
            command.request.TimeZone);

        if (locationResult.IsFailure)
            return locationResult.Error.ToErrors();

        var locationId = await _locationsRepository.CreateAsync(locationResult.Value, token);

        _logger.LogInformation("Location by id {LocationId} added in system", locationId.Value);

        return locationId.Value;
    }
}
