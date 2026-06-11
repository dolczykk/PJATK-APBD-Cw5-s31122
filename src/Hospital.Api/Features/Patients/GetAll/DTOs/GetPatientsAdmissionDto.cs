namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsAdmissionDto(
    int Id,
    DateTime AdmissionDate,
    DateTime? DischargeDate,
    GetPatientsWardDto Ward);