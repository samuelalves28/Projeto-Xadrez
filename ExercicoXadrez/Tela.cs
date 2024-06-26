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
                    ImprimirPeca(tab.Peca(i, j));

                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }

        public static void ImprimirTabuleiro(TabuleiroModel tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOrginial = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.Red;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOrginial;

                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOrginial;
                }

                Console.WriteLine();
            }

            Console.WriteLine("   a  b  c  d  e  f  g  h");
            Console.BackgroundColor = fundoOrginial;
        }




        public static PosicaoXadrezModel LerPosicaoXadrez()
        {
            string posicaoLinhaColuna = Console.ReadLine();
            char linha = posicaoLinhaColuna[0];
            int coluna = int.Parse(posicaoLinhaColuna[1] + "");

            return new PosicaoXadrezModel(coluna, linha);
        }

        public static void ImprimirPeca(PecaModel peca)
        {
            if (peca == null)
            {
                Console.Write(" - ");
            }
            else
            {
                if (peca.Cor == tabuleiro.CorModel.Cor.Branca)
                    Console.Write(" " + peca + "");
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" " + peca + "");
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}
