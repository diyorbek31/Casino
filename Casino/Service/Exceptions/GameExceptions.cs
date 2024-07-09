namespace Casino.Service.Exceptions;

public class GameExceptions : Exception
{
    public int StatusCode {  get; set; }
    public GameExceptions(int statusCode,string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
