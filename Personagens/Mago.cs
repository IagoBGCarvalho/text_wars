namespace text_wars
{
    public class Mago : Personagem // Herda as caracteristicas de personagem
    {
        // Construtor
        public Mago(string nome) : base(nome, 80, 20, ClassePersonagem.Mago)
        {
            // O mago recebe o nome do personagem, mas recebe 120 de vida e 15 de dano.

        }
    }
}