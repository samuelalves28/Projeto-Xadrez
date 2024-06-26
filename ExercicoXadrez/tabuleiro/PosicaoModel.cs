namespace tabuleiro
{
    public class PosicaoModel
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public PosicaoModel(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString() => Linha + ", " + Coluna;
    }
}
