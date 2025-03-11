namespace Among_us
{
    public partial class Form1 : Form
    {

        public GestoreGioco gestore;
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i < 17; i++)
            {
                comboBox2.Items.Add(i);
            } 
        }

        
        private void buttonAGGIUNGI_GIOCATORE_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }
    }
}
