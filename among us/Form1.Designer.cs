﻿namespace Among_us
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
            tabPage3 = new TabPage();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            listBox5 = new ListBox();
            listBoxMESSAGGI = new ListBox();
            listBoxSTANZEADIACENTI = new ListBox();
            listBoxINVENTARIO = new ListBox();
            label4 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
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
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1584, 495);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "mappa";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(listBox5);
            tabPage3.Controls.Add(listBoxMESSAGGI);
            tabPage3.Controls.Add(listBoxSTANZEADIACENTI);
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
            label6.Size = new Size(229, 15);
            label6.TabIndex = 6;
            label6.Text = "NON RICORDO COSA C'ERA DA METTERE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 266);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 5;
            label5.Text = "STANZE ADIACENTI";
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
            // listBoxSTANZEADIACENTI
            // 
            listBoxSTANZEADIACENTI.FormattingEnabled = true;
            listBoxSTANZEADIACENTI.ItemHeight = 15;
            listBoxSTANZEADIACENTI.Location = new Point(26, 295);
            listBoxSTANZEADIACENTI.Margin = new Padding(3, 2, 3, 2);
            listBoxSTANZEADIACENTI.Name = "listBoxSTANZEADIACENTI";
            listBoxSTANZEADIACENTI.Size = new Size(498, 139);
            listBoxSTANZEADIACENTI.TabIndex = 2;
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
        private ListBox listBoxSTANZEADIACENTI;
        private ListBox listBoxINVENTARIO;
        private Label label4;
        private ComboBox comboBox2;
    }
}
