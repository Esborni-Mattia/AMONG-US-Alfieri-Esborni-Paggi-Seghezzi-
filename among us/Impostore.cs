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
            inventario = new List<Oggetto>();
            messaggi = new List<string>();
        }

        public void usaBotola(Mappa mappa)
        {
            if (mappa.Botole == true)
            {
                //TODO - cambiare posizionex e posizioney del personaggio
                UsaBotola(PosizioneAttuale, PosizioneArrivo);
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
        public void Uccidi(ref Personaggio bersaglio)
        {
            // Verifica che il bersaglio sia nella stessa stanza
            if (bersaglio.PosizioneX != this.PosizioneX || bersaglio.PosizioneY != this.PosizioneY)
            {
                throw new Exception("Non puoi uccidere giocatori in stanze diverse");
            }

            // Verifica che il bersaglio sia vivo
            if (!bersaglio.InVita)
            {
                throw new Exception("Non puoi uccidere un giocatore già morto");
            }

            // Verifica che il bersaglio non sia un altro impostore
            if (bersaglio is Impostore)
            {
                throw new Exception("Non puoi uccidere un altro impostore");
            }

            // Imposta l'uccisione
            CambiaStato("Ha appena commesso un omicidio");
            bersaglio.InVita = false;

            // Messaggio di notifica (semplificato per ora)
            messaggi.Add($"Hai ucciso {bersaglio.Nome}");
        }
    }
}
