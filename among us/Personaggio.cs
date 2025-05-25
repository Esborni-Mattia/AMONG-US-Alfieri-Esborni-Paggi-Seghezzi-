using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public abstract class Personaggio
    {
        public Personaggio(string nome, string colore, int posizioneX, int posizioneY, bool stagiocando)
        {
            Nome = nome;
            Colore = colore;
            InVita = stagiocando;
            PosizioneX = posizioneX;
            PosizioneY = posizioneY;
            inventario = new List<Oggetto>();
            messaggi = new List<string>();
            direzioni = new List<string>();
        }
        public override string ToString()
        {
            return $"NOME: {Nome}, COLORE: {Colore}";      //da visualizzare nella inizializzazione dei personaggi
        }
        private List<string> ListaColori = new List<string>
        {
        "Rosso",
        "Blu",
        "Verde",
        "Rosa",
        "Arancione",
        "Giallo",
        "Nero",
        "Bianco",
        "Viola",
        "Ciano",
        "Lime",
        "Marrone",
        "Grigio",
        "Beige",
        "Argento",
        "Fucsia"
        };

        private int posizioneX;
        private bool inVita;
        private int posizioneY;
        private string nome;
        private List<string> direzioni;
        public List<Oggetto> inventario;
        private string colore;
        public List<string> messaggi;

        private string statoAttuale = "Normale";
        private Mappa posizioneAttuale;
        private Mappa posizioneArrivo;

        public bool InVita
        {
            get { return inVita; }
            set { inVita = value; }
        }
        public string Colore
        {
            get { return colore; }
            set
            {
                if (!ListaColori.Contains(value))
                {
                    throw new ArgumentException("colore non disponibile");
                }
                colore = value;
            }
        }
        public string Nome
        {
            get { return nome; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("lunghezza nome non valida");
                }
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new ArgumentException("il nome può contenere solo lettere");
                    }
                }
                nome = value;
            }
        }
        public int PosizioneX
        {
            get { return posizioneX; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("posizione x non valida");
                }
                posizioneX = value;
            }
        }
        public int PosizioneY
        {
            get { return posizioneY; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("posizione y non valida");
                }
                posizioneY = value;
            }
        }
        public string StatoAttuale
        {
            get
            {
                return statoAttuale;
            }
            set
            {
                statoAttuale = value;
            }
        }
        public Mappa PosizioneAttuale
        {
            get
            {
                return posizioneAttuale;
            }
            set
            {
                posizioneAttuale = value;
            }
        }

        public Mappa PosizioneArrivo
        {
            get { return posizioneArrivo; }
            set { posizioneArrivo = value; }
        }

        public virtual List<Ambiente> StanzeAdiacenti(Mappa mappa)  //ritorna una lista con le stanze adiacenti al giocatore
        {
            List<Ambiente> stanze = new List<Ambiente>();
            Ambiente est = mappa.GetStanza(PosizioneX, PosizioneY + 1);
            if (est != null)
            {
                stanze.Add(est);
                direzioni.Add("est");
            }
            Ambiente ovest = mappa.GetStanza(PosizioneX, PosizioneY - 1);
            if (ovest != null)
            {
                stanze.Add(ovest);
                direzioni.Add("ovest");
            }
            Ambiente nord = mappa.GetStanza(PosizioneX - 1, PosizioneY);
            if (nord != null)
            {
                stanze.Add(nord);
                direzioni.Add("nord");
            }
            Ambiente sud = mappa.GetStanza(PosizioneX + 1, PosizioneY);
            if (sud != null)
            {
                stanze.Add(sud);
                direzioni.Add("sud");
            }
            return stanze;
        }

        public List<string> get_direzioni()
        {
            return direzioni;
        }


        public virtual void spostamento(string direzione, int[,] mappa, Mappa mappaOggetti)
        {
            if (direzione == null)
                throw new Exception("Seleziona una direzione");

            int nuovaX = PosizioneX;
            int nuovaY = PosizioneY;

            switch (direzione.ToLower())
            {
                case "ovest": nuovaY -= 1; break;
                case "sud": nuovaX += 1; break;
                case "nord": nuovaX -= 1; break;
                case "est": nuovaY += 1; break;
                default: throw new ArgumentException("Direzione non valida");
            }

            if (nuovaX < 0 || nuovaX >= mappa.GetLength(0) ||
            nuovaY < 0 || nuovaY >= mappa.GetLength(1))
            {
                throw new ArgumentException("Non puoi uscire dai limiti della mappa");
            }

            if (mappa[nuovaX, nuovaY] == 1)
            {
                throw new ArgumentException("Non puoi muoverti dove ci sono muri");
            }

            // Sposta il personaggio usando la logica centralizzata nella mappa
            mappaOggetti.SpostaPersonaggio(this, nuovaX, nuovaY);
        }



        public virtual void PrendiOggetto(Oggetto oggetto)
        {   
            if(inventario.Count < 2)
            {
                if (!inventario.Contains(oggetto))
                {
                    inventario.Add(oggetto);
                }
                else
                {
                    throw new Exception("Oggetto già presente (impossibile)");
                }
                
            }
            else
            {
                throw new Exception("Inventario pieno");
            }
            
        }


        public virtual void LasciaOggetto(int pos_oggetto_nel_array, Ambiente nuovaPosizione) //probabilmente dovrà essere di tipo Oggetto perchè ritornerà l'elemento rilasciato
        {
            if (pos_oggetto_nel_array < 0 || pos_oggetto_nel_array >= inventario.Count)
            {
                throw new ArgumentException("Posizione non valida");
            }
            else
            {
                Oggetto oggettoRilasciato = inventario[pos_oggetto_nel_array]; // recupero oggetto
                if (oggettoRilasciato != null)
                {
                    //oggettoRilasciato.posizione = nuovaPosizione;
                    inventario[pos_oggetto_nel_array] = null;
                }
            }
        }

        public virtual List<Oggetto> guarda_zaino()
        {
            return inventario;
        }

        public virtual void Parla_con(Personaggio giocatore, string messaggio)
        {
            if (giocatore.PosizioneX == PosizioneX && giocatore.PosizioneY == PosizioneY)//significa che sono nella stessa stanza e possono comunicare
            {
                giocatore.messaggi.Add($"mittente: {Nome}, colore: {Colore}, ambiente di invio: {PosizioneX}:{PosizioneY} messaggio: {messaggio}");
            }
            else
            {
                throw new ArgumentException("non puoi comunicare con giocatori in stanze diverse");
            }
        }


        public virtual List<string> vedi_messaggi()
        {
            return messaggi;
        }
        public void CambiaStato(string nuovoStato)
        {
            StatoAttuale = nuovoStato;
        }

        public void ResetStato()
        {
            StatoAttuale = "Normale";
        }
    }
}
