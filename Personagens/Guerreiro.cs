namespace text_wars
{
    public class Guerreiro : Personagem // Herda as caracteristicas de personagem
    {
        // Métodos:
        public override void atacar(Personagem alvo)
        {
            double dano = this.Forca;

            Console.WriteLine(this.Nome + " ataca " + alvo.Nome + " com " + dano + " de força!" + "\n");

            alvo.Vida -= Convert.ToInt32(dano); // Converte o dano para int e reduz a vida do alvo

            if (alvo.Vida <= 0)
            {
                Console.WriteLine(alvo.Nome + " foi derrotado." + "\n");
            }
            else
            {
                Console.WriteLine("A vida de " + alvo.Nome + " agora é " + alvo.Vida + "\n");
            }
        }
        // Construtor
        public Guerreiro(string nome) : base(nome, 100, 35, ClassePersonagem.Guerreiro)
        {
            // O guerreiro recebe o nome do personagem, mas recebe 120 de vida e 15 de dano.

        }
    }
}