namespace Application.Common.Exceptions;

public class HttpNotFoundException : HttpBaseException
{
    public HttpNotFoundException(string message) : base(404, message)
    {
    }
}