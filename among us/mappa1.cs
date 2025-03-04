using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class Mappa1
    {
        public void disegnaMappa()
        {
            int[,] mappa = //0 - calpestabile, 1 - muro
            {
            {1, 0, 1, 2, 1, 0, 1},  
            {1, 2, 1, 0, 1, 2, 1},  
            {0, 0, 0, 2, 0, 0, 0},  
            {1, 0, 1, 0, 1, 2, 1},  
            {1, 2, 1, 0, 1, 0, 1},  
            };
        }
        private Dictionary<(int, int), Ambiente> ambienti = new Dictionary<(int, int), Ambiente>();
        private Dictionary<(int, int), (int, int)> botoleCollegate = new Dictionary<(int, int), (int, int)>();

        public Mappa1()
        {
            disegnaMappa();
            CollegaBotole();
            InizializzaAmbienti();
        }

        private void InizializzaAmbienti()
        {
            ambienti[(0,1)] = new Ambiente("Sala di Comando","descrizione", new Task(true, oggetti.attrezzo_multiuso)); //TODO aggiungere tutte le descrizioni, task e nome dell'ambiente
        }
        private void CollegaBotole()
        {
            botoleCollegate[(0, 3)] = (2, 3);  //stanze collegate dalle  botole
            botoleCollegate[(2, 3)] = (0, 3);  

            botoleCollegate[(1, 1)] = (4, 1);  
            botoleCollegate[(4, 1)] = (1, 1);  

            botoleCollegate[(1, 5)] = (3, 5);  
            botoleCollegate[(3, 5)] = (1, 5); 
        }

        public (int, int) Teletrasporta(int x, int y)
        {
            if (!botoleCollegate.ContainsKey((x, y)))
            {
                throw new Exception("Non sei su una botola!");
            }

            (int newX, int newY) = botoleCollegate[(x, y)];
            return (newX, newY);
        }
    }
}
