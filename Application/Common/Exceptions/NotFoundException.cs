namespace Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public string Error { get; set; }
    
    public NotFoundException(string message) : base(message)
    {
        Error = message;
    }
}