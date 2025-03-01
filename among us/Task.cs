using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public enum oggetti
    {
        attrezzo_multiuso, //stanza 1 e 10
        materasso_nuovo,   //stanza 4
        motore_elettrico,  //stanza 5
        tessera_di_accesso,//stanza 7 
        tubo_di_ricambio,  //stanza 8
        batteria,          //stanza 11
        saldatrice,        //stanza 12
        fusibile,          //stanza 13
        scheda_di_rete,    //stanza 15
        chiave_magnetica,  //stanza 17
        filtro_acqua,      //stanza 18
        bombola_aria,      //stanza 19
        casco_di_ricambio  //stanza 20
    }
    
    public class Task
    {
        private bool serveOggetto;
        private bool svolta;
        private oggetti oggetto;
        

        public oggetti Oggetto
        {
            get { return oggetto; }
            set
            {

            }
        }

        public Task(bool servOgg)
        {
            serveOggetto = servOgg;
            svolta = false;
        }

        public void Svolgi(Personaggio giocatore, Oggetto oggetto)
        {
            if (serveOggetto == false && svolta == false)
            {
                svolta = true;
            }
            if (serveOggetto == true && svolta == false)
            {
                if (giocatore.guarda_zaino().ToList().Contains(oggetto.Nome))
                {
                    svolta = true;
                }
            }
            if (svolta == true)
            {
                throw new Exception("task già svolta");
            }
        }
    }
}
