﻿using ExercicoXadrez.tabuleiro.exception;
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

                while (!partidaDeXadrezModel.IsPartidaTerminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partidaDeXadrezModel);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        PosicaoModel origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaDeXadrezModel.ValidaPosicaoDeOrigem(origem);

                        bool[,] PosicoesPossiveis = partidaDeXadrezModel.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaDeXadrezModel.Tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        PosicaoModel destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaDeXadrezModel.ValidaPosicaoDeDestino(origem, destino);


                        partidaDeXadrezModel.RealizaJogada(origem, destino);
                    }
                    catch (ExcpetionModel ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.ImprimirPartida(partidaDeXadrezModel);
            }
            catch (ExcpetionModel ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
