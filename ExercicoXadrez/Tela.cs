using System;
using tabuleiro;

namespace ExercicoXadrez
{
    public class Tela
    {
        public static void ImprimirTabuleiro(TabuleiroModel tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.WriteLine(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) != null)
                    {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write( " ");
                    }
                    else
                        Console.Write(" - ");
                }

                Console.WriteLine();
            }
            Console.WriteLine(" a  b  c  d  e  f  g  h");
        }

        public static void ImprimirPeca(PecaModel peca)
        {
            if(peca.Cor == tabuleiro.CorModel.Cor.Branca)
            {
                Console.WriteLine(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(peca);
                Console.ForegroundColor = aux;
            }
        }

    }
}
