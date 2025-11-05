using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace text_wars;

public class Jogador
{
    // Classe que representa um Jogador, que pode ter vários personagens

    // Propriedades:
    public int Id { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string Senha { get; set; }

    [NotMapped] // Data anottation que impede a propriedade de ser mapeada pelo EF Core, pois a classe Personagem ainda não está pronta
    public List<Personagem> PersonagensJogador { get; set; } = new List<Personagem>();

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