using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Api.Controllers;

[ApiController]
public class HealthController(IConfiguration configuration) : ApiController(configuration)
{
    [HttpGet(ApiEndpoints.Health.Get)]
    public IActionResult Healthy()
    {
        var clientId = ExtractClientIdFromHeader();
        if (string.IsNullOrEmpty(clientId))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Bad Request: Missing 'x-client-id' header");
        }

        if (!ValidateClientId(clientId))
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                detail: "Unauthorized: Invalid 'x-client-id' header");
        }

        return Ok("Healthy");
    }
}
