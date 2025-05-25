using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Among_us
{
    public abstract class Mappa
    {
        public List<Personaggio> GiocatoriPresenti = new List<Personaggio>();
        protected int[,] Map;
        protected static Random rnd = new Random();
        protected static List<Oggetto> strumenti = new List<Oggetto>()
        {
            new Oggetto(oggetti.attrezzo_multiuso),
            new Oggetto(oggetti.materasso_nuovo),
            new Oggetto(oggetti.motore_elettrico),
            new Oggetto(oggetti.tessera_di_accesso),
            new Oggetto(oggetti.tubo_di_ricambio),
            new Oggetto(oggetti.batteria),
            new Oggetto(oggetti.saldatrice),
            new Oggetto(oggetti.fusibile),
            new Oggetto(oggetti.scheda_di_rete),
            new Oggetto(oggetti.chiave_magnetica),
            new Oggetto(oggetti.filtro_acqua),
            new Oggetto(oggetti.bombola_aria),
            new Oggetto(oggetti.casco_di_ricambio)
        };
        protected Dictionary<(int, int), Ambiente> ambienti = new Dictionary<(int, int), Ambiente>();
        public abstract int[,] disegnaMappa();
        public void getStrumenti(List<Oggetto> o)
        {
            strumenti = o;
        }
        public Oggetto generazione_casuale_oggetti() //funzione per generare casualmente gli oggetti delle task nelle stanze all'inizio del gioco
        {
            try
            {
                int a = rnd.Next(0, strumenti.Count);
                Oggetto oggettoCasuale = strumenti[a];
                strumenti.RemoveAt(a);
                return oggettoCasuale;
            }
            catch (Exception e) { throw new Exception("Oggetti non caricati correttamente, riavviare l'applicazione"); }
            

        }
        public Ambiente GetStanza(int x, int y)    //ritorna la posizione della stanza nella mappa
        {
            ambienti.TryGetValue((x, y), out Ambiente stanza);
            return stanza;
        }
        public int[,] getStanze()
        {
            return Map;
        }
        public Dictionary<(int, int), Ambiente> getStanzes()
        {
            return ambienti;
        }
        public bool TutteLeTaskComplete()
        {
            foreach (Ambiente stanza in ambienti.Values)
            {
                //se la stanza ha una quest e questa non è svolta, ritorna false
                if (stanza.quest != null && !stanza.quest.svolta)
                {
                    return false;
                }
            }
            //se tutte le stanze sono senza quest o le quest sono tutte svolte, ritorna true
            return true;
        }
        public void SpostaPersonaggio(Personaggio p, int nuovaX, int nuovaY)
        {
            // Rimuovi il personaggio da tutte le stanze
            foreach (Ambiente stanza in ambienti.Values)
            {
                stanza.RimuoviPersone(p);
            }

            // Aggiorna le coordinate
            p.PosizioneX = nuovaX;
            p.PosizioneY = nuovaY;

            // Aggiungi alla nuova stanza
            GetStanza(nuovaX, nuovaY)?.AggiungiPersone(p);
        }


    }
}
