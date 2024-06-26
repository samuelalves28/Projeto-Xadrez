using ExercicoXadrez.tabuleiro;

namespace tabuleiro
{
    public class PecaModel
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
    }
}
