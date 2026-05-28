using Hospital.Api.Dal;
using Hospital.Api.Dal.Entities;
using Hospital.Api.Features.Patients.AssignBed.DTOs;
using Hospital.Api.Features.Patients.AssignBed.Exceptions;
using Hospital.Api.Features.Patients.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Features.Patients.AssignBed;

public sealed class AssignBedService(HospitalDbContext dbContext) : IAssignBedService
{
    private static readonly DateTime SqlDateTimeMax = new(9999, 12, 31, 23, 59, 59, 997);

    public async Task<AssignBedDto> HandleAsync(string pesel, AssignBedRequest request, CancellationToken cancellationToken)
    {
        var patientExists = await dbContext.Patients.AnyAsync(x => x.Pesel == pesel, cancellationToken);
        if (!patientExists)
        {
            throw new PatientNotFoundException(pesel);
        }

        var bedType = await dbContext.BedTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == request.BedType, cancellationToken);
        if (bedType is null)
        {
            throw new BedTypeNotFoundException(request.BedType);
        }

        var ward = await dbContext.Wards
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == request.Ward, cancellationToken);
        
        if (ward is null)
        {
            throw new WardNotFoundException(request.Ward);
        }

        var requestTo = request.To ?? SqlDateTimeMax;

        var bed = await dbContext.Beds
            .Include(x => x.BedAssignments)
            .Include(x => x.BedType)
            .Include(x => x.Room)
            .ThenInclude(x => x.Ward)
            .Where(x => x.BedTypeId == bedType.Id && x.Room.WardId == ward.Id)
            .Where(x => !x.BedAssignments.Any(a => a.From < requestTo && request.From < (a.To ?? SqlDateTimeMax)))
            .OrderBy(x => x.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (bed is null)
        {
            throw new NoAvailableBedException(request.BedType, request.Ward);
        }

        var assignment = new BedAssignment
        {
            PatientPesel = pesel,
            BedId = bed.Id,
            From = request.From,
            To = request.To
        };

        dbContext.BedAssignments.Add(assignment);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new AssignBedDto(
            assignment.Id,
            pesel,
            assignment.From,
            assignment.To,
            new AssignBedBedDto(
                bed.Id,
                new AssignBedBedTypeDto(bed.BedType.Id, bed.BedType.Name, bed.BedType.Description),
                new AssignBedRoomDto(
                    bed.Room.Id,
                    bed.Room.HasTv,
                    new AssignBedWardDto(bed.Room.Ward.Id, bed.Room.Ward.Name, bed.Room.Ward.Description))));
    }
}
