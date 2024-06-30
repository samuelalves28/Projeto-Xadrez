using ExercicoXadrez.tabuleiro;
using ExercicoXadrez.tabuleiro.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace ExercicoXadrez.xadrez
{
    public class PartidaDeXadrezModel
    {
        public TabuleiroModel Tab { get; private set; }

        public int Turno { get; private set; }

        public CorModel.Cor JogadorAtual { get; private set; }

        public bool PartidaTerminada { get; private set; }

        private HashSet<PecaModel> Pecas;
        private HashSet<PecaModel> Capturadas;


        public PartidaDeXadrezModel()
        {
            Tab = new TabuleiroModel(8, 8);
            PartidaTerminada = false;
            Turno = 1;
            JogadorAtual = CorModel.Cor.Branca;
            Pecas = new HashSet<PecaModel>();
            Capturadas = new HashSet<PecaModel>();

            ColocarPecas();
        }

        public void RealizaJogada(PosicaoModel origem, PosicaoModel destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidaPosicaoDeOrigem(PosicaoModel posicao)
        {
            if (Tab.Peca(posicao) == null)
                throw new ExcpetionModel("Não existe peça na posição de origem");

            if (JogadorAtual != Tab.Peca(posicao).Cor)
                throw new ExcpetionModel("A peça de origem escolhida não é sua");

            if (!Tab.Peca(posicao).ExiteMovimentoPossivel())
                throw new ExcpetionModel("Não há movimentos possíveis para a peça de origem escolhida.");
        }

        public void ValidaPosicaoDeDestino(PosicaoModel posicaoOrigem, PosicaoModel posicaoDestino)
        {
            if (!Tab.Peca(posicaoOrigem).PodeMoverPara(posicaoDestino))
                throw new ExcpetionModel("Posição de destino inválida");
        }

        private void MudaJogador()
        {
            if (JogadorAtual == CorModel.Cor.Preta)
                JogadorAtual = CorModel.Cor.Branca;
            else
                JogadorAtual = CorModel.Cor.Preta;
        }

        public void ExecutaMovimento(PosicaoModel origem, PosicaoModel destino)
        {
            PecaModel p = Tab.RetirarPeca(origem);
            p.IncrimentarQuantidadeMovimento();
            PecaModel pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
                Capturadas.Add(pecaCapturada);
        }

        public HashSet<PecaModel> PecasCapturadas(CorModel.Cor cor)
        {
            HashSet<PecaModel> aux = new HashSet<PecaModel>();
            foreach (var item in aux)
                if (item.Cor == cor)
                    aux.Add(item);

            return aux;
        }

        public HashSet<PecaModel> PecasEmJogo(CorModel.Cor cor)
        {
            HashSet<PecaModel> aux = new HashSet<PecaModel>();
            foreach (var item in Pecas)
                if (item.Cor == cor)
                    aux.Add(item);

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(int linha, char coluna, PecaModel peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrezModel(linha, coluna).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            #region Peças Brancas

            ColocarNovaPeca(1, 'c', new TorreModel(Tab, CorModel.Cor.Branca));
            ColocarNovaPeca(2, 'c', new TorreModel(Tab, CorModel.Cor.Branca));
            ColocarNovaPeca(2, 'd', new TorreModel(Tab, CorModel.Cor.Branca));
            ColocarNovaPeca(2, 'e', new TorreModel(Tab, CorModel.Cor.Branca));
            ColocarNovaPeca(1, 'd', new TorreModel(Tab, CorModel.Cor.Branca));

            #endregion

            #region Peças Pretas

            ColocarNovaPeca(7, 'c', new TorreModel(Tab, CorModel.Cor.Preta));
            ColocarNovaPeca(8, 'c', new TorreModel(Tab, CorModel.Cor.Preta));
            ColocarNovaPeca(7, 'd', new TorreModel(Tab, CorModel.Cor.Preta));
            ColocarNovaPeca(8, 'e', new TorreModel(Tab, CorModel.Cor.Preta));
            ColocarNovaPeca(8, 'd', new TorreModel(Tab, CorModel.Cor.Branca));

            #endregion
        }
    }
}
