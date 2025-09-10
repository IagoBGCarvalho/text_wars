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

                Guerreiro p1 = new Guerreiro("Kratos");
                personagens.Add(p1); // Adiciona p1 na lista dinâmica

                Mago p2 = new Mago("Patolino");
                personagens.Add(p2);

                Console.WriteLine("---Apresentação de personagens---\n");

                foreach (Personagem personagem in personagens)
                {
                    // Loop for que, para cada objeto personagem do tipo Personagem na lista personagens, exibe seu nome, classe, vida e força
                    Console.WriteLine(personagem.Nome + " é da classe " + personagem.Classe + ". " + "Vida: " + personagem.Vida + ", " + "e força: " + personagem.Forca);
                }

                Console.WriteLine("\n");
                Console.WriteLine("---A batalha começou!---\n");

                while (p1.Vida > 0 && p2.Vida > 0)
                {
                    // Game loop da batalha de turnos
                    // Logica:
                    // 1 - Verificar condição de vitória - Enquanto todos os jogadores estiverem vivos
                    // 2 - Turno do jogador 1
                    // 3 - Verificar condição
                    // 4 - Turno do jogador 2
                    // 5 - Verificar condição
                    // 6 - Volta para o passo 1

                    // Turno do jogador 1
                    Console.WriteLine("---Turno de " + p1.Nome + "---");
                    p1.atacar(p2);

                    // Verificacao
                    if (p2.Vida <= 0)
                    {
                        break;
                    }

                    // Turno do jogador 2
                    Console.WriteLine("---Turno de " + p2.Nome + "---");
                    p2.atacar(p1);

                    // Verificacao
                    if (p1.Vida <= 0)
                    {
                        break;
                    }
                }

                // Declaração de vencedor
                Console.WriteLine("---Fim da batalha!---");
                Console.WriteLine("\n");

                if (p1.Vida <= 0)
                {
                    Console.WriteLine(p2.Nome + " venceu!!!");
                }
                else if (p2.Vida <= 0)
                {
                    Console.WriteLine(p2.Nome + " venceu!!!");
                }
                else
                {
                    Console.WriteLine("Empatou");
                }

                Console.WriteLine("Contagem de jogadores: " + Personagem.ContagemJogadores);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}