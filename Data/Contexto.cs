using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace text_wars;

public class Contexto : DbContext
{
    // Classes a serem persistidas:
    public DbSet<Jogador> Jogador { get; set; } // Tabela de jogadores
    public DbSet<Personagem> Personagem { get; set; } // Tabela de personagens
    public DbSet<Classe> Classe { get; set; } // Tabela de classes

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
        // CONFIGURAÇÕES DE RELACIONAMENTOS:
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
        
        // CONFIGURAÇÃO ESTRUTURAL DA TABELA JOGADOR:
        modelBuilder.Entity<Jogador>(entity =>
        {
            entity.ToTable("Jogador");

            entity.HasKey(j => j.Id);

            entity.Property(j => j.Login)
                  .HasColumnType("varchar(20)")
                  .IsRequired();
            
            entity.Property(j => j.Senha)
                  .HasColumnType("varchar(40)")
                  .IsRequired();

            entity.HasIndex(j => j.Login)
                  .IsUnique(); // Cada jogador possui um login único
        });

        // CONFIGURAÇÃO ESTRUTURAL DA TABELA CLASSE:
        modelBuilder.Entity<Classe>(entity =>
        {
            entity.ToTable("Classe");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.NomeClasse)
                  .HasColumnType("varchar(30)") // Definindo o tipo da coluna
                  .IsRequired(); // Definindo a coluna como NOT NULL

            entity.HasIndex(c => c.NomeClasse)
                  .IsUnique(); // Cada classe deve ter um único nome
        });

        // CONFIGURAÇÃO ESTRUTURAL DA TABELA PERSONAGEM:
        modelBuilder.Entity<Personagem>(entity =>
        {
            entity.ToTable("Personagem");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                  .HasColumnType("varchar(20)")
                  .IsRequired();
        });
        
        // DATA SEEDING PARA CLASSES:
        modelBuilder.Entity<Classe>().HasData(
            new Classe 
            { 
                Id = 1, // É NECESSÁRIO ESPECIFICAR A PK DE CADA DATA SEEDING!
                NomeClasse = "Guerreiro", 
                VidaBase = 100, 
                ForcaBase = 35, 
                AgilidadeBase = 30 
            },

            new Classe 
            { 
                Id = 2, 
                NomeClasse = "Mago", 
                VidaBase = 80, 
                ForcaBase = 20, 
                AgilidadeBase = 50 
            }
        );
    }
}