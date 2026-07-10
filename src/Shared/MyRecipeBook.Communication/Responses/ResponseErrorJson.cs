namespace MyRecipeBook.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> Errors { get; private set; }

    public ResponseErrorJson(List<string> errorMessages) => Errors = errorMessages; //Apenas em versões mais novas > pode fazer dessa maneira apenas se for passar uma linha de código
    public ResponseErrorJson(string errorMessage) => Errors = [errorMessage];

}
