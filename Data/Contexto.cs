using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace text_wars;

public class Contexto : DbContext
{
    // Classes a serem persistidas:
    public DbSet<Jogador> Jogador { get; set; } // Tabela de jogadores
    public DbSet<Personagem> Classe { get; set; } // Tabela do modelo de classe
    public DbSet<Personagem> Personagem { get; set; } // Tabela da instância de personagens

    // Definindo a string de conexão:
    private string _stringDeConexao = "Data source=TextWars.db";

    public string StringDeConexao
    {
        get
        {
            return _stringDeConexao;
        }
    }

    // Configurações das options:
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Definindo o banco sqlite:
        optionsBuilder.UseSqlite(StringDeConexao);
    }
}