namespace Hospital.Api.Features.Patients.AssignBed.DTOs;

public sealed record AssignBedBedDto(
    int Id,
    AssignBedBedTypeDto BedType,
    AssignBedRoomDto Room);