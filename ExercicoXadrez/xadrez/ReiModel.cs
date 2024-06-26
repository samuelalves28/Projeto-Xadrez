using ExercicoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace ExercicoXadrez.xadrez
{
    public class ReiModel : PecaModel
    {
        public ReiModel(TabuleiroModel tab, CorModel.Cor cor) : base(tab, cor)
        {
        }

        public override string ToString() => "R";

        private bool PodeMover(PosicaoModel pos)
        {
            PecaModel peca = Tab.Peca(pos);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            PosicaoModel pos = new PosicaoModel(0, 0);

            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            return matriz;
        }
    }
}
