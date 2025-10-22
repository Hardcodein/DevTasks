namespace DirectoryService.API.Controllers;

[ApiController]
[Route("api/locations")]
public sealed class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<Guid> CreateLocationAsync()
    {
        return  Guid.NewGuid();
    }
}
