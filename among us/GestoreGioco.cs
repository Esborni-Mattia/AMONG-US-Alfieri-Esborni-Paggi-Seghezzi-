using Among_us;
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
        private bool[] turnazzi;
        private static List<Personaggio> giocatori = new List<Personaggio>();
        private static Random rnd = new Random();

        public GestoreGioco(int nGioc)
        {
            NumGiocatori = nGioc;
            TurnoAttuale = 0;
            turnazzi = new bool[nGioc];
        }
        public int NumGiocatori
        {
            get { return numGiocatori; }
            set
            {
                if (value < 4 || value > 16)
                {
                    throw new ArgumentException("numero giocatori non valido");
                }
                numGiocatori = value;
            }
        }
        public int TurnoAttuale
        {
            get { return turnoAttuale; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("turno non valido");
                }
                turnoAttuale = value;
            }
        }
        public List<Personaggio> Giocatori
        {
            get { return giocatori; }
        }
        public Personaggio Crea_Giocatore(Personaggio p)
        {
            foreach (Personaggio i in giocatori)
            {
                if (i.Nome == p.Nome || i.Colore == p.Colore)
                {
                    throw new ArgumentException("Non possono esserci più giocatori con lo stesso nome o colore");
                }
            }

            giocatori.Add(p);
            if (giocatori.Count == numGiocatori)
            {
                AssegnaImpostori();
            }

            return p;
        }
        public void AssegnaImpostori()
        {
            int numImpostori = numGiocatori / 4;
            HashSet<int> impostoriSelezionati = new HashSet<int>();
            for (int i = 0; i < giocatori.Count; i++)
            {
                giocatori[i] = new Astronauta(giocatori[i].Nome, giocatori[i].Colore, giocatori[i].PosizioneX, giocatori[i].PosizioneY, true);
            }

            while (impostoriSelezionati.Count < numImpostori)
            {
                int estratto = rnd.Next(0, giocatori.Count);
                Personaggio g = giocatori[estratto];
                if (!(g is Impostore))
                {
                    giocatori[estratto] = new Impostore(g.Nome, g.Colore, g.PosizioneX, g.PosizioneY, true);
                    impostoriSelezionati.Add(estratto);
                }
            }
        }
        public void Elimina_Giocatore(Personaggio p)
        {
            if (!giocatori.Contains(p))
            {
                throw new ArgumentException("Giocatore inesistente");
            }
            giocatori.Remove(p);
            if (giocatori.Count >= 4)
            {
                AssegnaImpostori();
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
        public string GetRuoloGiocatore(Personaggio p)
        {
            return p is Impostore ? "IMPOSTORE" : "ASTRONAUTA";
        }
    }
}


