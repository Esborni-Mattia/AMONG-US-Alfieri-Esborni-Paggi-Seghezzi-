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

        public Oggetto Oggetto { get; set; }
        public List<Personaggio> Personaggio { get; set; }
        public string Immagine { get; set; }
        public void AggiungiPersone(Personaggio p)
        {
            if (!Personaggio.Contains(p))
            {
                Personaggio.Add(p);
            }
        }

        public void RimuoviPersone(Personaggio p)
        {
            if (Personaggio.Contains(p))
            {
                Personaggio.Remove(p);
            }
        }
        public Ambiente(Ambienti n, string d, string im, Task? t = null, Oggetto  ogg= null)
        {
            nome = n;
            quest = t;
            Descrizione = d;
            Oggetto = ogg;
            Immagine = im;
            Personaggio = new List<Personaggio>();
        }

    }
}
