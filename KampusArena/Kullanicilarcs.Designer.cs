namespace KampusArena
{
    partial class Kullanicilarcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kullanicilarcs));
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            labeliban = new Label();
            maskedTextBoxiban = new MaskedTextBox();
            labelkullanicibilgi = new Label();
            labelkullaniciTip = new Label();
            comboBoxKullanicitip = new ComboBox();
            buttonguncelle = new Button();
            buttonTemizle = new Button();
            buttonsil = new Button();
            maskedTextBoxtelnmo = new MaskedTextBox();
            labeltelno = new Label();
            textBoxsifre = new TextBox();
            labelsifre = new Label();
            textBoxmail = new TextBox();
            labelMail = new Label();
            textBoxsoyad = new TextBox();
            labelSoyad = new Label();
            buttonEkle = new Button();
            textBoxad = new TextBox();
            labeladi = new Label();
            radioButtonaktif = new RadioButton();
            radioButtonpasif = new RadioButton();
            textBoxara = new TextBox();
            labelarama = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 22);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 182);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1343, 665);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labeliban);
            panel1.Controls.Add(maskedTextBoxiban);
            panel1.Controls.Add(labelkullanicibilgi);
            panel1.Controls.Add(labelkullaniciTip);
            panel1.Controls.Add(comboBoxKullanicitip);
            panel1.Controls.Add(buttonguncelle);
            panel1.Controls.Add(buttonTemizle);
            panel1.Controls.Add(buttonsil);
            panel1.Controls.Add(maskedTextBoxtelnmo);
            panel1.Controls.Add(labeltelno);
            panel1.Controls.Add(textBoxsifre);
            panel1.Controls.Add(labelsifre);
            panel1.Controls.Add(textBoxmail);
            panel1.Controls.Add(labelMail);
            panel1.Controls.Add(textBoxsoyad);
            panel1.Controls.Add(labelSoyad);
            panel1.Controls.Add(buttonEkle);
            panel1.Controls.Add(textBoxad);
            panel1.Controls.Add(labeladi);
            panel1.Location = new Point(1395, 211);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 545);
            panel1.TabIndex = 2;
            // 
            // labeliban
            // 
            labeliban.AutoSize = true;
            labeliban.ForeColor = Color.OrangeRed;
            labeliban.Location = new Point(67, 284);
            labeliban.Margin = new Padding(4, 0, 4, 0);
            labeliban.Name = "labeliban";
            labeliban.Size = new Size(64, 26);
            labeliban.TabIndex = 19;
            labeliban.Text = "IBAN:";
            // 
            // maskedTextBoxiban
            // 
            maskedTextBoxiban.BackColor = Color.OldLace;
            maskedTextBoxiban.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxiban.Location = new Point(146, 280);
            maskedTextBoxiban.Margin = new Padding(4);
            maskedTextBoxiban.Mask = ">TR00 0000 0000 0000 0000 0000 00";
            maskedTextBoxiban.Name = "maskedTextBoxiban";
            maskedTextBoxiban.Size = new Size(305, 30);
            maskedTextBoxiban.TabIndex = 18;
            // 
            // labelkullanicibilgi
            // 
            labelkullanicibilgi.AutoSize = true;
            labelkullanicibilgi.Location = new Point(3, -1);
            labelkullanicibilgi.Name = "labelkullanicibilgi";
            labelkullanicibilgi.Size = new Size(210, 26);
            labelkullanicibilgi.TabIndex = 14;
            labelkullanicibilgi.Text = "KULLANICI BİLGİLERİ";
            // 
            // labelkullaniciTip
            // 
            labelkullaniciTip.AutoSize = true;
            labelkullaniciTip.ForeColor = Color.OrangeRed;
            labelkullaniciTip.Location = new Point(40, 340);
            labelkullaniciTip.Name = "labelkullaniciTip";
            labelkullaniciTip.Size = new Size(161, 26);
            labelkullaniciTip.TabIndex = 15;
            labelkullaniciTip.Text = "KULLANICI TİPİ:";
            // 
            // comboBoxKullanicitip
            // 
            comboBoxKullanicitip.BackColor = Color.OldLace;
            comboBoxKullanicitip.FormattingEnabled = true;
            comboBoxKullanicitip.Items.AddRange(new object[] { "Öğrenci", "Akademisyen", "Personel ", "Admin" });
            comboBoxKullanicitip.Location = new Point(207, 337);
            comboBoxKullanicitip.Name = "comboBoxKullanicitip";
            comboBoxKullanicitip.Size = new Size(244, 34);
            comboBoxKullanicitip.TabIndex = 14;
            // 
            // buttonguncelle
            // 
            buttonguncelle.FlatStyle = FlatStyle.Flat;
            buttonguncelle.ForeColor = Color.OrangeRed;
            buttonguncelle.Location = new Point(86, 468);
            buttonguncelle.Name = "buttonguncelle";
            buttonguncelle.Size = new Size(168, 45);
            buttonguncelle.TabIndex = 13;
            buttonguncelle.Text = "GÜNCELLE";
            buttonguncelle.UseVisualStyleBackColor = true;
            buttonguncelle.Click += buttonguncelle_Click;
            // 
            // buttonTemizle
            // 
            buttonTemizle.FlatStyle = FlatStyle.Flat;
            buttonTemizle.ForeColor = Color.OrangeRed;
            buttonTemizle.Location = new Point(271, 468);
            buttonTemizle.Name = "buttonTemizle";
            buttonTemizle.Size = new Size(168, 45);
            buttonTemizle.TabIndex = 12;
            buttonTemizle.Text = "TEMİZLE";
            buttonTemizle.UseVisualStyleBackColor = true;
            buttonTemizle.Click += buttonTemizle_Click;
            // 
            // buttonsil
            // 
            buttonsil.FlatStyle = FlatStyle.Flat;
            buttonsil.ForeColor = Color.OrangeRed;
            buttonsil.Location = new Point(271, 419);
            buttonsil.Name = "buttonsil";
            buttonsil.Size = new Size(168, 43);
            buttonsil.TabIndex = 11;
            buttonsil.Text = "SİL";
            buttonsil.UseVisualStyleBackColor = true;
            buttonsil.Click += buttonsil_Click;
            // 
            // maskedTextBoxtelnmo
            // 
            maskedTextBoxtelnmo.BackColor = Color.OldLace;
            maskedTextBoxtelnmo.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxtelnmo.Location = new Point(146, 230);
            maskedTextBoxtelnmo.Mask = "(999) 000-0000";
            maskedTextBoxtelnmo.Name = "maskedTextBoxtelnmo";
            maskedTextBoxtelnmo.Size = new Size(305, 30);
            maskedTextBoxtelnmo.TabIndex = 10;
            // 
            // labeltelno
            // 
            labeltelno.AutoSize = true;
            labeltelno.ForeColor = Color.OrangeRed;
            labeltelno.Location = new Point(59, 232);
            labeltelno.Name = "labeltelno";
            labeltelno.Size = new Size(81, 26);
            labeltelno.TabIndex = 9;
            labeltelno.Text = "TELNO:";
            // 
            // textBoxsifre
            // 
            textBoxsifre.BackColor = Color.OldLace;
            textBoxsifre.BorderStyle = BorderStyle.FixedSingle;
            textBoxsifre.Location = new Point(146, 185);
            textBoxsifre.Name = "textBoxsifre";
            textBoxsifre.PasswordChar = '*';
            textBoxsifre.Size = new Size(305, 30);
            textBoxsifre.TabIndex = 8;
            // 
            // labelsifre
            // 
            labelsifre.AutoSize = true;
            labelsifre.ForeColor = Color.OrangeRed;
            labelsifre.Location = new Point(67, 185);
            labelsifre.Name = "labelsifre";
            labelsifre.Size = new Size(73, 26);
            labelsifre.TabIndex = 7;
            labelsifre.Text = "ŞİFRE:";
            // 
            // textBoxmail
            // 
            textBoxmail.BackColor = Color.OldLace;
            textBoxmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxmail.Location = new Point(146, 141);
            textBoxmail.Name = "textBoxmail";
            textBoxmail.Size = new Size(305, 30);
            textBoxmail.TabIndex = 6;
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.ForeColor = Color.OrangeRed;
            labelMail.Location = new Point(62, 141);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(78, 26);
            labelMail.TabIndex = 5;
            labelMail.Text = "EMAİL:";
            // 
            // textBoxsoyad
            // 
            textBoxsoyad.BackColor = Color.OldLace;
            textBoxsoyad.BorderStyle = BorderStyle.FixedSingle;
            textBoxsoyad.Location = new Point(146, 95);
            textBoxsoyad.Name = "textBoxsoyad";
            textBoxsoyad.Size = new Size(305, 30);
            textBoxsoyad.TabIndex = 4;
            // 
            // labelSoyad
            // 
            labelSoyad.AutoSize = true;
            labelSoyad.ForeColor = Color.OrangeRed;
            labelSoyad.Location = new Point(54, 91);
            labelSoyad.Name = "labelSoyad";
            labelSoyad.Size = new Size(86, 26);
            labelSoyad.TabIndex = 3;
            labelSoyad.Text = "SOYADI:";
            // 
            // buttonEkle
            // 
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.ForeColor = Color.OrangeRed;
            buttonEkle.Location = new Point(86, 419);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(168, 43);
            buttonEkle.TabIndex = 2;
            buttonEkle.Text = "EKLE";
            buttonEkle.UseVisualStyleBackColor = true;
            buttonEkle.Click += buttonEkle_Click;
            // 
            // textBoxad
            // 
            textBoxad.BackColor = Color.OldLace;
            textBoxad.BorderStyle = BorderStyle.FixedSingle;
            textBoxad.Location = new Point(146, 50);
            textBoxad.Name = "textBoxad";
            textBoxad.Size = new Size(305, 30);
            textBoxad.TabIndex = 1;
            // 
            // labeladi
            // 
            labeladi.AutoSize = true;
            labeladi.ForeColor = Color.OrangeRed;
            labeladi.Location = new Point(89, 53);
            labeladi.Name = "labeladi";
            labeladi.Size = new Size(51, 26);
            labeladi.TabIndex = 0;
            labeladi.Text = "ADI:";
            // 
            // radioButtonaktif
            // 
            radioButtonaktif.AutoSize = true;
            radioButtonaktif.ForeColor = Color.OrangeRed;
            radioButtonaktif.Location = new Point(1195, 146);
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
            radioButtonpasif.Location = new Point(1289, 146);
            radioButtonpasif.Name = "radioButtonpasif";
            radioButtonpasif.Size = new Size(84, 30);
            radioButtonpasif.TabIndex = 4;
            radioButtonpasif.TabStop = true;
            radioButtonpasif.Text = "PASİF";
            radioButtonpasif.UseVisualStyleBackColor = true;
            radioButtonpasif.CheckedChanged += radioButtonpasif_CheckedChanged;
            // 
            // textBoxara
            // 
            textBoxara.BackColor = Color.OldLace;
            textBoxara.BorderStyle = BorderStyle.FixedSingle;
            textBoxara.Location = new Point(1515, 160);
            textBoxara.Name = "textBoxara";
            textBoxara.Size = new Size(332, 30);
            textBoxara.TabIndex = 11;
            textBoxara.TextChanged += textBoxara_TextChanged;
            // 
            // labelarama
            // 
            labelarama.AutoSize = true;
            labelarama.ForeColor = Color.OrangeRed;
            labelarama.Location = new Point(1406, 164);
            labelarama.Name = "labelarama";
            labelarama.Size = new Size(103, 26);
            labelarama.TabIndex = 10;
            labelarama.Text = "ARA... 🔍 ";
            // 
            // Kullanicilarcs
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1924, 969);
            Controls.Add(textBoxara);
            Controls.Add(labelarama);
            Controls.Add(radioButtonpasif);
            Controls.Add(radioButtonaktif);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Kullanicilarcs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanicilarcs";
            WindowState = FormWindowState.Maximized;
            Load += Kullanicilarcs_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private TextBox textBoxmail;
        private Label labelMail;
        private TextBox textBoxsoyad;
        private Label labelSoyad;
        private Button buttonEkle;
        private TextBox textBoxad;
        private Label labeladi;
        private MaskedTextBox maskedTextBoxtelnmo;
        private Label labeltelno;
        private TextBox textBoxsifre;
        private Label labelsifre;
        private Button buttonguncelle;
        private Button buttonTemizle;
        private Button buttonsil;
        private Label labelkullanicibilgi;
        private ComboBox comboBoxKullanicitip;
        private Label labelkullaniciTip;
        private RadioButton radioButtonaktif;
        private RadioButton radioButtonpasif;
        private TextBox textBoxara;
        private Label labelarama;
        private Label labeliban;
        private MaskedTextBox maskedTextBoxiban;
    }
}