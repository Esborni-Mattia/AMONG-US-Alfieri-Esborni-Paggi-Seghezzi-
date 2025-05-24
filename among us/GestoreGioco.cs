using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Among_us
{
    public class GestoreGioco
    {
        private int turnoAttuale;
        private int numGiocatori;
        private List<Personaggio> giocatori;
        private static Random rnd = new Random();
        private Mappa mappa;
        private Personaggio giocatoreAttuale;

        public GestoreGioco(int nGioc)
        {
            if (nGioc < 4 || nGioc > 16)
            {
                throw new ArgumentException("Il numero di giocatori deve essere tra 4 e 16");
            }

            NumGiocatori = nGioc;
            TurnoAttuale = 0;
            giocatori = new List<Personaggio>();
            mappa = AssegnaMappa();
        }

        public Personaggio GiocatoreAttuale
        {
            get { return giocatoreAttuale; }
            private set { giocatoreAttuale = value; }
        }

        public void CambiaTurno()
        {
            if (giocatori.Count == 0)
            {
                throw new InvalidOperationException("Non ci sono giocatori nel gioco.");
            }

            // Incrementa il turno e torna a 0 se supera la lunghezza della lista
            

            turnoAttuale = (turnoAttuale + 1) % giocatori.Count;
            GiocatoreAttuale = giocatori[turnoAttuale];

            // Debugging per vedere il cambio turno
            MessageBox.Show($"Turno attuale: {turnoAttuale + 1}\nGiocatore attuale: {GiocatoreAttuale.Nome}");
        }

        public int NumGiocatori
        {
            get { return numGiocatori; }
            private set
            {
                if (value < 4 || value > 16)
                {
                    throw new ArgumentException("Numero giocatori non valido");
                }
                numGiocatori = value;
            }
        }

        public int TurnoAttuale
        {
            get { return turnoAttuale; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Turno non valido");
                }
                turnoAttuale = value;
            }
        }

        public List<Personaggio> Giocatori
        {
            get { return giocatori; }
        }

        public Personaggio CreaGiocatore(string nome, string colore)
        {
            if (giocatori.Count >= numGiocatori)
            {
                throw new InvalidOperationException($"Numero massimo di giocatori raggiunto ({numGiocatori})");
            }

            // Verifica nome e colore duplicati
            foreach (Personaggio i in giocatori)
            {
                if (i.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Non possono esserci più giocatori con lo stesso nome");
                }
                if (i.Colore.Equals(colore, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Non possono esserci più giocatori con lo stesso colore");
                }
            }

            // Inizializza come Astronauta (tutti iniziano come astronauti)
            Personaggio nuovoGiocatore = new Astronauta(nome, colore, 0, 1, true);
            giocatori.Add(nuovoGiocatore);
            mappa.GetStanza(nuovoGiocatore.PosizioneX, nuovoGiocatore.PosizioneY).AggiungiPersone(nuovoGiocatore);

            // Il primo giocatore aggiunto diventa automaticamente il giocatore attuale
            if (giocatori.Count == 1)
            {
                GiocatoreAttuale = nuovoGiocatore;
            }
            
            // Se abbiamo raggiunto il numero di giocatori necessari, assegna gli impostori
            if (giocatori.Count == numGiocatori)
            {
                AssegnaImpostori();
            }
            
            return nuovoGiocatore;
        }

        public Mappa GetMappa()
        {
            return mappa;
        }

        private Mappa AssegnaMappa()
        {
            int c = rnd.Next(1, 4);
            switch (c)
            {
                case 1: return new Mappa1();
                case 2: return new Mappa2();
                case 3: return new Mappa_3();
                default: return new Mappa1();
            }
        }

        public void AssegnaImpostori()
        {
            // Determina il numero di impostori in base al numero totale di giocatori
            int numImpostori = numGiocatori / 4;
            if (numImpostori < 1) numImpostori = 1;

            // Inizializza tutti come astronauti prima di selezionare gli impostori
            for (int i = 0; i < giocatori.Count; i++)
            {
                Personaggio g = giocatori[i];
                giocatori[i] = new Astronauta(g.Nome, g.Colore, g.PosizioneX, g.PosizioneY, g.InVita);
            }

            // Seleziona casualmente gli impostori
            HashSet<int> impostoriSelezionati = new HashSet<int>();
            while (impostoriSelezionati.Count < numImpostori)
            {
                int estratto = rnd.Next(0, giocatori.Count);
                if (!impostoriSelezionati.Contains(estratto))
                {
                    Personaggio g = giocatori[estratto];
                    giocatori[estratto] = new Impostore(g.Nome, g.Colore, g.PosizioneX, g.PosizioneY, g.InVita);
                    impostoriSelezionati.Add(estratto);
                }
            }

            // Aggiorna il giocatore attuale se è cambiato
            GiocatoreAttuale = giocatori[turnoAttuale];
        }

        public void EliminaGiocatore(Personaggio p)
        {
            
                int playerIndex = giocatori.IndexOf(p);

                if (p == GiocatoreAttuale && giocatori.Count > 1)
                {
                    CambiaTurno();
                }
                else if (playerIndex < turnoAttuale && giocatori.Count > 1)
                {
                    turnoAttuale--;
                }

                mappa.GetStanza(p.PosizioneX, p.PosizioneY).RimuoviPersone(p);
                giocatori.Remove(p);


                if (giocatori.Count > 0)
                {
                    turnoAttuale = Math.Min(turnoAttuale, giocatori.Count - 1);
                    GiocatoreAttuale = giocatori[turnoAttuale];
                }
                if (giocatori.Count >= 4)
                {
                    AssegnaImpostori();
                }
        }

        public bool Controllo_vittoria_morte_astronauti()
        {
            int contatore_vivi = 0;
            foreach(Personaggio i in giocatori)
            {
                if(i is Astronauta && i.InVita == true)
                {
                    contatore_vivi += 1;
                }
            }
            if (contatore_vivi == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Controllo_vittoria_morte_impostori()
        {
            int contatore_vivi = 0;
            foreach (Personaggio i in giocatori)
            {
                if (i is Impostore && i.InVita == true)
                {
                    contatore_vivi += 1;
                }
            }
            if (contatore_vivi == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Controllo_vittoria_svolgimento_task()
        {
            if (mappa.TutteLeTaskComplete() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"E' il turno di {GiocatoreAttuale?.Nome ?? "Nessun giocatore"}";
        }

        public string MostraAmbiente(Ambiente a)
        {
            return $"Nome ambiente: {a.nome}";
        }

        public string MostraQuest(Ambiente am)
        {
            return $"Task ambiente: {am.quest}";
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


