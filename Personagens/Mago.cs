namespace text_wars
{
    public class Mago : Personagem // Herda as caracteristicas de personagem
    {
        // Métodos:
        public override void atacar(Personagem alvo)
        {
            double dano = this.Forca;

            Console.WriteLine(this.Nome + " ataca " + alvo.Nome + " com " + dano + " de força!" + "\n");

            alvo.ReceberDano(dano);
        }
        
        // Construtor
        public Mago(string nome) : base(nome, 80, 20, ClassePersonagem.Mago)
        {
            // O mago recebe o nome do personagem, mas recebe 120 de vida e 15 de dano.

        }
    }
}