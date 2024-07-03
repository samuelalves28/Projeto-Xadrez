using ExercicoXadrez.tabuleiro;

namespace tabuleiro
{
    public abstract class PecaModel
    {
        public PosicaoModel Posicao { get; set; }
        public CorModel.Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public TabuleiroModel Tab { get; protected set; }

        public PecaModel(TabuleiroModel tab, CorModel.Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QtdMovimentos = 0;
        }

        public void IncrimentarQuantidadeMovimento() => QtdMovimentos++;
        public void DecrementarQuantidadeMovimento() => QtdMovimentos--;

        public bool ExiteMovimentoPossivel()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
                for (int j = 0; j < Tab.Colunas; j++)
                    if (mat[i, j])
                        return true;

            return false;
        }

        public bool PodePossivel(PosicaoModel posicao) => MovimentosPossiveis()[posicao.Linha, posicao.Coluna];

        public abstract bool[,] MovimentosPossiveis();
    }
}
