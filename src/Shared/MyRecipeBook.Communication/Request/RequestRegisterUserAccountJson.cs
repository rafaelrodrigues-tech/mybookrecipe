using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Communication.Request;
////Essa classe define exatamente quais dados a API aceita receber. Depois, esses dados são transformados em uma entidade User, que pertence ao domínio da aplicação.
public class RequestRegisterUserAccountJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

