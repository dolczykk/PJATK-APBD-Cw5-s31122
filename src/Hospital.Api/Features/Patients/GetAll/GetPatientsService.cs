using Hospital.Api.Dal;
using Hospital.Api.Features.Patients.GetAll.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Features.Patients.GetAll;

public sealed class GetPatientsService(HospitalDbContext dbContext) : IGetPatientsService
{
    public async Task<IReadOnlyCollection<GetPatientsDto>> HandleAsync(GetPatientsRequest request, CancellationToken cancellationToken)
    {
        var query = dbContext.Patients.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var pattern = $"%{request.Search.Trim()}%";
            query = query.Where(x =>
                EF.Functions.Like(x.FirstName, pattern) ||
                EF.Functions.Like(x.LastName, pattern));
        }

        return await query
            .OrderBy(x => x.Pesel)
            .Select(x => new GetPatientsDto(
                x.Pesel,
                x.FirstName,
                x.LastName,
                x.Age,
                x.Sex ? "Male" : "Female",
                x.Admissions
                    .OrderBy(a => a.Id)
                    .Select(a => new GetPatientsAdmissionDto(
                        a.Id,
                        a.AdmissionDate,
                        a.DischargeDate,
                        new GetPatientsWardDto(a.Ward.Id, a.Ward.Name, a.Ward.Description)))
                    .ToList(),
                x.BedAssignments
                    .OrderBy(a => a.Id)
                    .Select(a => new GetPatientsBedAssignmentDto(
                        a.Id,
                        a.From,
                        a.To,
                        new GetPatientsBedDto(
                            a.Bed.Id,
                            new GetPatientsBedTypeDto(a.Bed.BedType.Id, a.Bed.BedType.Name, a.Bed.BedType.Description),
                            new GetPatientsRoomDto(
                                a.Bed.Room.Id,
                                a.Bed.Room.HasTv,
                                new GetPatientsWardDto(
                                    a.Bed.Room.Ward.Id,
                                    a.Bed.Room.Ward.Name,
                                    a.Bed.Room.Ward.Description)))))
                    .ToList()))
            .ToListAsync(cancellationToken);
    }
}
