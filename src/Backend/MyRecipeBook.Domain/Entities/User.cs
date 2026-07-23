namespace MyRecipeBook.Domain.Entities;

public class User //como o sistema enxerga um usuário.
{
    public Guid Id { get; private set; } = Guid.CreateVersion7(); 
    public bool Active { get; set; } = true;//Propriedade que vai "evitar" exclusão permanente no banco de dados,
    //ou seja =>Usuario exclui uma receita(vai passar a valer false) e quer recuperar ela.
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;//UTCNow Vai pegar a data e horario conforme no fuso horario do usuario
    //representação da data e hora q a pessoa se cadastrou na plataforma
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
