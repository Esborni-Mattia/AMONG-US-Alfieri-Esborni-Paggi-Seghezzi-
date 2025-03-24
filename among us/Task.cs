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
        public bool svolta { get; set; }
        private oggetti? oggettonecessario;
        public bool Completata => svolta; 
        public oggetti? Oggettonecessario => oggettonecessario; 

        public Task(bool servOgg, oggetti? oggetto = null)
        {
            oggettonecessario = oggetto;
            serveOggetto = servOgg;
            svolta = false;
        }

        public void Svolgi(Personaggio giocatore, Oggetto oggetto)
        {
            if (svolta)
            {
                throw new Exception("task già svolta");
            }
            if (serveOggetto == false && svolta == false)
            {
                svolta = true;
            }
            if (serveOggetto == true && svolta == false)
            {
                if (oggettonecessario == null)
                {
                    throw new Exception("la task ha bisogno di un oggetto ma non è stato detto quale");
                }
                if (!giocatore.guarda_zaino().Contains(oggetto))
                {
                    throw new Exception($"Serve {Oggettonecessario} per svolgere la task");
                }
                svolta = true;
            }
        }
    }
}
