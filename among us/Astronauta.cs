using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Among_us
{
    public class Astronauta : Personaggio
    {
        public Astronauta(string nome, string colore, int posizioneX, int posizioneY, bool stagiocando) : base(nome, colore, posizioneX, posizioneY, stagiocando)
        {
            Nome = nome;
            Colore = colore;
            PosizioneX = posizioneX;
            PosizioneY = posizioneY;
            InVita = stagiocando;
            //inventario = new Oggetto[2];
            messaggi = new List<string>();
        }
        public void Accusa(ref Personaggio giocatore)
        {
            if (giocatore is Impostore && giocatore.InVita == true)
            {
                giocatore.InVita = false;
            }
            else
            {
                InVita = false;
            }
        }
    }
}