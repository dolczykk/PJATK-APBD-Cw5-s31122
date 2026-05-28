namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsBedTypeDto(
    int Id,
    string Name,
    string Description);
