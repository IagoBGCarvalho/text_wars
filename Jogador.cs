namespace text_wars;

public class Jogador
{
    // Classe que representa um Jogador, que pode ter vários personagens

    // Atributos:
    private static int proximoId = 1;
    string login;
    string senha;
    private readonly List<Personagem> personagensJogador = new List<Personagem>();

    // Propriedades:
    public int Id { get;}
    public string Login { get; set; }
    public string Senha { get; }
    public List<Personagem> PersonagensJogador => personagensJogador;
    

    public Jogador(string login, string senha)
    {
        if (string.IsNullOrEmpty(login))
        {
            throw new ArgumentException("O login não pode ser vazio.", nameof(login));
        }

        if (string.IsNullOrEmpty(senha))
        {
            throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));
        }

        this.Login = login;
        this.Senha = senha;
        this.Id = proximoId++;
    }
}
