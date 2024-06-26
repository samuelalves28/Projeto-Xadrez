using tabuleiro;

namespace ExercicoXadrez.xadrez
{
    public class PosicaoXadrezModel
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrezModel(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public PosicaoModel ToPosicao() => new PosicaoModel(8 - Linha, Coluna - 'a');

        public override string ToString() => "" + Coluna + Linha;
    }
}
