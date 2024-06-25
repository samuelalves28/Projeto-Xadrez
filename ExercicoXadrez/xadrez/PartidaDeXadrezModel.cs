using ExercicoXadrez.tabuleiro;
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
        private int Turno;
        private CorModel.Cor JogadorAtual;
        public bool PartidaTerminada { get; private set; }



        public PartidaDeXadrezModel()
        {
            Tab = new TabuleiroModel(8, 8);
            PartidaTerminada = false;
            Turno = 1;
            JogadorAtual = CorModel.Cor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(PosicaoModel origem, PosicaoModel destino)
        {
            PecaModel p = Tab.RetirarPeca(origem);
            p.IncrimentarQuantidadeMovimento();
            PecaModel pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        private void ColocarPecas()
        {
            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Branca), new PosicaoXadrezModel(1, 'c').ToPosicao());
            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Branca), new PosicaoXadrezModel(2, 'c').ToPosicao());

            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Branca), new PosicaoXadrezModel(2, 'd').ToPosicao());
            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Branca), new PosicaoXadrezModel(2, 'e').ToPosicao());

            Tab.ColocarPeca(new ReiModel(Tab, CorModel.Cor.Branca), new PosicaoXadrezModel(1, 'd').ToPosicao());


            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Preta), new PosicaoXadrezModel(7, 'c').ToPosicao());
            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Preta), new PosicaoXadrezModel(8, 'c').ToPosicao());

            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Preta), new PosicaoXadrezModel(7, 'd').ToPosicao());
            Tab.ColocarPeca(new TorreModel(Tab, CorModel.Cor.Preta), new PosicaoXadrezModel(8, 'e').ToPosicao());

            Tab.ColocarPeca(new ReiModel(Tab, CorModel.Cor.Preta), new PosicaoXadrezModel(8, 'd').ToPosicao());
        }
    }
}
