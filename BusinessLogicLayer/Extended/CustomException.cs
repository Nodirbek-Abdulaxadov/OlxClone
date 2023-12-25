namespace BusinessLogicLayer.Extended;
public class CustomException(string message)
    : Exception
{
    public string ErrorMessage { get; } = message;
}