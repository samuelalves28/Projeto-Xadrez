using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
