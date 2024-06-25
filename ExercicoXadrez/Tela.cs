using ExercicoXadrez.xadrez;
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
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) != null)
                    {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                    else
                        Console.Write(" - ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }

        public static PosicaoXadrezModel LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char linha = s[0];
            int coluna = int.Parse(s[1] + "");

            return new PosicaoXadrezModel(coluna, linha);

        }

        public static void ImprimirPeca(PecaModel peca)
        {
            if (peca.Cor == tabuleiro.CorModel.Cor.Branca)
            {
                Console.Write(" " + peca + "");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" " + peca + "");
                Console.ForegroundColor = aux;
            }
        }

    }
}
