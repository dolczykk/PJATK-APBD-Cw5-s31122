namespace Hospital.Api.Features.Patients.GetAll.DTOs;

public sealed record GetPatientsRoomDto(
    string Id,
    bool HasTv,
    GetPatientsWardDto Ward);
