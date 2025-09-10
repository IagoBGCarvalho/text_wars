using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_wars;

namespace text_wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Personagem> personagens = new List<Personagem>(); // List gera uma lista dinâmica onde é possível adicionar, remover e iterar. Apenas guarda objetos do tipo Personagem ou derivados dele (mago, guerreiro...)

                Guerreiro p1 = new Guerreiro("Nines");
                personagens.Add(p1); // Adiciona p1 na lista dinâmica

                Mago p2 = new Mago("Olavo");
                personagens.Add(p2);

                foreach (Personagem personagem in personagens)
                {
                    // Loop for que, para cada objeto personagem do tipo Personagem na lista personagens, exibe seu nome, classe, vida e força
                    Console.WriteLine(personagem.Nome + " é da classe " + personagem.Classe + ". " + "Vida: " + personagem.Vida + ", " + "e força: " + personagem.Forca);
                }

                Console.WriteLine("\n");

                p1.atacar(p2);
                p2.atacar(p1);
                

                p2.atacar(p1);
                p1.atacar(p2);
                

                Console.WriteLine(Personagem.ContagemJogadores);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Contagem de jogadores: " + ex.Message);
            }
        }
    }
}