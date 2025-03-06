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
            inventario = new Oggetto[2];
            messaggi = new List<string>();
        }
        private static List<string> ListaColori = new List<string>
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
        public Oggetto[] inventario { get; set; }
        private string colore;
        public List<string> messaggi;

        private string statoAttuale = "Normale";
        private Mappa posizioneAttuale;

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
                    if (char.IsLetter(value[c]))
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
                posizioneX = value;
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
                StatoAttuale = value;
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
        public virtual void spostamento(string direzione, int[,] mappa)
        {
            switch (direzione.ToLower())
            {
                case "sud":
                    if(PosizioneY - 1 == 1)
                    {
                        throw new ArgumentException("non puoi muoverti dove ci sono muri");
                    }
                    PosizioneY -= 1;
                    break;
                case "est":
                    if (PosizioneX + 1 == 1)
                    {
                        throw new ArgumentException("non puoi muoverti dove ci sono muri");
                    }
                    PosizioneX += 1;
                    break;
                case "ovest":
                    if (PosizioneX - 1 == 1)
                    {
                        throw new ArgumentException("non puoi muoverti dove ci sono muri");
                    }
                    PosizioneX -= 1;
                    break;
                case "nord":
                    if (PosizioneY + 1 == 1)
                    {
                        throw new ArgumentException("non puoi muoverti dove ci sono muri");
                    }
                    PosizioneY += 1;
                    break;
            }
            if (PosizioneX < 0 || PosizioneX >= mappa.GetLength(1) || PosizioneY < 0 || PosizioneY >= mappa.GetLength(0))
            {
                throw new ArgumentException("Non puoi uscire dai limiti della mappa");
            }

            // Controllo se la nuova posizione è un muro
            if (mappa[PosizioneY, PosizioneX] == 1)
            {
                throw new ArgumentException("Non puoi muoverti dove ci sono muri");
            }
        }

        public virtual void PrendiOggetto(Oggetto oggetto)
        {
            int Nelementi_inventario = 0;
            foreach (Oggetto i in inventario)
            {
                if (i != null)
                {
                    Nelementi_inventario += 1;
                }
            }
            foreach (Oggetto i in inventario)
            {
                if (Nelementi_inventario < 2)
                {
                    if (oggetto == i)
                    {
                        throw new Exception("l'oggetto è già presente nel tuo inventario");
                    }
                    else
                    {
                        inventario[inventario.Length - 1] = oggetto;
                    }
                }
                else
                {
                    throw new Exception("inventario pieno");
                }
            }
        }

        public virtual void LasciaOggetto(int pos_oggetto_nel_array) //probabilmente dovrà essere di tipo string perchè ritornerà l'elemento rilasciato
        {
            if (pos_oggetto_nel_array < 0 || pos_oggetto_nel_array > 2)
            {
                throw new ArgumentException("posizione non valida");
            }
            else
            {
                
                inventario[pos_oggetto_nel_array] = null;

            }
            
            
            
            
            
            //TODO - fare in modo che l'oggetto rilasciato rimanga nella stanza in cui c'è stato il rilascio
            //bisogna prima creare la classe oggetto con gli attributi della posizione
        }


        public virtual Oggetto[] guarda_zaino()
        {
            return inventario;
        }

        public virtual void Parla_con(Personaggio giocatore, string messaggio)
        {
            if (giocatore.PosizioneX == PosizioneX && giocatore.PosizioneY == PosizioneY)//significa che sono nella stessa stanza e possono comunicare
            {
                giocatore.messaggi.Add($"mittente: {giocatore.Nome}, colore: {giocatore.Colore}, ambiente di invio: {PosizioneX}:{PosizioneY} messaggio: {messaggio}");
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
