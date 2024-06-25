using ExercicoXadrez.xadrez;
using System;
using tabuleiro;
using static ExercicoXadrez.tabuleiro.CorModel;

namespace ExercicoXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TabuleiroModel tab = new TabuleiroModel(8, 8);
                tab.ColocarPeca(new ReiModel(tab, Cor.Preta), new PosicaoModel(0, 0));
                tab.ColocarPeca(new ReiModel(tab, Cor.Branca), new PosicaoModel(7, 1));

                Tela.ImprimirTabuleiro(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
