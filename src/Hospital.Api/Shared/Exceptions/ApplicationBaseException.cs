using System.Net;

namespace Hospital.Api.Shared.Exceptions;

public abstract class ApplicationBaseException(string message) : Exception(message)
{
    public abstract HttpStatusCode StatusCode { get; }
}