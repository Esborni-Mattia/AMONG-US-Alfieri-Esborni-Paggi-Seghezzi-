using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_us
{
    public class Impostore : Personaggio
    {
        public Impostore(string nome, string colore, int posizioneX, int posizioneY, bool stagiocando) : base(nome, colore, posizioneX, posizioneY, stagiocando)
        {
            Nome = nome;
            Colore = colore;
            PosizioneX = posizioneX;
            PosizioneY = posizioneY;
            InVita = stagiocando;
            inventario = new string[2];
            messaggi = new List<string>();
        }

        public void usaBotola()
        {

        }

    }
}
