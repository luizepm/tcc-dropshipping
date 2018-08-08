using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcc_criar_db
{
    class Program
    {
        static void Main(string[] args)
        {
            InicializarBd.GeraTabelas(true);
        }
    }
}
