using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class Ambiente
    {
        public string nome { get; set; }
        public Task quest { get; set; }
        public bool botola { get; set; }


        public Ambiente(string n, Task q, bool b)
        {
            nome = n;
            quest = q;
            botola = b;
        }

    }
}
