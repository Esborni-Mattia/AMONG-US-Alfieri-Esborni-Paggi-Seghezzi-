namespace Among_us
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            comboBox2 = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            listagiocatori = new ListBox();
            tabPage2 = new TabPage();
            pictureBoxMappa = new PictureBox();
            tabPage3 = new TabPage();
            button8 = new Button();
            buttonUccidi = new Button();
            label9 = new Label();
            listBox2 = new ListBox();
            label8 = new Label();
            listBox1 = new ListBox();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            listBox5 = new ListBox();
            listBoxMESSAGGI = new ListBox();
            listBoxTask = new ListBox();
            listBoxINVENTARIO = new ListBox();
            label4 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMappa).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(10, 9);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1592, 523);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(listagiocatori);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1584, 495);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Inizializzazione";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(697, 56);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(188, 23);
            comboBox2.TabIndex = 9;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(893, 308);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(107, 43);
            button2.TabIndex = 8;
            button2.Text = "ELIMINA";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonRIMUOVI_GIOCATORE_Click;
            // 
            // button1
            // 
            button1.Location = new Point(893, 249);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(107, 43);
            button1.TabIndex = 7;
            button1.Text = "AGGIUNGI";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonAGGIUNGI_GIOCATORE_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(568, 56);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 6;
            label3.Text = "NUM GIOCATORI";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(146, 127);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(226, 23);
            comboBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 129);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "COLORE";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(146, 51);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 51);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "NOME";
            // 
            // listagiocatori
            // 
            listagiocatori.FormattingEnabled = true;
            listagiocatori.ItemHeight = 15;
            listagiocatori.Location = new Point(1060, 7);
            listagiocatori.Margin = new Padding(3, 2, 3, 2);
            listagiocatori.Name = "listagiocatori";
            listagiocatori.Size = new Size(520, 484);
            listagiocatori.TabIndex = 0;
            listagiocatori.SelectedIndexChanged += listagiocatori_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pictureBoxMappa);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1584, 495);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "mappa";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // pictureBoxMappa
            // 
            pictureBoxMappa.Location = new Point(223, 56);
            pictureBoxMappa.Margin = new Padding(3, 2, 3, 2);
            pictureBoxMappa.Name = "pictureBoxMappa";
            pictureBoxMappa.Size = new Size(808, 424);
            pictureBoxMappa.TabIndex = 0;
            pictureBoxMappa.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button8);
            tabPage3.Controls.Add(buttonUccidi);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(listBox2);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(listBox1);
            tabPage3.Controls.Add(button7);
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(listBox5);
            tabPage3.Controls.Add(listBoxMESSAGGI);
            tabPage3.Controls.Add(listBoxTask);
            tabPage3.Controls.Add(listBoxINVENTARIO);
            tabPage3.Controls.Add(label4);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1584, 495);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "informazioni";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(1466, 386);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(82, 22);
            button8.TabIndex = 18;
            button8.Text = "Accusa";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // buttonUccidi
            // 
            buttonUccidi.Location = new Point(1466, 386);
            buttonUccidi.Margin = new Padding(3, 2, 3, 2);
            buttonUccidi.Name = "buttonUccidi";
            buttonUccidi.Size = new Size(82, 22);
            buttonUccidi.TabIndex = 17;
            buttonUccidi.Text = "Uccidi";
            buttonUccidi.UseVisualStyleBackColor = true;
            buttonUccidi.Click += buttonUccidi_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1267, 212);
            label9.Name = "label9";
            label9.Size = new Size(91, 15);
            label9.TabIndex = 16;
            label9.Text = "Giocatori stanza";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(1267, 229);
            listBox2.Margin = new Padding(3, 2, 3, 2);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(296, 94);
            listBox2.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1028, 212);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 14;
            label8.Text = "OGGETTI";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(1028, 229);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(175, 94);
            listBox1.TabIndex = 13;
            // 
            // button7
            // 
            button7.Location = new Point(1325, 412);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(82, 22);
            button7.TabIndex = 12;
            button7.Text = "Usa Porta";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1325, 386);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(82, 22);
            button6.TabIndex = 11;
            button6.Text = "Passa Turno";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1325, 349);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(82, 22);
            button5.TabIndex = 10;
            button5.Text = "Fai Task";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1140, 411);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(144, 22);
            button4.TabIndex = 9;
            button4.Text = "Rilascia Oggetto";
            button4.UseVisualStyleBackColor = true;
            button4.Click += rilasciaOgg_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1140, 349);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(144, 22);
            button3.TabIndex = 8;
            button3.Text = "Raccogli Oggetto";
            button3.UseVisualStyleBackColor = true;
            button3.Click += prendiOgg_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(752, 38);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 7;
            label7.Text = "MESSAGGI";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(701, 266);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 6;
            label6.Text = "POSIZIONI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 266);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 5;
            label5.Text = "TASK";
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 15;
            listBox5.Location = new Point(646, 295);
            listBox5.Margin = new Padding(3, 2, 3, 2);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(344, 139);
            listBox5.TabIndex = 4;
            // 
            // listBoxMESSAGGI
            // 
            listBoxMESSAGGI.FormattingEnabled = true;
            listBoxMESSAGGI.ItemHeight = 15;
            listBoxMESSAGGI.Location = new Point(646, 55);
            listBoxMESSAGGI.Margin = new Padding(3, 2, 3, 2);
            listBoxMESSAGGI.Name = "listBoxMESSAGGI";
            listBoxMESSAGGI.Size = new Size(828, 139);
            listBoxMESSAGGI.TabIndex = 3;
            // 
            // listBoxTask
            // 
            listBoxTask.FormattingEnabled = true;
            listBoxTask.ItemHeight = 15;
            listBoxTask.Location = new Point(26, 295);
            listBoxTask.Margin = new Padding(3, 2, 3, 2);
            listBoxTask.Name = "listBoxTask";
            listBoxTask.Size = new Size(498, 139);
            listBoxTask.TabIndex = 2;
            // 
            // listBoxINVENTARIO
            // 
            listBoxINVENTARIO.FormattingEnabled = true;
            listBoxINVENTARIO.ItemHeight = 15;
            listBoxINVENTARIO.Location = new Point(26, 67);
            listBoxINVENTARIO.Margin = new Padding(3, 2, 3, 2);
            listBoxINVENTARIO.Name = "listBoxINVENTARIO";
            listBoxINVENTARIO.Size = new Size(498, 139);
            listBoxINVENTARIO.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(104, 38);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 0;
            label4.Text = "INVENTARIO";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1608, 535);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Among Us";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMappa).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox textBox1;
        private Label label1;
        private ListBox listagiocatori;
        private ComboBox comboBox1;
        private Label label2;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private ListBox listBox5;
        private ListBox listBoxMESSAGGI;
        private ListBox listBoxTask;
        private ListBox listBoxINVENTARIO;
        private Label label4;
        private ComboBox comboBox2;
        private PictureBox pictureBoxMappa;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button7;
        private Button button6;
        private Label label8;
        private ListBox listBox1;
        private Label label9;
        private ListBox listBox2;
        private Button buttonUccidi;
        private Button button8;
    }
}
