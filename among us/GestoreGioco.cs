using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class GestoreGioco
    {
        private int turnoAttuale;
        private int numGiocatori;
        private static Random rnd = new Random();
        public static List<Personaggio> giocatori = new List<Personaggio>();



        public int NumGiocatori
        {
            get { return numGiocatori; }
            set
            {
                if (value < 4 || value > 16)
                {
                    throw new ArgumentException("numero giocatori non valido");
                }
            }
        }
        public int TurnoAttuale
        {
            get { return turnoAttuale; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("turno non valido");
                }
                turnoAttuale = value;
            }
        }

        public override string ToString()
        {
            return $"E' il turno di {giocatori[TurnoAttuale].Nome}";
        }

        public string MostraAmbiente(Ambiente a)
        {
            return $"nome ambiente: {a.nome}";
        }

        public string MostraQuest(Ambiente am)
        {
            return $"task ambiente: {am.quest}";
        }
        public void FineTurno()
        {
            foreach (Personaggio giocatore in giocatori)
            {
                giocatore.ResetStato();
            }
        }
    }
}
