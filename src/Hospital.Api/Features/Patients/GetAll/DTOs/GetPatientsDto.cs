namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsDto(
    string Pesel,
    string FirstName,
    string LastName,
    int Age,
    string Sex,
    IReadOnlyCollection<GetPatientsAdmissionDto> Admissions,
    IReadOnlyCollection<GetPatientsBedAssignmentDto> BedAssignments);
