using System.Collections.Generic;

namespace text_wars;

public class Jogador
{
    // Classe que representa um Jogador, que pode ter vários personagens

    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public virtual ICollection<Personagem> PersonagensJogador { get; set; } = new List<Personagem>(); // Propriedade de navegação, um personagem pode ter N Personagens

    //Construtor para o Entity:
    public Jogador() { }
    
    // Construtor para a Main:
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
    }
}