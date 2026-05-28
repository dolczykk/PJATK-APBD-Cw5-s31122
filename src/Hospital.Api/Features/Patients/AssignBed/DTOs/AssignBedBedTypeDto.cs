namespace Hospital.Api.Features.Patients.AssignBed.DTOs;

public sealed record AssignBedBedTypeDto(
    int Id,
    string Name,
    string Description);
