namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsWardDto(
    int Id,
    string Name,
    string Description);