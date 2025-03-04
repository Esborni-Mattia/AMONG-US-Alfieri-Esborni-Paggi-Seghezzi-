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

        public string Descrizione { get; set; }
        public Task? quest { get; set; }


        public Ambiente(string n,string d, Task? t = null)
        {
            nome = n;
            quest = t;
            Descrizione = d;
        }

    }
}
