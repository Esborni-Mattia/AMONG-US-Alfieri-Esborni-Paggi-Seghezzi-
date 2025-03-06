using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_us
{
    public class Impostore : Personaggio
    {
        public Impostore(string nome, string colore, int posizioneX, int posizioneY, bool stagiocando) : base(nome, colore, posizioneX, posizioneY, stagiocando)
        {
            Nome = nome;
            Colore = colore;
            PosizioneX = posizioneX;
            PosizioneY = posizioneY;
            InVita = stagiocando;
            inventario = new Oggetto[2];
            messaggi = new List<string>();
        }

        public void usaBotola(Mappa mappa)
        {
            if (mappa.Botola == true)
            {
                //TODO - cambiare posizionex e posizioney del personaggio
            }
            else
            {
                throw new Exception("non c'è nessuna botola disponibile");
            }
        }

        public void UsaBotola(Mappa partenza, Mappa arrivo)
        {
            CambiaStato("Ha appena usato una botola");
            partenza.NotificaGiocatori($"{Nome} ha usato una botola!");
            arrivo.NotificaGiocatori($"Qualcuno è comparso da una botola!");
            PosizioneAttuale = arrivo;
        }
        public void Uccidi(Personaggio bersaglio)
        {
            if (bersaglio.StatoAttuale == "Ha appena svolto un incarico in questa stanza")
            {
                // Uccisione sicura
                CambiaStato("Ha appena commesso un omicidio");
                PosizioneAttuale.NotificaGiocatori($"{Nome} ha ucciso qualcuno!");
            }
            else
            {
                // Probabilità 50%
                bool successo = new Random().Next(2) == 0;
                if (successo)
                {
                    CambiaStato("Ha appena commesso un omicidio");
                    PosizioneAttuale.NotificaGiocatori($"{Nome} ha ucciso qualcuno!");
                }
            }

        }
    }
}
