using System.Windows.Forms;

namespace Among_us
{
    public partial class Form1 : Form
    {
        private List<Personaggio> giocatori = new List<Personaggio>();
        public List<string> ListaColori = new List<string>
        {
        "Rosso",
        "Blu",
        "Verde",
        "Rosa",
        "Arancione",
        "Giallo",
        "Nero",
        "Bianco",
        "Viola",
        "Ciano",
        "Lime",
        "Marrone",
        "Grigio",
        "Beige",
        "Argento",
        "Fucsia"
        };
        public GestoreGioco gestore;
        public Form1()
        {
            InitializeComponent();
            for (int i = 4; i < 16; i++)
            {
                comboBox2.Items.Add(i);
            }
            foreach (string s in ListaColori)
            {
                comboBox1.Items.Add(s);
            }
        }
        private void AggiornaListaGiocatori()
        {
            listagiocatori.Items.Clear();
            foreach (Personaggio g in gestore.Giocatori)
            {
                string ruolo = gestore.GetRuoloGiocatore(g);
                listagiocatori.Items.Add($"{g.Nome} - {g.Colore} ({ruolo})");
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                int numeroGiocatori = (int)comboBox2.SelectedItem;
                gestore = new GestoreGioco(numeroGiocatori);
                comboBox2.Enabled = false;
            }
        }
        private void AggiornaPulsanteAggiungi()
        {
            button1.Enabled = gestore.Giocatori.Count < (int)comboBox2.SelectedItem;
        }
        private void buttonAGGIUNGI_GIOCATORE_Click(object sender, EventArgs e)
        {
            try
            {
                if (gestore == null || comboBox2.SelectedItem == null)
                {
                    throw new Exception("seleziona il numero di giocatori");
                }
                if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 3)
                {
                    throw new Exception("Il nome del giocatore non deve essere vuoto o più corto di 3 caratteri.");
                }

                if (comboBox1.SelectedItem == null)
                {
                    throw new Exception("Devi selezionare un colore!");
                }
                string nome = textBox1.Text;
                string colore = comboBox1.SelectedItem.ToString();
                Personaggio nuovoGiocatore = new Astronauta(nome, colore, 0, 1, true);
                nuovoGiocatore = gestore.Crea_Giocatore(nuovoGiocatore); 
                giocatori.Add(nuovoGiocatore);
                AggiornaPulsanteAggiungi();
                if (giocatori.Count == (int)comboBox2.SelectedItem)
                {
                    AggiornaListaGiocatori();
                    button1.Enabled = false;
                }
                else
                {
                    listagiocatori.Items.Add($"{nome} - {colore} (ASTRONAUTA)");
                }
                comboBox1.Items.Remove(colore);
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRIMUOVI_GIOCATORE_Click(object sender, EventArgs e)
        {
            try
            {
                if (listagiocatori.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona un giocatore dalla lista per rimuoverlo.");
                }
                string nomeSelezionato = listagiocatori.SelectedItem.ToString().Split('-')[0].Trim();
                Personaggio giocatoreDaRimuovere = null;
                foreach (Personaggio g in gestore.Giocatori)
                {
                    if (g.Nome.Equals(nomeSelezionato, StringComparison.OrdinalIgnoreCase)) 
                    {
                        giocatoreDaRimuovere = g;
                        break; 
                    }
                }
                if (giocatoreDaRimuovere == null)
                {
                    throw new Exception("Giocatore non trovato.");
                }
                string colore = giocatoreDaRimuovere.Colore;
                gestore.Elimina_Giocatore(giocatoreDaRimuovere);
                giocatori.Remove(giocatoreDaRimuovere);
                comboBox1.Items.Add(colore);
                listagiocatori.Items.RemoveAt(listagiocatori.SelectedIndex);
                AggiornaListaGiocatori();
                AggiornaPulsanteAggiungi();

                MessageBox.Show($"Giocatore {nomeSelezionato} rimosso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listagiocatori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
