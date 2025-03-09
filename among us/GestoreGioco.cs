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
        private static List<Personaggio> giocatori = new List<Personaggio>();
        private static Random rnd = new Random();

        public GestoreGioco(int nGioc)
        {
            NumGiocatori = nGioc;
            TurnoAttuale = 0;
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


        

        public void Crea_Giocatore(Personaggio p)
        {
            foreach(Personaggio i in giocatori)
            {
                if(i.Nome == p.Nome || i.Colore == p.Colore)
                {
                    throw new ArgumentException("non possono esserci più giocatori con lo stesso nome o colore");
                }
                else
                {
                    giocatori.Add(p);

                    int numImpostori = 0;
                    if (numGiocatori < 16 && numGiocatori%4 == 0) numImpostori = Math.Abs(numGiocatori / 4);
                    else throw new ArgumentException("più di 16 giocatori");


                    HashSet<int> impostoriSelezionati = new HashSet<int>(); //lista che non accetta duplicati

                    while (impostoriSelezionati.Count < numImpostori)
                    {
                        int estratto = rnd.Next(0, giocatori.Count);
                        if (!(giocatori[estratto] is Impostore))  // Controlla che non sia già un impostore
                        {
                            giocatori[estratto] = new Impostore(giocatori[estratto].Nome, giocatori[estratto].Colore, giocatori[estratto].PosizioneX, giocatori[estratto].PosizioneY, true); // Converte in impostore
                            impostoriSelezionati.Add(estratto);
                        }                       
                    }
                }
            }
        }
        public void Elimina_Giocatore(int pos)
        {
            if(pos<0 || pos > giocatori.Count)
            {
                throw new ArgumentException("giocatore inesistente");
            }
            else
            {
                giocatori.RemoveAt(pos);
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
        public string MostraCreazionePersona(Personaggio p)
        {
            string a;
            if(p is Impostore)
            {
                a = "IMPOSTORE";
            }
            else
            {
                a = "ASTRONAUTA";
            }
            return $"Ciao {p.Nome}, indossi la tuta spaziale {p.Colore} e giochi come {a}";
        }
    }
}
