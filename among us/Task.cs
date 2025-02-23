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

        public void Svolgi(Personaggio giocatore)
        {
            if (serveOggetto == false && svolta == false)
            {
                svolta = true;
                throw new Exception("hai svolto la task");
            }
            if (serveOggetto == true && svolta == false)
            {
                if (giocatore.GetInventario().Contains(oggetto)) //TODO - fare classe oggetto per sistemare questo problema
                {
                    svolta = true;
                    throw new Exception("hai svolto la task");
                }
            }
            if (svolta == true)
            {
                throw new Exception("task già svolta");
            }
        }
    }
}
