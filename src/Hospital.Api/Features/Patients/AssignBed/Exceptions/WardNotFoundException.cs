using System.Net;
using Hospital.Api.Shared.Exceptions;

namespace Hospital.Api.Features.Patients.AssignBed.Exceptions;

public class WardNotFoundException(string ward) : ApplicationBaseException($"Nie znaleziono oddziału '{ward}'")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
