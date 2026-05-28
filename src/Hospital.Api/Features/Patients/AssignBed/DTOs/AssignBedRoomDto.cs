namespace Hospital.Api.Features.Patients.AssignBed.DTOs;

public sealed record AssignBedRoomDto(
    string Id,
    bool HasTv,
    AssignBedWardDto Ward);
