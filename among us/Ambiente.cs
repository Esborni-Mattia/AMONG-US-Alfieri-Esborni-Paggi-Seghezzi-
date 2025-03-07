using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class Ambiente
    {
        public enum Ambienti
        {
            caffetteria,
            sala_elettricità,
            telecamere,
            snai,
            laboratorio,
            palestra,
            dormitorio,
            sala_motore,
            sala_comando,
            eurobet,
            sisal,
            ossigeno,
            reattore,
            armeria,
            libreria,
            bagno,
            infermeria,
            sala_osservatorio,
            giardino
        }
        Ambienti sale;
        public string nome { get; set; }

        public string Descrizione { get; set; }
        public Task? quest { get; set; }


        public Ambiente(string n,string d, Ambienti a, Task? t = null)
        {
            nome = n;
            quest = t;
            Descrizione = d;
            sale = a;
        }

    }
}
