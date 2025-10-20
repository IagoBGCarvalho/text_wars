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
            // Declaração de variáveis
            string decisao = "";

            // Corpo
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
                    Console.WriteLine(personagem.Nome + " é da classe " + personagem.Classe + ". " + "Vida: " + personagem.Vida + ", " + "força: " + personagem.Forca + " e agilidade: " + personagem.Agilidade);
                }

                Console.WriteLine("\n");
                Console.WriteLine("---A batalha começou!---\n");

                Personagem atacanteAtual; // Variáveis que representam o papel de cada jogador no método atacar
                Personagem defensorAtual; 

                if (p1.Agilidade > p2.Agilidade)
                {
                    // Condicionais que, com base na velocidade, determinam qual será o jogador que começará atacando
                    atacanteAtual = p1;
                    defensorAtual = p2;
                    Console.WriteLine("Por ter mais agilidade, " + p1.Nome + " começa.\n");
                }
                else
                {
                    atacanteAtual = p2;
                    defensorAtual = p1;
                    Console.WriteLine("Por ter mais agilidade, " + p2.Nome + " começa.\n");
                }

                while (p1.Vida > 0 && p2.Vida > 0)
                {
                    // Game loop da batalha de turnos
                    // Logica:
                    // 1 - Verificar condição de vitória - Enquanto todos os jogadores estiverem vivos
                    // 2 - Turno do atacante atual
                    // 3 - Verificar condição
                    // 4 - Inversão de papéis (antigo defensor vira o atual atacante)
                    // 5 - Verificar condição
                    // 6 - Volta para o passo 1

                    // Turno do atacante atual:
                    Console.WriteLine("---Turno de " + atacanteAtual.Nome + "---");
                    Console.WriteLine("Digite a ação desejada: (A) - Atacar (D) - Defender (P) - Passar");
                    decisao = (Console.ReadLine() ?? "").ToUpper(); // O operador de coalescência evita que a string decisão (que não pode ser nula) receba um valor nulo, retornando uma string vazia caso isso aconteça

                    if (decisao == "A")
                    {
                        atacanteAtual.atacar(defensorAtual);
                    }
                    else if (decisao == "D")
                    {
                        atacanteAtual.Defender();
                    }
                    else
                    {
                        Console.WriteLine("O jogador " + atacanteAtual.Nome + " passou a vez.\n");
                    }

                    // Verificacão de vitória:
                    if (defensorAtual.Vida <= 0)
                    {
                        break;
                    }

                    // Inversão de papéis(turno do jogador 2):
                    Personagem temp = atacanteAtual;
                    atacanteAtual = defensorAtual;
                    defensorAtual = temp;

                    // No próximo loop, caso o defensor não tenha morrido, receberá o papel de atacante (troca de turno)
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
                    Console.WriteLine(p1.Nome + " venceu!!!");
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