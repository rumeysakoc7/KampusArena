namespace KampusArena
{
    partial class Kategoriler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kategoriler));
            pictureBox1 = new PictureBox();
            dataGridViewkategori = new DataGridView();
            panelkategori = new Panel();
            labelKategoribilgi = new Label();
            labelaciklama = new Label();
            textBoxaciklama = new TextBox();
            buttontemizle = new Button();
            buttonGuncelle = new Button();
            buttonSil = new Button();
            buttonekle = new Button();
            labelkategoriad = new Label();
            textBoxkategoriad = new TextBox();
            radioButtonaktif = new RadioButton();
            radioButtonpasif = new RadioButton();
            labelarama = new Label();
            textBoxara = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewkategori).BeginInit();
            panelkategori.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(28, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewkategori
            // 
            dataGridViewkategori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewkategori.Location = new Point(28, 233);
            dataGridViewkategori.Name = "dataGridViewkategori";
            dataGridViewkategori.RowHeadersWidth = 51;
            dataGridViewkategori.Size = new Size(998, 561);
            dataGridViewkategori.TabIndex = 1;
            dataGridViewkategori.CellClick += dataGridViewkategori_CellClick;
            // 
            // panelkategori
            // 
            panelkategori.BorderStyle = BorderStyle.FixedSingle;
            panelkategori.Controls.Add(labelKategoribilgi);
            panelkategori.Controls.Add(labelaciklama);
            panelkategori.Controls.Add(textBoxaciklama);
            panelkategori.Controls.Add(buttontemizle);
            panelkategori.Controls.Add(buttonGuncelle);
            panelkategori.Controls.Add(buttonSil);
            panelkategori.Controls.Add(buttonekle);
            panelkategori.Controls.Add(labelkategoriad);
            panelkategori.Controls.Add(textBoxkategoriad);
            panelkategori.Location = new Point(1083, 299);
            panelkategori.Name = "panelkategori";
            panelkategori.Size = new Size(596, 423);
            panelkategori.TabIndex = 2;
            // 
            // labelKategoribilgi
            // 
            labelKategoribilgi.AutoSize = true;
            labelKategoribilgi.ForeColor = Color.OrangeRed;
            labelKategoribilgi.Location = new Point(3, 17);
            labelKategoribilgi.Name = "labelKategoribilgi";
            labelKategoribilgi.Size = new Size(204, 26);
            labelKategoribilgi.TabIndex = 8;
            labelKategoribilgi.Text = "KATEGORİ BİLGİLERİ";
            // 
            // labelaciklama
            // 
            labelaciklama.AutoSize = true;
            labelaciklama.ForeColor = Color.OrangeRed;
            labelaciklama.Location = new Point(47, 147);
            labelaciklama.Name = "labelaciklama";
            labelaciklama.Size = new Size(114, 26);
            labelaciklama.TabIndex = 7;
            labelaciklama.Text = "AÇIKLAMA:";
            // 
            // textBoxaciklama
            // 
            textBoxaciklama.BackColor = Color.OldLace;
            textBoxaciklama.BorderStyle = BorderStyle.FixedSingle;
            textBoxaciklama.Location = new Point(174, 143);
            textBoxaciklama.Name = "textBoxaciklama";
            textBoxaciklama.Size = new Size(391, 30);
            textBoxaciklama.TabIndex = 6;
            // 
            // buttontemizle
            // 
            buttontemizle.FlatStyle = FlatStyle.Flat;
            buttontemizle.ForeColor = Color.OrangeRed;
            buttontemizle.Location = new Point(405, 278);
            buttontemizle.Name = "buttontemizle";
            buttontemizle.Size = new Size(160, 46);
            buttontemizle.TabIndex = 5;
            buttontemizle.Text = "TEMİZLE";
            buttontemizle.UseVisualStyleBackColor = true;
            buttontemizle.Click += buttontemizle_Click;
            // 
            // buttonGuncelle
            // 
            buttonGuncelle.FlatStyle = FlatStyle.Flat;
            buttonGuncelle.ForeColor = Color.OrangeRed;
            buttonGuncelle.Location = new Point(174, 278);
            buttonGuncelle.Name = "buttonGuncelle";
            buttonGuncelle.Size = new Size(183, 46);
            buttonGuncelle.TabIndex = 4;
            buttonGuncelle.Text = "GÜNCELLE";
            buttonGuncelle.UseVisualStyleBackColor = true;
            buttonGuncelle.Click += buttonGuncelle_Click;
            // 
            // buttonSil
            // 
            buttonSil.FlatStyle = FlatStyle.Flat;
            buttonSil.ForeColor = Color.OrangeRed;
            buttonSil.Location = new Point(405, 202);
            buttonSil.Name = "buttonSil";
            buttonSil.Size = new Size(160, 46);
            buttonSil.TabIndex = 3;
            buttonSil.Text = "SİL";
            buttonSil.UseVisualStyleBackColor = true;
            buttonSil.Click += buttonSil_Click;
            // 
            // buttonekle
            // 
            buttonekle.FlatStyle = FlatStyle.Flat;
            buttonekle.ForeColor = Color.OrangeRed;
            buttonekle.Location = new Point(174, 202);
            buttonekle.Name = "buttonekle";
            buttonekle.Size = new Size(183, 46);
            buttonekle.TabIndex = 2;
            buttonekle.Text = "EKLE";
            buttonekle.UseVisualStyleBackColor = true;
            buttonekle.Click += buttonekle_Click;
            // 
            // labelkategoriad
            // 
            labelkategoriad.AutoSize = true;
            labelkategoriad.ForeColor = Color.OrangeRed;
            labelkategoriad.Location = new Point(11, 93);
            labelkategoriad.Name = "labelkategoriad";
            labelkategoriad.Size = new Size(150, 26);
            labelkategoriad.TabIndex = 1;
            labelkategoriad.Text = "KATEGORİ ADI:";
            // 
            // textBoxkategoriad
            // 
            textBoxkategoriad.BackColor = Color.OldLace;
            textBoxkategoriad.BorderStyle = BorderStyle.FixedSingle;
            textBoxkategoriad.Location = new Point(174, 89);
            textBoxkategoriad.Name = "textBoxkategoriad";
            textBoxkategoriad.Size = new Size(391, 30);
            textBoxkategoriad.TabIndex = 0;
            // 
            // radioButtonaktif
            // 
            radioButtonaktif.AutoSize = true;
            radioButtonaktif.ForeColor = Color.OrangeRed;
            radioButtonaktif.Location = new Point(810, 197);
            radioButtonaktif.Name = "radioButtonaktif";
            radioButtonaktif.Size = new Size(88, 30);
            radioButtonaktif.TabIndex = 3;
            radioButtonaktif.TabStop = true;
            radioButtonaktif.Text = "AKTİF";
            radioButtonaktif.UseVisualStyleBackColor = true;
            radioButtonaktif.CheckedChanged += radioButtonaktif_CheckedChanged;
            // 
            // radioButtonpasif
            // 
            radioButtonpasif.AutoSize = true;
            radioButtonpasif.ForeColor = Color.OrangeRed;
            radioButtonpasif.Location = new Point(904, 197);
            radioButtonpasif.Name = "radioButtonpasif";
            radioButtonpasif.Size = new Size(84, 30);
            radioButtonpasif.TabIndex = 4;
            radioButtonpasif.TabStop = true;
            radioButtonpasif.Text = "PASİF";
            radioButtonpasif.UseVisualStyleBackColor = true;
            radioButtonpasif.CheckedChanged += radioButtonpasif_CheckedChanged;
            // 
            // labelarama
            // 
            labelarama.AutoSize = true;
            labelarama.ForeColor = Color.OrangeRed;
            labelarama.Location = new Point(1084, 252);
            labelarama.Name = "labelarama";
            labelarama.Size = new Size(103, 26);
            labelarama.TabIndex = 8;
            labelarama.Text = "ARA... 🔍 ";
            // 
            // textBoxara
            // 
            textBoxara.BackColor = Color.OldLace;
            textBoxara.BorderStyle = BorderStyle.FixedSingle;
            textBoxara.Location = new Point(1193, 248);
            textBoxara.Name = "textBoxara";
            textBoxara.Size = new Size(359, 30);
            textBoxara.TabIndex = 9;
            textBoxara.TextChanged += textBoxara_TextChanged_1;
            // 
            // Kategoriler
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1827, 887);
            Controls.Add(textBoxara);
            Controls.Add(labelarama);
            Controls.Add(radioButtonpasif);
            Controls.Add(radioButtonaktif);
            Controls.Add(panelkategori);
            Controls.Add(dataGridViewkategori);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Kategoriler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategoriler";
            WindowState = FormWindowState.Maximized;
            Load += Kategoriler_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewkategori).EndInit();
            panelkategori.ResumeLayout(false);
            panelkategori.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewkategori;
        private Panel panelkategori;
        private Label labelaciklama;
        private TextBox textBoxaciklama;
        private Button buttontemizle;
        private Button buttonGuncelle;
        private Button buttonSil;
        private Button buttonekle;
        private Label labelkategoriad;
        private TextBox textBoxkategoriad;
        private RadioButton radioButtonaktif;
        private RadioButton radioButtonpasif;
        private Label labelKategoribilgi;
        private Label labelarama;
        private TextBox textBoxara;
    }
}