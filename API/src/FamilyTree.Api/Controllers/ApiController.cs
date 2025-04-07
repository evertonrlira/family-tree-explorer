using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FamilyTree.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    private readonly Guid _validClientId;

    public ApiController(IConfiguration configuration)
    {
        var clientId = configuration["ClientId"];
        if (string.IsNullOrEmpty(clientId))
        {
            throw new ArgumentException("Client ID is not configured.");
        }
        _validClientId = Guid.Parse(clientId);
    }

    protected string ExtractClientIdFromHeader()
    {
        if (!Request.Headers.TryGetValue("x-client-id", out Microsoft.Extensions.Primitives.StringValues value))
        {
            return string.Empty;
        }

        return value.ToString();
    }

    protected bool ValidateClientId(string clientId)
    {
        return (Guid.TryParse(clientId, out var clientIdGuid) && clientIdGuid == _validClientId);
    }

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        return Problem(errors[0]);
    }

    protected IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, detail: error.Description);
    }

    protected IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }
}