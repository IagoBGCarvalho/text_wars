namespace text_wars
{
    public class Guerreiro : Personagem // Herda as caracteristicas de personagem
    {
        // Métodos:
        public override void atacar(Personagem alvo)
        {
            double dano = this.Forca;

            Console.WriteLine(this.Nome + " ataca " + alvo.Nome + " com " + dano + " de força!" + "\n");

            alvo.ReceberDano(dano);

        }
        // Construtor
        public Guerreiro(string nome) : base(nome, 100, 35, 30, ClassePersonagem.Guerreiro)
        {
            // O guerreiro recebe o nome do personagem, mas recebe 120 de vida e 15 de dano.

        }
    }
}