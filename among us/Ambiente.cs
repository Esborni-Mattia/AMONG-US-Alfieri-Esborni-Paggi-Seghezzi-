using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{

    public enum Ambienti
    {
        SalaComando,
        SalaMotore,
        Dormitorio1,
        Dormitorio2,
        Palestra,
        Laboratorio,
        Cucina,
        Magazzino,
        Armeria,
        PonteOsservazione,
        Infermeria,
        Stiva,
        TunnelManutenzione,
        SalaRadar,
        CentroComunicazioni,
        DepositoCarburante,
        Criocamere,
        Serre,
        BaiaAttracco,
        CameraDecompressione
    }

    public class Ambiente
    {
        public Ambienti nome { get; set; }

        public string Descrizione { get; set; }
        public Task? quest { get; set; }

        public oggetti? oggetto { get; set; }


        public Ambiente(Ambienti n,string d, Task? t = null, oggetti? o=null)
        {
            nome = n;
            quest = t;
            Descrizione = d;
            oggetto = o;
        }

    }
}
