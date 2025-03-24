using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Among_us
{
    public partial class Form1 : Form
    {
        public List<string> ListaColori = new List<string> { "Rosso", "Blu", "Verde", "Rosa", "Arancione", "Giallo", "Nero", "Bianco", "Viola", "Ciano", "Lime", "Marrone", "Grigio", "Beige", "Argento", "Fucsia" };
        private GestoreGioco gestore;
        private bool partitaIniziata = false;
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitializeUI();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += listboxGiocatori;
            timer.Interval = 2000;
            timer.Start();
        }

        private void listboxGiocatori(object? sender, EventArgs e)
        {
            if (gestore != null && gestore.GiocatoreAttuale != null)
            {
                AggiornaGiocatori();
                AggiornaVisibilitaPulsanteAccusa();
                AggiornaVisibilitaPulsanteUccidi();
            }
        }

        private void InitializeUI()
        {
            // Inizializza la ComboBox per il numero di giocatori
            for (int i = 4; i <= 16; i++)
            {
                comboBox2.Items.Add(i);
            }

            // Inizializza la ComboBox per i colori
            foreach (string colore in ListaColori)
            {
                comboBox1.Items.Add(colore);
            }

            // Disabilita i controlli per la fase di gioco fino a quando
            // non è completata la configurazione
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;

            // Imposta elementi predefiniti
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedItem != null)
                {
                    List<Oggetto> strumenti2 = new List<Oggetto>()
                {
                new Oggetto(oggetti.attrezzo_multiuso),
                new Oggetto(oggetti.materasso_nuovo),
                new Oggetto(oggetti.motore_elettrico),
                new Oggetto(oggetti.tessera_di_accesso),
                new Oggetto(oggetti.tubo_di_ricambio),
                new Oggetto(oggetti.batteria),
                new Oggetto(oggetti.saldatrice),
                new Oggetto(oggetti.fusibile),
                new Oggetto(oggetti.scheda_di_rete),
                new Oggetto(oggetti.chiave_magnetica),
                new Oggetto(oggetti.filtro_acqua),
                new Oggetto(oggetti.bombola_aria),
                new Oggetto(oggetti.casco_di_ricambio)
                };

                    // Se ci sono già giocatori aggiunti, chiedi conferma
                    if (gestore != null && gestore.Giocatori.Count > 0 && !partitaIniziata)
                    {
                        DialogResult result = MessageBox.Show(
                            "Cambiare il numero di giocatori resetterà la partita. Continuare?",
                            "Conferma",
                            MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            // Ripristina la selezione precedente senza attivare nuovamente l'evento
                            comboBox2.SelectedIndexChanged -= comboBox2_SelectedIndexChanged;
                            int precedenteNumGiocatori = gestore.NumGiocatori;
                            comboBox2.SelectedItem = precedenteNumGiocatori;
                            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
                            return;
                        }

                        // Reset della lista giocatori
                        listagiocatori.Items.Clear();

                        // Ripristina i colori disponibili
                        comboBox1.Items.Clear();
                        foreach (string colore in ListaColori)
                        {
                            comboBox1.Items.Add(colore);
                        }
                    }

                    // Crea una nuova istanza del gestore con il numero di giocatori selezionato
                    int numeroGiocatori = (int)comboBox2.SelectedItem;
                    gestore = new GestoreGioco(numeroGiocatori);
                    gestore.GetMappa().getStrumenti(strumenti2);
                    // Aggiorna lo stato del pulsante Aggiungi
                    AggiornaPulsanteAggiungi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AggiornaPulsanteAggiungi()
        {
            if (gestore != null)
            {
                button1.Enabled = gestore.Giocatori.Count < gestore.NumGiocatori;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void AggiornaListaGiocatori()
        {
            listagiocatori.Items.Clear();

            if (gestore != null)
            {
                foreach (Personaggio g in gestore.Giocatori)
                {
                    string ruolo = gestore.GetRuoloGiocatore(g);
                    listagiocatori.Items.Add($"{g.Nome} - {g.Colore} ({ruolo})");
                }
            }
        }

        private void buttonAGGIUNGI_GIOCATORE_Click(object sender, EventArgs e)
        {
            try
            {
                if (gestore == null)
                {
                    throw new Exception("Seleziona prima il numero di giocatori");
                }

                // Validazione input
                if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 3)
                {
                    throw new Exception("Il nome del giocatore non deve essere vuoto o più corto di 3 caratteri");
                }

                if (comboBox1.SelectedItem == null)
                {
                    throw new Exception("Devi selezionare un colore!");
                }

                // Crea il nuovo giocatore
                string nome = textBox1.Text;
                string colore = comboBox1.SelectedItem.ToString();
                Personaggio nuovoGiocatore = gestore.CreaGiocatore(nome, colore);
                // Aggiorna l'interfaccia
                listagiocatori.Items.Add($"{nome} - {colore} (ASTRONAUTA)");
                comboBox1.Items.Remove(colore);
                textBox1.Clear();

                // Verifica se è stato raggiunto il numero massimo di giocatori
                if (gestore.Giocatori.Count == gestore.NumGiocatori)
                {
                    AggiornaListaGiocatori(); // Mostra i ruoli finali
                    partitaIniziata = true;
                    AbilitaFaseGioco();
                }

                AggiornaPulsanteAggiungi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbilitaFaseGioco()
        {
            tabPage2.Enabled = true;
            tabPage3.Enabled = true;

            // Disabilita i controlli di aggiunta/rimozione giocatori
            button1.Enabled = false; // Aggiungi
            button2.Enabled = false; // Rimuovi
            textBox1.Enabled = false;
            comboBox1.Enabled = false;

            // Inizializza la mappa e le altre informazioni di gioco
            CaricaImmagini();
            carica_posizioni();
            
            try
            {
                AggiornaLBOggetti();
            }
            catch
            {
                // Ignora se non ci sono oggetti
            }

            AggiornaInv();
            AggiornaGiocatori();
            // Passa alla scheda di gioco
            tabControl1.SelectedIndex = 1;
        }
        private void AggiornaVisibilitaPulsanteUccidi()
        {
            if (gestore != null && gestore.GiocatoreAttuale != null)
            {
                // Mostra il pulsante solo se il giocatore attuale è un impostore
                buttonUccidi.Visible = gestore.GiocatoreAttuale is Impostore;
            }
            else
            {
                buttonUccidi.Visible = false;
            }
        }
        private void AggiornaVisibilitaPulsanteAccusa()
        {
            if (gestore != null && gestore.GiocatoreAttuale != null)
            {
                // Mostra il pulsante solo se il giocatore attuale è un impostore
                button8.Visible = gestore.GiocatoreAttuale is Astronauta;
            }
            else
            {
                button8.Visible = false;
            }
        }
        private void buttonRIMUOVI_GIOCATORE_Click(object sender, EventArgs e)
        {
            try
            {
                if (gestore == null)
                {
                    throw new Exception("Nessuna partita inizializzata");
                }

                if (listagiocatori.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona un giocatore dalla lista per rimuoverlo");
                }

                string nomeSelezionato = listagiocatori.SelectedItem.ToString().Split('-')[0].Trim();
                Personaggio giocatoreDaRimuovere = null;

                // Trova il giocatore da rimuovere
                foreach (Personaggio g in gestore.Giocatori)
                {
                    if (g.Nome.Equals(nomeSelezionato, StringComparison.OrdinalIgnoreCase))
                    {
                        giocatoreDaRimuovere = g;

                    }
                }

                if (giocatoreDaRimuovere == null)
                {
                    throw new Exception("Giocatore non trovato");
                }

                // Rimuovi il giocatore
                string colore = giocatoreDaRimuovere.Colore;
                gestore.EliminaGiocatore(giocatoreDaRimuovere);

                // Aggiorna l'interfaccia
                comboBox1.Items.Add(colore);
                AggiornaListaGiocatori();
                AggiornaPulsanteAggiungi();

                MessageBox.Show($"Giocatore {nomeSelezionato} rimosso");

                // Se il numero di giocatori è sceso sotto 4, reimposta la partita
                if (gestore.Giocatori.Count < 4)
                {
                    MessageBox.Show("Numero di giocatori insufficiente, la partita verrà reimpostata");
                    ResetPartita();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPartita()
        {
            // Resetta lo stato del gioco
            partitaIniziata = false;
            gestore = null;

            // Abilita nuovamente i controlli di configurazione
            comboBox2.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.Enabled = true;

            // Disabilita le tab di gioco
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;

            // Torna alla prima tab
            tabControl1.SelectedIndex = 0;

            // Ricarica i colori
            comboBox1.Items.Clear();
            foreach (string colore in ListaColori)
            {
                comboBox1.Items.Add(colore);
            }

            // Pulisci la lista giocatori
            listagiocatori.Items.Clear();
        }

        private void rilasciaOgg_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxINVENTARIO.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona un oggetto da rilasciare");
                }


                int index = listBoxINVENTARIO.SelectedIndex;

                Oggetto oggettoDaRilasciare = gestore.GiocatoreAttuale.inventario[index];
                if (oggettoDaRilasciare != null)
                {
                    // Aggiorna l'oggetto nella stanza corrente
                    Ambiente stanzaAttuale = gestore.GetMappa().GetStanza(
                        gestore.GiocatoreAttuale.PosizioneX,
                        gestore.GiocatoreAttuale.PosizioneY);

                    if (stanzaAttuale.Oggetto != null)
                    {
                        throw new Exception("C'è già un oggetto in questa stanza");
                    }

                    stanzaAttuale.Oggetto = oggettoDaRilasciare;
                    gestore.GiocatoreAttuale.inventario[index] = null;
                    listBoxINVENTARIO.Items.RemoveAt(index);

                    // Aggiorna la lista degli oggetti
                    AggiornaLBOggetti();

                    MessageBox.Show($"Hai rilasciato {oggettoDaRilasciare.Nome}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carica_posizioni()
        {
            listBox5.Items.Clear();

            if (gestore != null && gestore.GiocatoreAttuale != null)
            {
                List<Ambiente> stanzeAdiacenti = gestore.GiocatoreAttuale.StanzeAdiacenti(gestore.GetMappa());

                foreach (string direzione in gestore.GiocatoreAttuale.get_direzioni())
                {
                    listBox5.Items.Add(direzione);

                }
                gestore.GiocatoreAttuale.get_direzioni().Clear();
            }
        }

        private void prendiOgg_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona un oggetto da prendere");
                }


                Oggetto nuovoOggetto = (Oggetto)listBox1.SelectedItem;

                gestore.GiocatoreAttuale.PrendiOggetto(nuovoOggetto);
                AggiornaInv();

                // Rimuovi l'oggetto dalla stanza
                gestore.GetMappa().getStanzes()[(gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY)].Oggetto = null;
                listBox1.Items.Clear();

                MessageBox.Show($"Hai preso {nuovoOggetto.Nome}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AggiornaInv()
        {
            listBoxINVENTARIO.Items.Clear();

            if (gestore != null && gestore.GiocatoreAttuale != null)
            {
                foreach (Oggetto o in gestore.GiocatoreAttuale.inventario)
                {
                    if (o != null)
                    {
                        listBoxINVENTARIO.Items.Add(o);
                    }
                }
            }
        }

        private void CaricaImmagini()
        {
            if (gestore != null && gestore.GiocatoreAttuale != null)
            {

                pictureBoxMappa.SizeMode = PictureBoxSizeMode.StretchImage;

                try
                {
                    string percorsoImmagine = gestore.GetMappa().getStanzes()[
                        (gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY)].Immagine;
                    pictureBoxMappa.Image = Image.FromFile(percorsoImmagine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nel caricamento dell'immagine: {ex.Message}");
                }
            }
        }

        private void AggiornaLBOggetti()
        {
            listBox1.Items.Clear();

            if (gestore != null && gestore.GiocatoreAttuale != null)
            {

                Oggetto oggetto = gestore.GetMappa().getStanzes()[
                    (gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY)].Oggetto;

                if (oggetto != null)
                {
                    listBox1.Items.Add(oggetto);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) // passa turno
        {
            try
            {
                if (gestore == null)
                {
                    throw new Exception("Nessuna partita in corso");
                }

                gestore.CambiaTurno();
                
                // Aggiorna l'interfaccia
                CaricaImmagini();
                carica_posizioni();
                try
                {
                    AggiornaLBOggetti();
                }
                catch
                {
                    // Ignora se non ci sono oggetti
                }
                AggiornaInv();
                AggiornaInfoTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e) // attraversa porta
        {
            try
            {
                if (gestore == null)
                {
                    throw new Exception("Nessuna partita in corso");
                }

                if (listBox5.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona una direzione");
                }

                string direzione = (string)listBox5.SelectedItem;

                // Salva le coordinate attuali
                int vecchiaX = gestore.GiocatoreAttuale.PosizioneX;
                int vecchiaY = gestore.GiocatoreAttuale.PosizioneY;
                Personaggio p = gestore.GiocatoreAttuale;
                // Rimuovi esplicitamente il giocatore dalla stanza corrente
                gestore.GetMappa().GetStanza(vecchiaX, vecchiaY).RimuoviPersone(ref p);
                List<Personaggio> g1 = gestore.GetMappa().GetStanza(gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY).Personaggio;
                // Aggiorna le coordinate del giocatore
                gestore.GiocatoreAttuale.spostamento(direzione, gestore.GetMappa().getStanze());

                // Aggiungi esplicitamente il giocatore alla nuova stanza
                gestore.GetMappa().GetStanza(gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY).AggiungiPersone(ref p);
                List<Personaggio> g = gestore.GetMappa().GetStanza(gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY).Personaggio;
                // Verifica dello spostamento (debug)
                MessageBox.Show($"Spostamento: da ({vecchiaX},{vecchiaY}) a ({gestore.GiocatoreAttuale.PosizioneX},{gestore.GiocatoreAttuale.PosizioneY})");


                CaricaImmagini();
                carica_posizioni();
                AggiornaLBOggetti();
                AggiornaGiocatori();
                AggiornaInfoTask();

                // Passa al turno successivo
                gestore.CambiaTurno();

                // Aggiorna nuovamente l'interfaccia dopo il cambio turno
                CaricaImmagini();
                carica_posizioni();
                AggiornaLBOggetti();
                AggiornaInv();
                AggiornaGiocatori();
                AggiornaInfoTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listagiocatori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void AggiornaGiocatori()
        {
            listBox2.Items.Clear();
            foreach (Personaggio p in gestore.GetMappa().GetStanza(gestore.GiocatoreAttuale.PosizioneX, gestore.GiocatoreAttuale.PosizioneY).Personaggio)
            {
                listBox2.Items.Add(p);
            }

        }
        private void AggiornaInfoTask()
        {
            listBoxTask.Items.Clear();

            if (gestore != null && gestore.GiocatoreAttuale != null)
            {
                Task taskCorrente = gestore.GetMappa().GetStanza(
                    gestore.GiocatoreAttuale.PosizioneX,
                    gestore.GiocatoreAttuale.PosizioneY).quest;

                if (taskCorrente != null)
                {
                    listBoxTask.Items.Add("Task disponibile in questa stanza");

                    if (taskCorrente.Oggettonecessario != null)
                    {
                        listBoxTask.Items.Add($"Oggetto necessario: {taskCorrente.Oggettonecessario}");
                    }
                    else
                    {
                        listBoxTask.Items.Add("Non serve un oggetto specifico per questa task");
                    }
                }
                else
                {
                    listBoxTask.Items.Add("Nessuna task in questa stanza");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //svolgi task
        {
            try
            {
                Task taskCorrente = gestore.GetMappa().GetStanza(
                    gestore.GiocatoreAttuale.PosizioneX,
                    gestore.GiocatoreAttuale.PosizioneY).quest;

                if (taskCorrente != null)
                {
                    bool taskCompletata = false;
                    int indiceOggettoUsato = -1; // Per tenere traccia dell'indice dell'oggetto usato

                    // Se la task non richiede un oggetto
                    if (!taskCorrente.Oggettonecessario.HasValue)
                    {
                        try
                        {
                            taskCorrente.Svolgi(gestore.GiocatoreAttuale, null);
                            taskCompletata = true;
                            MessageBox.Show("Task completata con successo!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Errore nello svolgimento della task: " + ex.Message);
                        }
                    }
                    else
                    {
                        // Se la task richiede un oggetto specifico
                        oggetti oggettoRichiesto = taskCorrente.Oggettonecessario.Value;

                        // Cerca l'oggetto nell'inventario
                        bool oggettoTrovato = false;

                        for (int i = 0; i < gestore.GiocatoreAttuale.inventario.Count; i++)
                        {
                            if (gestore.GiocatoreAttuale.inventario[i] != null &&
                                gestore.GiocatoreAttuale.inventario[i].Nome == oggettoRichiesto)
                            {
                                try
                                {
                                    taskCorrente.Svolgi(gestore.GiocatoreAttuale, gestore.GiocatoreAttuale.inventario[i]);
                                    taskCompletata = true;
                                    oggettoTrovato = true;
                                    indiceOggettoUsato = i; // Salva l'indice dell'oggetto usato
                                    MessageBox.Show($"Task completata con successo usando {oggettoRichiesto}!");
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Errore nello svolgimento della task: " + ex.Message);
                                }
                            }
                        }

                        if (!oggettoTrovato)
                        {
                            throw new Exception($"Non hai l'oggetto necessario ({oggettoRichiesto}) nell'inventario.");
                        }
                    }

                    // Se la task è stata completata
                    if (taskCompletata)
                    {
                        // Se è stato usato un oggetto, rimuovilo dall'inventario
                        if (indiceOggettoUsato >= 0)
                        {
                            gestore.GiocatoreAttuale.inventario[indiceOggettoUsato] = null;
                            // Aggiorna la visualizzazione dell'inventario
                            AggiornaInv();
                        }

                        // Pulisci la quest dalla stanza
                        gestore.GetMappa().GetStanza(
                            gestore.GiocatoreAttuale.PosizioneX,
                            gestore.GiocatoreAttuale.PosizioneY).quest = null;

                        // Aggiorna la ListBox (la pulisce perché ora non c'è task)
                        AggiornaInfoTask();
                    }
                }
                else
                {
                    throw new Exception("Non c'è alcuna task in questa stanza.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                AggiornaInfoTask();
            }
            if (gestore.Controllo_vittoria_svolgimento_task() == true)
            {
                MessageBox.Show("FINE PARTITA","non ci sono più task da svolgere, gli ASTRONAUTI vincono",MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void buttonUccidi_Click(object sender, EventArgs e)
        {
            try
            {
                if (gestore == null)
                {
                    throw new Exception("Nessuna partita in corso");
                }

                if (!(gestore.GiocatoreAttuale is Impostore))
                {
                    throw new Exception("Solo gli impostori possono uccidere");
                }

                if (listBox2.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona un giocatore da uccidere");
                }

                // Ottieni la vittima selezionata
                Personaggio vittima = (Personaggio)listBox2.SelectedItem;

                // Evita che l'impostore uccida se stesso
                if (vittima == gestore.GiocatoreAttuale)
                {
                    throw new Exception("Non puoi uccidere te stesso");
                }

                // Esegui l'uccisione
                Impostore impostore = (Impostore)gestore.GiocatoreAttuale;
                impostore.Uccidi(ref vittima);
                gestore.EliminaGiocatore(vittima);
                // Aggiorna l'interfaccia
                MessageBox.Show($"Hai ucciso {vittima.Nome}!");

                // Rimuovi il giocatore dalla partita


                // Aggiorna le liste
                AggiornaGiocatori();

                // Passa al turno successivo
                gestore.CambiaTurno();

                // Aggiorna l'interfaccia
                CaricaImmagini();
                carica_posizioni();
                AggiornaLBOggetti();
                AggiornaInv();
                AggiornaGiocatori();
                AggiornaInfoTask();
                if (gestore.Controllo_vittoria_morte_astronauti() == true)
                {
                    MessageBox.Show("TERMINE PARTITA","non ci sono più astronauti, vittoria IMPOSTORI",MessageBoxButtons.OK);
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e) //Accusa
        {
            try
            {
                if (gestore == null)
                {
                    throw new Exception("Nessuna partita in corso");
                }


                if (listBox2.SelectedIndex == -1)
                {
                    throw new Exception("Seleziona un giocatore da accusare");
                }

                // Ottieni la vittima selezionata
                Personaggio vittima = (Personaggio)listBox2.SelectedItem;

                
                if (vittima == gestore.GiocatoreAttuale)
                {
                    throw new Exception("Non puoi accusare te stesso");
                }

                // Esegui l'uccisione
                Astronauta astronauta = (Astronauta)gestore.GiocatoreAttuale;
                astronauta.Accusa(ref vittima);
                if (!vittima.InVita)
                {
                    gestore.EliminaGiocatore(vittima);
                }
                else if (!gestore.GiocatoreAttuale.InVita)
                {
                    gestore.EliminaGiocatore(gestore.GiocatoreAttuale);
                }
                // Aggiorna l'interfaccia
                MessageBox.Show($"Hai accusato {vittima.Nome}!");

                


                // Aggiorna le liste
                AggiornaGiocatori();

                // Passa al turno successivo
                gestore.CambiaTurno();

                // Aggiorna l'interfaccia
                CaricaImmagini();
                carica_posizioni();
                AggiornaLBOggetti();
                AggiornaInv();
                AggiornaGiocatori();
                AggiornaInfoTask();

                if (gestore.Controllo_vittoria_morte_impostori()==true)
                {
                    MessageBox.Show("TERMINE PARTITA","non ci sono più impostori, vittoria ASTRONAUTI",MessageBoxButtons.OK);
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}