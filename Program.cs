using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_wars;

namespace text_wars
{
    internal class Program
    {
        public static List<Jogador> jogadores = new List<Jogador>();
        static void Main(string[] args)
        {
            // Declaração de variáveis
            
            string decisaoTurno = "";
            string decisaoCriacaoJogador = "";
            string decisaoCriacaoPersonagem = "";
            Personagem p1;
            Personagem p2;
            Jogador jogadorSelecionado1;
            Jogador jogadorSelecionado2;

            // Corpo
            try
            {
                while (true)
                {
                    // Criação e seleção do jogador 1:
                    Console.WriteLine("\n(Jogador 1) Deseja (C)RIAR um novo jogador ou (E)NTRAR?:");
                    decisaoCriacaoJogador = (Console.ReadLine() ?? "").ToUpper();

                    if (decisaoCriacaoJogador == "C")
                    {
                        jogadorSelecionado1 = CriarJogador();
                    }
                    else
                    {
                        jogadorSelecionado1 = EscolherJogador();
                    }

                    // Criação e seleção do jogador 2:
                    Console.WriteLine("\n(Jogador 2) Deseja (C)RIAR um novo jogador ou (E)NTRAR?:");
                    decisaoCriacaoJogador = (Console.ReadLine() ?? "").ToUpper();

                    if (decisaoCriacaoJogador == "C")
                    {
                        jogadorSelecionado2 = CriarJogador();
                    }
                    else
                    {
                        jogadorSelecionado2 = EscolherJogador();
                    }

                    Console.Clear(); // Limpa a tela de criação e seleção de jogadores

                    // Criação de personagem do jogador 1:
                    Console.WriteLine("(Jogador 1) Deseja (C)RIAR ou (S)ELECIONAR um personagem?");
                    decisaoCriacaoPersonagem = (Console.ReadLine() ?? "").ToUpper();

                    if (decisaoCriacaoPersonagem == "C")
                    {
                        p1 = CriarPersonagem(jogadorSelecionado1);
                    }
                    else
                    {
                        p1 = SelecionarPersonagem(jogadorSelecionado1);
                        p1.ResetarParaBatalha();
                    }
                    Console.WriteLine($"Você selecionou: {p1.Nome} ({p1.Classe})\n");

                    // Criação de personagem do jogador 2:
                    Console.WriteLine("(Jogador 2) Deseja (C)RIAR ou (S)ELECIONAR um personagem?");
                    decisaoCriacaoPersonagem = (Console.ReadLine() ?? "").ToUpper();

                    if (decisaoCriacaoPersonagem == "C")
                    {
                        p2 = CriarPersonagem(jogadorSelecionado2);
                    }
                    else
                    {
                        p2 = SelecionarPersonagem(jogadorSelecionado2);
                        p2.ResetarParaBatalha();
                    }
                    Console.WriteLine($"Você selecionou: {p2.Nome} ({p2.Classe})\n");

                    Thread.Sleep(2000);
                    Console.Clear();


                    Console.WriteLine("---Apresentação de personagens---\n");

                    Console.WriteLine($"{p1.Nome} ({p1.Classe}) | Vida: {p1.Vida} | Força: {p1.Forca} | Agilidade: {p1.Agilidade}");
                    Console.WriteLine($"{p2.Nome} ({p2.Classe}) | Vida: {p2.Vida} | Força: {p2.Forca} | Agilidade: {p2.Agilidade}");


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
                        decisaoTurno = (Console.ReadLine() ?? "").ToUpper(); // O operador de coalescência evita que a string decisão (que não pode ser nula) receba um valor nulo, retornando uma string vazia caso isso aconteça

                        if (decisaoTurno == "A")
                        {
                            atacanteAtual.atacar(defensorAtual);
                        }
                        else if (decisaoTurno == "D")
                        {
                            atacanteAtual.Defender();
                        }
                        else
                        {
                            Console.WriteLine($"{atacanteAtual.Nome} passou a vez.\n");
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

                    string decisaoLoopJogo = "";

                    while (String.IsNullOrEmpty(decisaoLoopJogo))
                    {
                        Console.WriteLine("\nDeseja jogar mais uma vez? Digite 'S' para SIM e 'N' para NÃO:");
                        decisaoLoopJogo = (Console.ReadLine() ?? "").ToUpper();

                        if (String.IsNullOrEmpty(decisaoLoopJogo))
                        {
                            Console.WriteLine("Digite um valor válido.\n");
                        }
                    }

                    if (decisaoLoopJogo == "N") { break; }
                }

                Console.WriteLine("Obrigado por jogar!!!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static Personagem CriarPersonagem(Jogador jogador)
        {
            /// Função responsável por criar o personagem para o jogador que a chamou
            // Nome:
            string nome = "";
            while (string.IsNullOrEmpty(nome))
            {
                // Loop de validação que não se encerra enquanto usuário não escrever algum caractere para o nome
                Console.WriteLine("Qual será o nome do personagem?");
                nome = Console.ReadLine() ?? "";
                Console.WriteLine();

                if (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("O nome não pode ser vazio. Tente novamente.\n");
                }
            }

            // Classe:
            string classe = "";
            while (classe != "G" && classe != "M")
            {
                Console.WriteLine($"Qual a classe de {nome}? Digite <G> para Guerreiro e <M> para Mago:");
                classe = (Console.ReadLine() ?? "").ToUpper();
                Console.WriteLine();

                if (classe != "G" && classe != "M")
                {
                    Console.WriteLine("Classe inválida. Por favor, digite G ou M.");
                }
            }

            // Instanciação:
            if (classe == "G")
            {
                var novoPersonagem = new Guerreiro(nome);
                jogador.PersonagensJogador.Add(novoPersonagem);
                return novoPersonagem;
            }
            else // Será alterado futuramente com a adição de novas classes
            {
                var novoPersonagem = new Mago(nome);
                jogador.PersonagensJogador.Add(novoPersonagem);
                return novoPersonagem;
            }
        }

        private static Personagem SelecionarPersonagem(Jogador jogador)
        {
            /// Função que seleciona um dos N personagens do jogador
            if (jogador.PersonagensJogador.Count == 0)
            {
                // Se o jogador não tem personagens, força a criação de um
                Console.WriteLine("Você ainda não tem personagens. Vamos criar o primeiro!");
                return CriarPersonagem(jogador);
            }

            Console.WriteLine("Escolha um dos seus personagens:");

            while (true)
            {
                for (int i = 0; i < jogador.PersonagensJogador.Count; i++)
                {
                    // Lista todos os personagens do jogador
                    var p = jogador.PersonagensJogador[i];
                    Console.WriteLine($"<{i + 1}> - {p.Nome} ({p.Classe})");
                }

                Console.WriteLine("Digite o número do personagem:");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int indiceSelecionado)) // Converte o texto para um número
                {
                    int indiceReal = indiceSelecionado - 1; // Converte (1, 2, 3) para (0, 1, 2)

                    if (indiceReal >= 0 && indiceReal < jogador.PersonagensJogador.Count)
                    {
                        return jogador.PersonagensJogador[indiceReal]; // Retorna o personagem criado
                    }
                }
                Console.WriteLine("Seleção inválida. Tente novamente.");
            }
        }

        private static Jogador CriarJogador()
        {
            /// Função que cria um jogador e o adiciona na lista de jogadores
            string login;
            string senha;
            string senha_confirmacao;

            Console.WriteLine($"\n--- Criação de jogador ---\n");

            Console.WriteLine("Digite qual será o seu nome de usuário:");
            login = Console.ReadLine() ?? "";

            while (true)
            {
                Console.WriteLine("Digite a sua senha:");
                senha = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a senha novamente:");
                senha_confirmacao = Console.ReadLine() ?? "";

                if (senha == senha_confirmacao)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Senha repetida incorretamente, tente novamente.\n");
                }
            }

            var novo_jogador = new Jogador(login, senha);
            jogadores.Add(novo_jogador);

            return novo_jogador;
        }
        
        private static Jogador EscolherJogador()
        {
            // Função que faz o login do jogador no sistema
            while (true)
            {
                string loginBuscado = "";
                Jogador? jogadorEncontrado = null;

                // Obter e validar login:
                while (string.IsNullOrEmpty(loginBuscado))
                {
                    Console.WriteLine("Digite o seu login:");
                    loginBuscado = Console.ReadLine() ?? "";

                    if (string.IsNullOrEmpty(loginBuscado))
                    {
                        Console.WriteLine("O login não pode ser vazio. Tente novamente.\n");
                    }
                }

                // Procurar o jogador na lista:
                foreach (var jogador in jogadores)
                {
                    // Procura na lista de jogadores se existe algum objeto jogador com login igual ao fornecido
                    if (jogador.Login == loginBuscado)
                    {
                        jogadorEncontrado = jogador;
                        break;
                    }
                }

                // Verificar se o jogador foi encontrado e realizar a autenticação:
                if (jogadorEncontrado != null)
                {
                    // Caso entre aqui, significa que o login do jogador foi encontrado
                    Console.WriteLine($"Digite a senha para {jogadorEncontrado.Login}:");

                    while (true)
                    {
                        // Loop para autenticação
                        string senhaInserida = Console.ReadLine() ?? "";

                        if (senhaInserida == jogadorEncontrado.Senha)
                        {
                            // Significa que a senha está correta e a autenticação foi concluída com sucesso:
                            Console.WriteLine("Login efetuado com sucesso!");
                            return jogadorEncontrado;
                        }
                        else
                        {
                            Console.WriteLine("Senha incorreta. Tenta novamente.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"O jogador {loginBuscado} não foi encontrado. Tente novamente.");
                    // Como o while true é infinito, só irá parar quando o login for efetuado corretamente.
                }
            }
        }
    }
}