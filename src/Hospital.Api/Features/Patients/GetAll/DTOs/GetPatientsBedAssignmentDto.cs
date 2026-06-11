namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsBedAssignmentDto(
    int Id,
    DateTime From,
    DateTime? To,
    GetPatientsBedDto Bed);