using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens
{
    class CMY
    {
        public int C { get; set; }
        public int M { get; set; }
        public int Y { get; set; }
        public CMY(int c, int m, int y)
        {
            C = c;
            M = m;
            Y = y;
        }
    }
}
