using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordHashing;

namespace MyRecipeBook.Infrastructure.Security.PasswordHashing;
//internal para ter acesso somente na classe de infraestrutura
//selead nenhuma outra classe pode ter herança com essa
internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int DEGREE_OF_PARALLELISM = 1;
    private const int ITERATIONS = 2;
    private const int MEMORY_SIZE = 20 * 1024;//20 MB
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;

    public string HashPassword(string password)//cadastrando a conta de uma pessoa // recebe senha original texto puro
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);//devolve um array de bytes com valores aleatorios
        //randomNumbegenerator> gera numeros aleatorios criptografatos seguros

        var hash = HashPassword(password, salt);

        var combinedBytes = new byte[hash.Length + salt.Length];//concatenação

        salt.CopyTo(combinedBytes);//salt ocupa 0 - 15
        hash.CopyTo(combinedBytes, index: salt.Length); // começa do 16 até 47(soma de 16 + 32 = 48, ultimo valor não entra)

        return Convert.ToBase64String(combinedBytes); // Converte bytes para texto.
    }

    public bool VerifyPassword(string password, string passwordHash) //LOGIN senha pura e senha resultado do hashpassword
    {
        var combinedBytes = Convert.FromBase64String(passwordHash);

        var salt = new byte[SALT_SIZE];
        var hash = new byte[HASH_SIZE];

        //copiando partes
        Array.Copy(combinedBytes, salt, SALT_SIZE);// combinedBytes vai copiar para o salt até salt_size
        Array.Copy(combinedBytes, SALT_SIZE, hash, 0, HASH_SIZE); // combinedBytes vai copiar para o hash, iniciando em SALT_SIZE, na posição 0, até hash_size

        var newHash = HashPassword(password, salt);//hash final para o login. Ela pega a senha digitada e o salt que já estava salvo, e calcula um novo hash.

        return CryptographicOperations.FixedTimeEquals(newHash, salt);//Verificação entre hashs para ver se são compativeis.
    }
    private byte[] HashPassword(string password, byte[] salt)//Permanece somente nessa classe // executa a logica algoritmo
    {

        var passwordBytes = Encoding.UTF8.GetBytes(password);// senha convertida para bytes

        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,//Vai usar somente 1 nucleo,ou seja, vai ser somente um fluxo de execução(desempenho/recursos).
            Iterations = ITERATIONS,//O resultado do algoritmo vai passar n rodadas conforme a quantidade de iterations
            MemorySize = MEMORY_SIZE,//tamanho de memoria q vai ser ocupado.
            Salt = salt//temperar, toda vez q passar a senha, essa senha vai ser "concatenada" com o salt= valores aleatorios
            // esses valores aleatorios vão ser 
        };

        return hashAlgorithm.GetBytes(HASH_SIZE);//hash gerado como array de bytes com o tamanho definido por HASH_SIZE.

    }
}