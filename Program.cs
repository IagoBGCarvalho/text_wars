using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Personagem p1 = new Personagem(0);
                Personagem p2 = new Personagem(20);

                Personagem.atacar(p1, p2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("A batalha teve que ser encerrada pela falta de competidores.");
            }
            
        }
    }
}