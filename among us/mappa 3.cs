using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Among_us
{
    public class Mappa_3 : Mappa
    {
        public override int[,] disegnaMappa()
        {
            int[,] mappa =
            {
            {1, 0, 1, 1, 1, 1, 1},
            {1, 0, 2, 0, 0, 0, 1},
            {1, 0, 1, 1, 2, 0, 1},
            {1, 0, 0, 0, 1, 2, 0},
            {1, 2, 1, 0, 0, 1, 0},
            {1, 1, 1, 1, 1, 0, 0},
            };
            return mappa;
        }
       
        private static Random rnd = new Random();
        private static List<oggetti> strumenti = Enum.GetValues(typeof(oggetti)).Cast<oggetti>().ToList();
       
        public Mappa_3()
        {
            Map = disegnaMappa(); 
            CollegaBotole();
            InizializzaAmbienti();

        }

        private void InizializzaAmbienti()
        {
            ambienti[(0, 1)] = new Ambiente(Ambienti.SalaComando, "Ti trovi in sala di comando, il centro nevralgico dell’astronave. Vedi tante console luminose, schermi olografici ed una grande vetrata che si affaccia sullo spazio infinito.", "sala_comando.png", new Task(true, oggetti.attrezzo_multiuso), generazione_casuale_oggetti());
            ambienti[(1, 1)] = new Ambiente(Ambienti.SalaMotore, "Sei dentro una enorme stanza pulsante di energia, con turbine a fusione e cavi ad alta tensione che serpeggiano ovunque. Il calore e il ronzio delle macchine rendono l’ambiente quasi opprimente.", "sala_motore.png", new Task(false, null), generazione_casuale_oggetti());
            ambienti[(1, 2)] = new Ambiente(Ambienti.Cucina, "Un piccolo spazio con fornelli magnetici e distributori automatici. L’odore di cibo sintetico riempie l’aria.", "cucina.png", new Task(true, oggetti.tessera_di_accesso), generazione_casuale_oggetti());
            ambienti[(1, 3)] = new Ambiente(Ambienti.Magazzino, "Scaffali pieni di attrezzi, pezzi di ricambio e provviste per il viaggio spaziale. Alcune casse sono aperte.", "magazzino.png", new Task(true, oggetti.tubo_di_ricambio), generazione_casuale_oggetti());
            ambienti[(1, 4)] = new Ambiente(Ambienti.Armeria, "Racks di fucili al plasma e munizioni laser. L’area è sorvegliata da un drone di sicurezza.", "armeria.png", null, generazione_casuale_oggetti());
            ambienti[(1, 5)] = new Ambiente(Ambienti.Palestra, "Ti trovi nella palestra, uno spazio compatto ma tecnologicamente avanzato, progettato per mantenere l’equipaggio in forma durante i lunghi viaggi nello spazio. L’odore leggero di sudore si mescola al ronzio dei sistemi di ventilazione.", "palestra.png", new Task(true, oggetti.motore_elettrico), generazione_casuale_oggetti());
            ambienti[(2, 1)] = new Ambiente(Ambienti.Infermeria, "Letti bianchi e monitor di controllo vitale. Un robot medico è inattivo.", "infermeria.png", new Task(true, oggetti.batteria), generazione_casuale_oggetti());
            ambienti[(2, 4)] = new Ambiente(Ambienti.TunnelManutenzione, "Un lungo corridoio con tubature e fili elettrici scoperti. L’ambiente è stretto e angusto.", "tunnel_di_manutenzione.png", new Task(true, oggetti.fusibile), generazione_casuale_oggetti());
            ambienti[(2, 5)] = new Ambiente(Ambienti.SalaRadar, "Un monitor mostra il movimento di corpi celesti vicini. Un’antenna sembra fuori uso.", "sala_radar.png", new Task(false, null), generazione_casuale_oggetti());
            ambienti[(3, 1)] = new Ambiente(Ambienti.CentroComunicazioni, "Schermi con segnali radio provenienti da tutta la galassia. Un’interferenza disturba la trasmissione.", "centro_comunicazioni.png", new Task(true, oggetti.scheda_di_rete), generazione_casuale_oggetti());
            ambienti[(3, 2)] = new Ambiente(Ambienti.DepositoCarburante, "Un serbatoio gigante contiene il carburante per i motori. Un sensore segnala una perdita.", "stanza_carburante.png", new Task(false, null));
            ambienti[(3, 3)] = new Ambiente(Ambienti.Criocamere, "Capsule di ibernazione allineate lungo la parete. Alcune sembrano inattive.", "sala_criocamere.png", new Task(true, oggetti.chiave_magnetica), generazione_casuale_oggetti());
            ambienti[(3, 5)] = new Ambiente(Ambienti.Serre, "Un piccolo ecosistema con piante per produrre ossigeno e cibo fresco. La temperatura è più alta qui.", "sala_serre.png", new Task(true, oggetti.filtro_acqua), generazione_casuale_oggetti());
            ambienti[(3, 6)] = new Ambiente(Ambienti.Dormitorio1, "Sei nel dormitorio ovest, vedi tante piccole cabine con letti a castello, armadietti personali e foto olografiche di casa. Alcune stanze sembrano abbandonate in tutta fretta.", "dormitorio_1.png", null, generazione_casuale_oggetti());
            ambienti[(4, 1)] = new Ambiente(Ambienti.BaiaAttracco, "Un portellone di carico permette l’aggancio di navette. Un meccanismo idraulico sembra bloccato.", "baia_di_attracco.png", new Task(true, oggetti.bombola_aria), generazione_casuale_oggetti());
            ambienti[(4, 3)] = new Ambiente(Ambienti.CameraDecompressione, "Uno spazio tra la nave e il vuoto cosmico, necessario per le uscite extraveicolari.", "camera_di_decompressione.png", new Task(true, oggetti.casco_di_ricambio), generazione_casuale_oggetti());
            ambienti[(4, 4)] = new Ambiente(Ambienti.Dormitorio2, "Sei nel dormitorio est, vedi tante piccole cabine con letti a castello, armadietti personali e foto olografiche di casa. Alcune stanze sembrano abbandonate in tutta fretta.", "dormitorio_2.png", new Task(true, oggetti.materasso_nuovo), generazione_casuale_oggetti());
            ambienti[(4, 6)] = new Ambiente(Ambienti.Laboratorio, "Laboratorio… tavoli ingombri di provette e strumenti avanzati, con esperimenti in corso e campioni alieni conservati in cilindri di vetro. Uno schermo mostra dati misteriosi.", "laboratorio.png", null, generazione_casuale_oggetti());
            ambienti[(5, 5)] = new Ambiente(Ambienti.PonteOsservazione, "Una grande finestra panoramica offre una vista spettacolare delle stelle. Qualche sedia è ribaltata.", "pannello_di_osservazione.png", new Task(true, oggetti.attrezzo_multiuso), generazione_casuale_oggetti());
            ambienti[(5, 6)] = new Ambiente(Ambienti.Stiva, "Contenitori di rifornimenti sono sparsi in giro. Una parte del pavimento sembra danneggiata.", "stiva.png", new Task(true, oggetti.saldatrice));
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

        public Ambiente? GetStanza(int x, int y)    //ritorna la posizione della stanza nella mappa
        {
            ambienti.TryGetValue((x, y), out Ambiente stanza);
            return stanza;
        }
    }
}

