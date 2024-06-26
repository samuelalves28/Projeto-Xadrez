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
    }
}
