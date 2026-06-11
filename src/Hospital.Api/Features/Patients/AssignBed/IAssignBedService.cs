using Hospital.Api.Features.Patients.AssignBed.DTOs;

namespace Hospital.Api.Features.Patients.AssignBed;

public interface IAssignBedService
{
    Task<AssignBedDto> HandleAsync(string pesel, AssignBedRequest request, CancellationToken cancellationToken);
}