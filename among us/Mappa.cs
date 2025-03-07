using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public abstract class Mappa
    {
        public List<Personaggio> GiocatoriPresenti = new List<Personaggio>();
        public bool Botole {  get; set; }


        public string NotificaGiocatori(string messaggio)
        {
            foreach (Personaggio g in GiocatoriPresenti)
            {
                    return $"Messaggio per {g.Nome}: {messaggio}";
            }
            return "";
        }

    }
}
