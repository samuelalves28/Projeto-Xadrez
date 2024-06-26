using ExercicoXadrez.xadrez;
using System;
using tabuleiro;

namespace ExercicoXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrezModel partidaDeXadrezModel = new PartidaDeXadrezModel();

                while (!partidaDeXadrezModel.PartidaTerminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrezModel.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    PosicaoModel origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] PosicoesPossiveis = partidaDeXadrezModel.Tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrezModel.Tab, PosicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    PosicaoModel destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partidaDeXadrezModel.ExecutaMovimento(origem, destino);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
