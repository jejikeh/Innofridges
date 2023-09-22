namespace Application.Common.Exceptions;

public class HttpBaseException : Exception
{
    public int StatusCode { get; set; }

    public HttpBaseException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}