using FamilyTree.Api.Mapping;
using FamilyTree.Application.Queries.GetFamilies;
using FamilyTree.Application.Queries.GetFamilyMembers;
using FamilyTree.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Api.Controllers;

[ApiController]
public class FamilyController(ISender mediator, IConfiguration configuration) : ApiController(configuration)
{
    private readonly ISender _mediator = mediator;

    [HttpGet(ApiEndpoints.Family.GetAll)]
    public async Task<IActionResult> GetAllFamilies([FromQuery] GetAllFamiliesRequest _)
    {
        var clientId = ExtractClientIdFromHeader();
        if (string.IsNullOrEmpty(clientId))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Bad Request: Missing x-client-id header");
        }

        if (!ValidateClientId(clientId))
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                detail: "Unauthorized: Invalid x-client-id header");
        }

        var query = new GetFamiliesQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            data => Ok(data.Select(ContractMapping.MapToResponse)),
            Problem);
    }

    [HttpGet(ApiEndpoints.Family.GetMembers)]
    public async Task<IActionResult> GetMembers([FromQuery] GetFamilyMembersRequest request)
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

        if (request.FamilyId == Guid.Empty)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Bad Request: Missing 'FamilyId' parameter");
        }

        var query = new GetFamilyMembersQuery(request.FamilyId);

        var result = await _mediator.Send(query);

        return result.Match(
            data => Ok(data.Select(ContractMapping.MapToResponse)),
            Problem);
    }
}
