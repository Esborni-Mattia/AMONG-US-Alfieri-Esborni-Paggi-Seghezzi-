using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class Task
    {
        private bool serveOggetto;
        private bool svolta;

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
