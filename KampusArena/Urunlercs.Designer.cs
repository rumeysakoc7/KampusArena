namespace KampusArena
{
    partial class Urunlercs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Urunlercs));
            pictureBox1 = new PictureBox();
            comboBoxKategori = new ComboBox();
            textBoxara = new TextBox();
            labelkategori = new Label();
            labelarama = new Label();
            flowLayoutPanelUrunler = new FlowLayoutPanel();
            panel1 = new Panel();
            labeldurum = new Label();
            labelfiyat = new Label();
            pictureBoxurunresim = new PictureBox();
            labelurunad = new Label();
            buttondetaylar = new Button();
            panel6 = new Panel();
            label13 = new Label();
            label14 = new Label();
            pictureBox6 = new PictureBox();
            label15 = new Label();
            button5 = new Button();
            radioButtonKiralik = new RadioButton();
            radioButtonsatilik = new RadioButton();
            buttontumunugoster = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanelUrunler.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurunresim).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 127);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.BackColor = Color.LemonChiffon;
            comboBoxKategori.ForeColor = Color.OrangeRed;
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(560, 105);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(408, 34);
            comboBoxKategori.TabIndex = 3;
            comboBoxKategori.SelectedIndexChanged += comboBoxKategori_SelectedIndexChanged;
            // 
            // textBoxara
            // 
            textBoxara.BackColor = Color.OldLace;
            textBoxara.BorderStyle = BorderStyle.FixedSingle;
            textBoxara.Location = new Point(1200, 108);
            textBoxara.Name = "textBoxara";
            textBoxara.Size = new Size(359, 30);
            textBoxara.TabIndex = 4;
            textBoxara.TextChanged += textBoxara_TextChanged;
            // 
            // labelkategori
            // 
            labelkategori.AutoSize = true;
            labelkategori.ForeColor = Color.OrangeRed;
            labelkategori.Location = new Point(556, 76);
            labelkategori.Name = "labelkategori";
            labelkategori.Size = new Size(142, 26);
            labelkategori.TabIndex = 5;
            labelkategori.Text = "KATEGORİLER";
            // 
            // labelarama
            // 
            labelarama.AutoSize = true;
            labelarama.ForeColor = Color.OrangeRed;
            labelarama.Location = new Point(1091, 113);
            labelarama.Name = "labelarama";
            labelarama.Size = new Size(103, 26);
            labelarama.TabIndex = 6;
            labelarama.Text = "ARA... 🔍 ";
            // 
            // flowLayoutPanelUrunler
            // 
            flowLayoutPanelUrunler.AutoScroll = true;
            flowLayoutPanelUrunler.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelUrunler.CausesValidation = false;
            flowLayoutPanelUrunler.Controls.Add(panel1);
            flowLayoutPanelUrunler.Controls.Add(panel6);
            flowLayoutPanelUrunler.Location = new Point(47, 211);
            flowLayoutPanelUrunler.Name = "flowLayoutPanelUrunler";
            flowLayoutPanelUrunler.Size = new Size(1589, 769);
            flowLayoutPanelUrunler.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labeldurum);
            panel1.Controls.Add(labelfiyat);
            panel1.Controls.Add(pictureBoxurunresim);
            panel1.Controls.Add(labelurunad);
            panel1.Controls.Add(buttondetaylar);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(306, 320);
            panel1.TabIndex = 0;
            // 
            // labeldurum
            // 
            labeldurum.AutoSize = true;
            labeldurum.ForeColor = Color.OrangeRed;
            labeldurum.Location = new Point(3, 208);
            labeldurum.Name = "labeldurum";
            labeldurum.Size = new Size(146, 26);
            labeldurum.TabIndex = 11;
            labeldurum.Text = "Kiralık/Satılık:";
            // 
            // labelfiyat
            // 
            labelfiyat.AutoSize = true;
            labelfiyat.ForeColor = Color.OrangeRed;
            labelfiyat.Location = new Point(86, 182);
            labelfiyat.Name = "labelfiyat";
            labelfiyat.Size = new Size(63, 26);
            labelfiyat.TabIndex = 10;
            labelfiyat.Text = "Fiyat:";
            // 
            // pictureBoxurunresim
            // 
            pictureBoxurunresim.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxurunresim.Location = new Point(73, 17);
            pictureBoxurunresim.Name = "pictureBoxurunresim";
            pictureBoxurunresim.Size = new Size(150, 104);
            pictureBoxurunresim.TabIndex = 1;
            pictureBoxurunresim.TabStop = false;
            // 
            // labelurunad
            // 
            labelurunad.AutoSize = true;
            labelurunad.ForeColor = Color.OrangeRed;
            labelurunad.Location = new Point(50, 156);
            labelurunad.Name = "labelurunad";
            labelurunad.Size = new Size(99, 26);
            labelurunad.TabIndex = 8;
            labelurunad.Text = "Ürün Adı:";
            // 
            // buttondetaylar
            // 
            buttondetaylar.FlatStyle = FlatStyle.Flat;
            buttondetaylar.ForeColor = Color.Coral;
            buttondetaylar.Location = new Point(173, 266);
            buttondetaylar.Name = "buttondetaylar";
            buttondetaylar.Size = new Size(119, 38);
            buttondetaylar.TabIndex = 9;
            buttondetaylar.Text = "Detaylar...";
            buttondetaylar.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label13);
            panel6.Controls.Add(label14);
            panel6.Controls.Add(pictureBox6);
            panel6.Controls.Add(label15);
            panel6.Controls.Add(button5);
            panel6.Location = new Point(315, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(306, 320);
            panel6.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.OrangeRed;
            label13.Location = new Point(3, 208);
            label13.Name = "label13";
            label13.Size = new Size(146, 26);
            label13.TabIndex = 11;
            label13.Text = "Kiralık/Satılık:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.OrangeRed;
            label14.Location = new Point(86, 182);
            label14.Name = "label14";
            label14.Size = new Size(63, 26);
            label14.TabIndex = 10;
            label14.Text = "Fiyat:";
            // 
            // pictureBox6
            // 
            pictureBox6.BorderStyle = BorderStyle.FixedSingle;
            pictureBox6.Location = new Point(73, 17);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(150, 104);
            pictureBox6.TabIndex = 1;
            pictureBox6.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.OrangeRed;
            label15.Location = new Point(50, 156);
            label15.Name = "label15";
            label15.Size = new Size(99, 26);
            label15.TabIndex = 8;
            label15.Text = "Ürün Adı:";
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.Coral;
            button5.Location = new Point(173, 266);
            button5.Name = "button5";
            button5.Size = new Size(119, 38);
            button5.TabIndex = 9;
            button5.Text = "Detaylar...";
            button5.UseVisualStyleBackColor = true;
            // 
            // radioButtonKiralik
            // 
            radioButtonKiralik.AutoSize = true;
            radioButtonKiralik.ForeColor = Color.OrangeRed;
            radioButtonKiralik.Location = new Point(332, 111);
            radioButtonKiralik.Name = "radioButtonKiralik";
            radioButtonKiralik.Size = new Size(109, 30);
            radioButtonKiralik.TabIndex = 9;
            radioButtonKiralik.TabStop = true;
            radioButtonKiralik.Text = "KİRALIK";
            radioButtonKiralik.UseVisualStyleBackColor = true;
            radioButtonKiralik.CheckedChanged += radioButtonKiralik_CheckedChanged_1;
            // 
            // radioButtonsatilik
            // 
            radioButtonsatilik.AutoSize = true;
            radioButtonsatilik.ForeColor = Color.OrangeRed;
            radioButtonsatilik.Location = new Point(201, 111);
            radioButtonsatilik.Name = "radioButtonsatilik";
            radioButtonsatilik.Size = new Size(105, 30);
            radioButtonsatilik.TabIndex = 8;
            radioButtonsatilik.TabStop = true;
            radioButtonsatilik.Text = "SATILIK";
            radioButtonsatilik.UseVisualStyleBackColor = true;
            radioButtonsatilik.CheckedChanged += radioButtonsatilik_CheckedChanged_1;
            // 
            // buttontumunugoster
            // 
            buttontumunugoster.FlatStyle = FlatStyle.Flat;
            buttontumunugoster.ForeColor = Color.Coral;
            buttontumunugoster.Location = new Point(201, 76);
            buttontumunugoster.Name = "buttontumunugoster";
            buttontumunugoster.Size = new Size(226, 38);
            buttontumunugoster.TabIndex = 12;
            buttontumunugoster.Text = "TÜMÜNÜ GÖSTER";
            buttontumunugoster.UseVisualStyleBackColor = true;
            buttontumunugoster.Click += buttontumunugoster_Click;
            // 
            // Urunlercs
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1706, 1055);
            Controls.Add(buttontumunugoster);
            Controls.Add(radioButtonKiralik);
            Controls.Add(radioButtonsatilik);
            Controls.Add(flowLayoutPanelUrunler);
            Controls.Add(labelarama);
            Controls.Add(labelkategori);
            Controls.Add(textBoxara);
            Controls.Add(comboBoxKategori);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Urunlercs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Urunlercs";
            WindowState = FormWindowState.Maximized;
            Load += Urunlercs_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanelUrunler.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurunresim).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBoxKategori;
        private TextBox textBoxara;
        private Label labelkategori;
        private Label labelarama;
        private FlowLayoutPanel flowLayoutPanelUrunler;
        private Panel panel1;
        private PictureBox pictureBoxurunresim;
        private Label labelurunad;
        private Button buttondetaylar;
        private Label labeldurum;
        private Label labelfiyat;
        private Panel panel6;
        private Label label13;
        private Label label14;
        private PictureBox pictureBox6;
        private Label label15;
        private Button button5;
        private RadioButton radioButtonKiralik;
        private RadioButton radioButtonsatilik;
        private Button buttontumunugoster;
    }
}