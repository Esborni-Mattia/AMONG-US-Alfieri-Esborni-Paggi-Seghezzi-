using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class mappa1
    {
        public void disegmaMappa()
        {
            string[] mappa = new string[]
            {
                "     | 1 |     | 2 |     | 3 |  ",
                "     | 4 |     | 5 |     | 6 |[ 7 |  ",
                "| 8 || 9 ||10 ||11 ||12 ||13 |",
                "     |14 |     |15 |     |16 ||17 |  ",
                "     |18 |     |19 |     |20 |  "
            };

            foreach (string righe in mappa)
            {
                Console.WriteLine(righe);
            }
        }
    }
}
