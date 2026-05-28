namespace Hospital.Api.Features.Patients.AssignBed.DTOs;

public sealed record AssignBedDto(
    int Id,
    string PatientPesel,
    DateTime From,
    DateTime? To,
    AssignBedBedDto Bed);
