namespace DirectoryService.API.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<Guid> CreateLocationAsync(
        [FromBody] CreateLocationRequest request,
        [FromServices] CreateLocationCommandHandler handler,
        CancellationToken token = default)
    {
        return await handler.Handle(new CreateLocationCommand(request), token);
    }
}
