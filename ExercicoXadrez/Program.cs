using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace ExercicoXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TabuleiroModel tab = new TabuleiroModel(8, 8);

            Tela.ImprimirTabuleiro(tab);
        }
    }
}
