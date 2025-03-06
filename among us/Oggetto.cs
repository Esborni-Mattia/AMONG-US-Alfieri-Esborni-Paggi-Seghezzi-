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
    public class Oggetto
    {
        private oggetti nome;
        public Ambiente posizione { get; set; }


        public oggetti Nome
        {
            get { return nome; }
            set
            {
                if(!(value is oggetti))
                {
                    throw new ArgumentException("oggetto non valido");
                }
                nome = value;
            }
        }

        public Oggetto(oggetti nome, Ambiente pos)
        {
            Nome = nome;
            posizione = pos;
        }



    }
}
