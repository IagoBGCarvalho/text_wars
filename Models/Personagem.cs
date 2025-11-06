using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace text_wars
{
    public class Personagem
    {
        // Classe que representa um personagem de um jogador. Recebe a chave do jogador para se associar a ele e uma da classe para especificar a vida, força e agilidade base.
        [Key]
        public int Id { get; set; }
        [Required] // O nome não pode ser nulo ou branco
        public string Nome { get; set; } = null!;
        public int VidaAtual { get; set; }
        public int VidaMaxima { get; set; }
        public double Forca { get; set; }
        public double Agilidade { get; set; }

        // Relacionamento com Jogador
        [ForeignKey("Jogador")] // Especifica que a propriedade se trata de uma chave estrangeira da tabela Jogador
        public int JogadorId { get; set; }
        public virtual Jogador Jogador { get; set; } = null!; // Propriedade de navegação, uma instância de um personagem está ligada a um jogador

        // Relacionamento com Classe
        [ForeignKey("Classe")]
        public int ClasseId { get; set; }
        public virtual Classe Classe { get; set; } = null!; // Um personagem possui, como molde, uma classe

        [NotMapped] // Esta propriedade é utilizada somente na lógica de jogo, então não precisa ser mapeada pelo EF
        private bool estaDefendendo = false; // Flag para sinalizar se o personagem está em modo de defesa

        public Personagem() { } // Construtor vazio para o EF
        
        // Construtor
        public Personagem(string nome, Jogador jogador, Classe classe)
        {
            // Validação do nome
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome do personagem nao pode ser vazio.", nameof(nome));
            }

            this.Nome = nome;
            this.Jogador = jogador; // Utiliza a propriedade de navegação para associar um personagem ao jogador
            this.Classe = classe; // Associa o personagem à classe

            // Utilizando a classe como molde para os stats:
            this.VidaMaxima = classe.VidaBase;
            this.VidaAtual = classe.VidaBase;
            this.Forca = classe.ForcaBase;
            this.Agilidade = classe.AgilidadeBase;
        }

        // Métodos
        public virtual void atacar(Personagem alvo)
        {
            // Virtual está aplicando um método padrão que PODE ser alterado por outras classes utilizando override
            double dano = this.Forca; // Ele lê a Força que foi pega da Classe
            Console.WriteLine(this.Nome + " ataca " + alvo.Nome + " com " + dano + " de força!" + "\n");
            alvo.ReceberDano(dano);
        }

        public void Defender()
        {
            // Método que ativa o modo de defesa
            Console.WriteLine(this.Nome + " está se defendendo para o proximo ataque.\n");
            this.estaDefendendo = true;
        }

        public void ReceberDano(double danoBruto)
        {
            // Metodo que calcula o dano recebido pelo personagem. Pode ou não diminuir o dano pela metade caso o modo de defesa esteja ativado
            if (this.estaDefendendo)
            {
                Console.WriteLine(this.Nome + " estava defendendo e absorveu metade do dano\n");
                danoBruto /= 2;
                this.estaDefendendo = false;
            }

            // Precisamos ter certeza que o 'set' da VidaAtual lida com valores <= 0
            this.VidaAtual -= (int)danoBruto; 
            if (this.VidaAtual < 0) this.VidaAtual = 0; // Garantia

            if (this.VidaAtual <= 0)
            {
                Console.WriteLine(this.Nome + " foi derrotado." + "\n");
            }
            else
            {
                Console.WriteLine("A vida de " + this.Nome + " agora é " + this.VidaAtual + "\n");
            }
        }

        public void ResetarParaBatalha()
        {
            // Restaura a vida de um personagem derrotado
            this.VidaAtual = this.VidaMaxima;
            this.estaDefendendo = false;
        }
    }
}