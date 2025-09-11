namespace text_wars
{
    public abstract class Personagem
    {
        // Atributos
        private string nome = "";
        private int vida;
        public double forca { get; set; }

        public ClassePersonagem Classe { get; private set; } // Propriedade referente a escolha de classe, o set é private pois a classe não pode ser alterada depois de escolhida
        public static int ContagemJogadores { get; private set; }

        private bool estaDefendendo = false; // Flag para sinalizar se o personagem está em modo de defesa

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
                    return;
                }

                vida = Convert.ToInt32(value);
            }
        }

        // Métodos
        public abstract void atacar(Personagem alvo);

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

            this.Vida -= Convert.ToInt32(danoBruto); // Converte o dano para int e reduz a vida do alvo

            if (this.Vida <= 0)
            {
                Console.WriteLine(this.Nome + " foi derrotado." + "\n");
            }
            else
            {
                Console.WriteLine("A vida de " + this.Nome + " agora é " + this.Vida + "\n");
            }
        }

        // Construtor
        public Personagem(string nome, int vida, double forca, ClassePersonagem classe)
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

            this.Nome = nome;
            this.Vida = vida;
            this.Forca = forca;
            this.Classe = classe;

            ContagemJogadores++;
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