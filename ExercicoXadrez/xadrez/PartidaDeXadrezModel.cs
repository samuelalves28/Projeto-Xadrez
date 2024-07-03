using ExercicoXadrez.tabuleiro;
using ExercicoXadrez.tabuleiro.exception;
using System.Collections.Generic;
using tabuleiro;
using static ExercicoXadrez.tabuleiro.CorModel;

namespace ExercicoXadrez.xadrez
{
    public class PartidaDeXadrezModel
    {
        #region Campos

        public TabuleiroModel Tab { get; private set; }

        public int Turno { get; private set; }

        public CorModel.Cor JogadorAtual { get; private set; }

        public bool IsPartidaTerminada { get; private set; }

        public bool IsXeque { get; private set; }

        private HashSet<PecaModel> Pecas;

        private HashSet<PecaModel> Capturadas;

        public PecaModel VulneravelEnPassant { get; private set; }

        #endregion

        #region Métodos Públicos

        public PartidaDeXadrezModel()
        {
            Tab = new TabuleiroModel(8, 8);
            IsPartidaTerminada = false;
            IsXeque = false;
            Turno = 1;
            JogadorAtual = CorModel.Cor.Branca;
            VulneravelEnPassant = null;
            Pecas = new HashSet<PecaModel>();
            Capturadas = new HashSet<PecaModel>();

            ColocarPecas();
        }

        public void RealizaJogada(PosicaoModel origem, PosicaoModel destino)
        {
            PecaModel pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new ExcpetionModel("Você não pode se colocar em cheque");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
                IsXeque = true;
            else
                IsXeque = false;

            if (TesteXequeMate(Adversaria(JogadorAtual)))
                IsPartidaTerminada = true;
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        public void DesfazMovimento(PosicaoModel origem, PosicaoModel destino, PecaModel pecaCapturada)
        {
            PecaModel peca = Tab.RetirarPeca(destino);
            peca.DecrementarQuantidadeMovimento();

            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }

            Tab.ColocarPeca(peca, origem);
        }

        public PecaModel ExecutaMovimento(PosicaoModel origem, PosicaoModel destino)
        {
            PecaModel p = Tab.RetirarPeca(origem);
            p.IncrimentarQuantidadeMovimento();

            PecaModel pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if (pecaCapturada != null)
                Capturadas.Add(pecaCapturada);

            return pecaCapturada;
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
            if (!Tab.Peca(posicaoOrigem).PodePossivel(posicaoDestino))
                throw new ExcpetionModel("Posição de destino inválida");
        }

        private void MudaJogador()
        {
            if (JogadorAtual == CorModel.Cor.Preta)
                JogadorAtual = CorModel.Cor.Branca;
            else
                JogadorAtual = CorModel.Cor.Preta;
        }

        public void ColocarNovaPeca(int linha, char coluna, PecaModel peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrezModel(linha, coluna).ToPosicao());
            Pecas.Add(peca);
        }

        public bool EstaEmXeque(CorModel.Cor cor)
        {
            var pecaRei = Rei(cor);

            if (pecaRei == null)
                throw new ExcpetionModel("Não tem rei da cor " + cor + " no tabuleiro");

            foreach (var peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();

                if (mat[pecaRei.Posicao.Linha, pecaRei.Posicao.Coluna])
                    return true;
            }

            return false;
        }

        public bool TesteXequeMate(CorModel.Cor cor)
        {
            if (!IsXeque)
                return false;

            foreach (var peca in PecasEmJogo(cor))
            {
                bool[,] mat = peca.MovimentosPossiveis();

                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            var origem = peca.Posicao;
                            var destino = new PosicaoModel(i, j);
                            PecaModel pecaCaptura = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCaptura);
                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }

            return true;
        }


        #endregion

        #region HashSet 

        public HashSet<PecaModel> PecasCapturadas(CorModel.Cor cor)
        {
            HashSet<PecaModel> aux = new HashSet<PecaModel>();
            foreach (var item in Capturadas)
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

        #endregion

        #region Métodos Privados

        private void ColocarPecas()
        {

            ColocarNovaPeca(1, 'a', new TorreModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'b', new CavaloModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'c', new BispoModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'd', new DamaModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'e', new ReiModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'f', new BispoModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'g', new CavaloModel(Tab, Cor.Branca));
            ColocarNovaPeca(1, 'h', new TorreModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'a', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'b', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'c', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'd', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'e', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'f', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'g', new PeaoModel(Tab, Cor.Branca));
            ColocarNovaPeca(2, 'h', new PeaoModel(Tab, Cor.Branca));

            ColocarNovaPeca(8, 'b', new CavaloModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'c', new BispoModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'd', new DamaModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'e', new ReiModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'f', new BispoModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'g', new CavaloModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'a', new TorreModel(Tab, Cor.Preta));
            ColocarNovaPeca(8, 'h', new TorreModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'a', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'b', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'c', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'd', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'e', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'f', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'g', new PeaoModel(Tab, Cor.Preta));
            ColocarNovaPeca(7, 'h', new PeaoModel(Tab, Cor.Preta));
        }

        private CorModel.Cor Adversaria(CorModel.Cor cor)
        {
            if (cor == CorModel.Cor.Branca)
                return CorModel.Cor.Preta;
            else
                return CorModel.Cor.Branca;
        }

        private PecaModel Rei(CorModel.Cor cor)
        {
            foreach (var peca in PecasEmJogo(cor))
                if (peca is ReiModel)
                    return peca;

            return null;
        }

        #endregion
    }
}
