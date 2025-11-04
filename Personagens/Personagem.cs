namespace text_wars
{
    public abstract class Personagem
    {
        // Atributos
        private string nome = "";
        private int vida;
        private double forca;
        private double agilidade;

        public ClassePersonagem Classe { get; private set; } // Propriedade referente a escolha de classe, o set é private pois a classe não pode ser alterada depois de escolhida

        private bool estaDefendendo = false; // Flag para sinalizar se o personagem está em modo de defesa
        public int VidaMaxima { get; private set; }

        // getters e setters
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (value.Length <= 0)
                {
                    return;
                }
                nome = value;
            }
        }

        public double Forca
        {
            get
            {
                return forca;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                forca = value;
            }
        }

        public double Vida
        {
            get
            {
                return vida;
            }
            set
            {
                if (value < 0)
                {
                    vida = 0; // Caso a vida seja menor do que 0, significa que o jogador morreu
                }
                vida = Convert.ToInt32(value);
            }
        }

        public double Agilidade
        {
            get
            {
                return agilidade;

            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                agilidade = value;
            }
        }

        // Métodos
        public virtual void atacar(Personagem alvo)
        {
            // Virtual está aplicando um método padrão que PODE ser alterado por outras classes utilizando override
            double dano = this.Forca;
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

            this.Vida -= danoBruto; // Converte o dano para int e reduz a vida do alvo

            if (this.Vida <= 0)
            {
                Console.WriteLine(this.Nome + " foi derrotado." + "\n");
            }
            else
            {
                Console.WriteLine("A vida de " + this.Nome + " agora é " + this.Vida + "\n");
            }
        }

        public void ResetarParaBatalha()
        {
            /// Restaura a vida de um personagem derrotado
            this.Vida = this.VidaMaxima;
            this.estaDefendendo = false;
        }

        // Construtor
        public Personagem(string nome, int vida, double forca, double agilidade, ClassePersonagem classe)
        {
            // Validação do nome
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome do personagem nao pode ser vazio.", nameof(nome));
            }

            // Validação da vida
            if (vida <= 0)
            {
                throw new ArgumentException("A vida inicial deve ser maior do que zero", nameof(vida));
            }

            // Validacao da força
            if (forca <= 0)
            {
                throw new ArgumentException("A força do personagem não pode ser menor ou igual a 0.", nameof(forca));
            }

            // Validacao da força
            if (agilidade <= 0)
            {
                throw new ArgumentException("A agilidade do personagem não pode ser menor ou igual a 0.", nameof(agilidade));
            }

            this.Nome = nome;
            this.Vida = vida;
            this.VidaMaxima = vida;
            this.Forca = forca;
            this.Agilidade = agilidade;
            this.Classe = classe;

        }
    }

    public enum ClassePersonagem
    {
        // Menu de opções para escolha de classe no construtor do personagem
        Indefinido, // Valor padrão
        Guerreiro,
        Mago
    }
}