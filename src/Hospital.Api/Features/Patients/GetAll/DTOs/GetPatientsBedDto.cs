namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsBedDto(
    int Id,
    GetPatientsBedTypeDto BedType,
    GetPatientsRoomDto Room);