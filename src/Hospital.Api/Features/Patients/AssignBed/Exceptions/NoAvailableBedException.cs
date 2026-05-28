using System.Net;
using Hospital.Api.Shared.Exceptions;

namespace Hospital.Api.Features.Patients.AssignBed.Exceptions;

public class NoAvailableBedException(string bedType, string ward) : ApplicationBaseException($"Brak dostępnego łóżka typu '{bedType}' na oddziale '{ward}' w wybranym przedziale czasu")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
