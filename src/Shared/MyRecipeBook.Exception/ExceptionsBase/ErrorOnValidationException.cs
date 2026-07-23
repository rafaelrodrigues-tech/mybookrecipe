namespace MyRecipeBook.Exception.ExceptionsBase;

public class ErrorOnValidationException : MyRecipeBookException
{
    private readonly List<string> _errors;//readonly => atribuir valor apenas no construtor
    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }
    public List<string> GetErrorMessages() => _errors;
}
