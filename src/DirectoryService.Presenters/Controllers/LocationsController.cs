namespace DirectoryService.API.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<Envelope<Guid>>(201)]
    [ProducesResponseType<Envelope>(400)]
    [ProducesResponseType<Envelope>(500)]
    [ProducesResponseType<Envelope>(409)]
    [EndpointSummary("Создать локацию")]
    public async Task<EndpointResult<Guid>> CreateLocationAsync(
        [FromBody] CreateLocationRequest request,
        [FromServices] CreateLocationCommandHandler handler,
        CancellationToken token = default)
    {
        return await handler.Handle(new CreateLocationCommand(request), token);
    }
}
