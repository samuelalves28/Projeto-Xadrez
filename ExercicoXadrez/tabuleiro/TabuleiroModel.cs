using ExercicoXadrez.tabuleiro.exception;

namespace tabuleiro
{
    public class TabuleiroModel
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public PecaModel[,] Pecas;


        public TabuleiroModel(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new PecaModel[linhas, colunas];
        }

        public PecaModel Peca(int linha, int coluna) => Pecas[linha, coluna];

        public PecaModel Peca(PosicaoModel pos) => Pecas[pos.Linha, pos.Coluna];

        public PecaModel RetirarPeca(PosicaoModel pos)
        {
            if (Peca(pos) == null)
            {
                return null;
            }

            PecaModel aux = Peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public void ColocarPeca(PecaModel peca, PosicaoModel pos)
        {
            if (ExistePecaNestaPosicao(pos))
                throw new ExcpetionModel("Já existe uma peça nesta posição!");

            Pecas[pos.Linha, pos.Coluna] = peca;
            peca.Posicao = pos;
        }

        public bool ExistePecaNestaPosicao(PosicaoModel pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public bool PosicaoValida(PosicaoModel pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;

            return true;
        }

        public void ValidarPosicao(PosicaoModel pos)
        {
            if (!PosicaoValida(pos))
                throw new ExcpetionModel("Posição inválida");

        }
    }
}
