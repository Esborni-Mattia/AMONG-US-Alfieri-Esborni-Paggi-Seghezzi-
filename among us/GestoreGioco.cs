using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class GestoreGioco
    {
        private int turnoAttuale;
        private int numGiocatori;

        public int NumGiocatori
        {
            get { return numGiocatori; }
            set
            {
                if(value<4 || value > 16)
                {
                    throw new ArgumentException("numero giocatori non valido");
                }
            }
        }
        public int TurnoAttuale
        {
            get { return turnoAttuale; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("turno non valido");
                }
                turnoAttuale = value;
            }
        }
    }
}
