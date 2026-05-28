using System.Net;
using Hospital.Api.Shared.Exceptions;

namespace Hospital.Api.Features.Patients.Shared.Exceptions;

public class PatientNotFoundException(string pesel) : ApplicationBaseException($"Nie znaleziono pacjenta o numerze PESEL '{pesel}'")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
