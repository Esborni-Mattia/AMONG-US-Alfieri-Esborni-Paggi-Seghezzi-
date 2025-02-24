using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class Oggetto
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set
            {
                if(value.Length<3 || value.Length > 20)
                {
                    throw new ArgumentException("lunghezza nome non valida");
                }
                nome = value;
            }
        }

    }
}
