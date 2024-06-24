using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicoXadrez.tabuleiro.exception
{
    public class ExcpetionModel : Exception
    {

        public ExcpetionModel(string msg) : base(msg)
        {
        }

    }
}
