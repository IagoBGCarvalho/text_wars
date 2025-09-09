namespace text_wars
{
    public class Personagem
    {
        // Atributos
        private string nome = "";
        public int vida { get; set; }
        public double forca { get; set; }
        public static int ContagemJogadores { get; private set; }

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

        // Métodos
        public static void atacar(Personagem personagem1, Personagem personagem2)
        {
            if (personagem1.Forca > personagem2.Forca)
            {
                Console.WriteLine("O personagem 1 venceu!");
            }
            else if (personagem2.Forca > personagem1.forca)
            {
                Console.WriteLine("O personagem 2 venceu!");
            }
            else
            {
                Console.WriteLine("Empatou.");
            }
        }

        // Construtor
        public Personagem(int forca)
        {
            Forca = forca;

            if (forca <= 0)
            {
                throw new ArgumentException("A força do personagem não pode ser menor ou igual a 0.", nameof(forca));
            }
        }
    }
}