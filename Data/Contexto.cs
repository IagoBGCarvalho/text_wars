using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace text_wars;

public class Contexto : DbContext
{
    // Classes a serem persistidas:
    public DbSet<Jogador> Jogador { get; set; } // Tabela de jogadores
    public DbSet<Personagem> Personagens { get; set; } // Tabela de personagens
    public DbSet<Classe> Classes { get; set; } // Tabela de classes

    // Definindo a string de conexão:
    private string _stringDeConexao = "Data source=TextWars.db";

    public string StringDeConexao
    {
        get
        {
            return _stringDeConexao;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configurações das options:
        optionsBuilder.UseSqlite(StringDeConexao); // Definindo o banco sqlite
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações de relacionamento:
        // Relacão Jogador (1) -> Personagem (N)
        modelBuilder.Entity<Jogador>()
            .HasMany(j => j.PersonagensJogador) // Um jogador tem N Personagens
            .WithOne(p => p.Jogador) // Um personagem tem 1 Jogador
            .HasForeignKey(p => p.JogadorId); // A chave em Personagem para o relacionamento é JogadorId 

        // Relação Classe (1) -> Personagem (N)
        modelBuilder.Entity<Classe>()
            .HasMany(c => c.Personagens) // Uma classe tem N Personagens associados a ela
            .WithOne(p => p.Classe) // Cada personagem possui apenas 1 classe
            .HasForeignKey(p => p.ClasseId); // A chave em Personagem para o relacionamento é ClasseId

        // Definindo que cada jogador possui um único login:
        modelBuilder.Entity<Jogador>()
            .HasIndex(j => j.Login)
            .IsUnique();
    }
}