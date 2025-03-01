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


        public void NotificaGiocatori(string messaggio)
        {
            foreach (Personaggio giocatore in GiocatoriPresenti)
            {
                Console.WriteLine($"Messaggio per {giocatore.Nome}: {messaggio}");
            }
        }

    }
}
