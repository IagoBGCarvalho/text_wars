using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace text_wars
{
    public class Classe
    {
        // Classe que representa a tabela que contém as classes que podem ser escolhidas na criação de um personagem
        [Key]
        public int Id { get; set; }
        public string NomeClasse { get; set; } = null!;
        public int VidaBase { get; set; }
        public double ForcaBase { get; set; }
        public double AgilidadeBase { get; set; }

        public virtual ICollection<Personagem> Personagens { get; set; } = new List<Personagem>(); // Propriedade de Navegação, uma Classe pode ser usada por N Personagens
        
        // Construtor para o EF Core:
        public Classe() { } 
    }
}