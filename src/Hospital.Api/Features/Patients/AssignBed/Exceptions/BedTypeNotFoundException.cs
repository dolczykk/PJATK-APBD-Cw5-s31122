using System.Net;
using Hospital.Api.Shared.Exceptions;

namespace Hospital.Api.Features.Patients.AssignBed.Exceptions;

public class BedTypeNotFoundException(string bedType)
    : ApplicationBaseException($"Nie znaleziono typu łóżka '{bedType}'")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}