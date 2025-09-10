namespace text_wars
{
    public class Guerreiro : Personagem // Herda as caracteristicas de personagem
    {
        // Construtor
        public Guerreiro(string nome) : base(nome, 100, 35, ClassePersonagem.Guerreiro)
        {
            // O guerreiro recebe o nome do personagem, mas recebe 120 de vida e 15 de dano.

        }
    }
}