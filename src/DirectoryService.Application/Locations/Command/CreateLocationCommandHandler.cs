namespace DirectoryService.Application.Locations.Command;

public class CreateLocationCommandHandler
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

    public async Task<Guid> Handle(CreateLocationCommand command, CancellationToken token = default)
    {
        var validationResult = await _validator.ValidateAsync(command, token);

        if (!validationResult.IsValid)
            return Guid.Empty;

        var addedLocation = Location.Create(
            command.request.Name,
            command.request.Address.MailIndex,
            command.request.Address.Country,
            command.request.Address.City,
            command.request.Address.District,
            command.request.Address.Street,
            command.request.Address.NumberofHouse).Value;

        var locationId = await _locationsRepository.CreateAsync(addedLocation, token);

        _logger.LogInformation($"Location by id {locationId} added in system");

        return locationId;
    }
}
