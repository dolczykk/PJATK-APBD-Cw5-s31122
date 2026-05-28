using Hospital.Api.Features.Patients.GetAll.DTOs;

namespace Hospital.Api.Features.Patients.GetAll;

public interface IGetPatientsService
{
    Task<IReadOnlyCollection<GetPatientsDto>> HandleAsync(GetPatientsRequest request, CancellationToken cancellationToken);
}
