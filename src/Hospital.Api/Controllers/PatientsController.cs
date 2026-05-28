using Hospital.Api.Features.Patients.AssignBed;
using Hospital.Api.Features.Patients.GetAll;
using Hospital.Api.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController(
    IGetPatientsService getPatientsService,
    IAssignBedService assignBedService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponse>> GetPatients([FromQuery] string? search, CancellationToken cancellationToken)
    {
        var result = await getPatientsService.HandleAsync(new GetPatientsRequest(search), cancellationToken);
        return Ok(BaseResponse.Success(result));
    }

    [HttpPost("{pesel}/bedassignments")]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse>> AssignBed(string pesel, [FromBody] AssignBedRequest request, CancellationToken cancellationToken)
    {
        if (!TryValidateModel(request))
        {
            return ValidationProblem(ModelState);
        }

        var result = await assignBedService.HandleAsync(pesel, request, cancellationToken);
        return Created($"/api/patients/{pesel}/bedassignments/{result.Id}", BaseResponse.Success(result));
    }
}
