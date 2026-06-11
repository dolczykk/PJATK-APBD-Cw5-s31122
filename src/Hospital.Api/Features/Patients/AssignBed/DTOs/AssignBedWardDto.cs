namespace Hospital.Api.Features.Patients.AssignBed.DTOs;

public sealed record AssignBedWardDto(
    int Id,
    string Name,
    string Description);