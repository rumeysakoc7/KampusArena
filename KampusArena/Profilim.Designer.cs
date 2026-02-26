namespace KampusArena
{
    partial class Profilim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profilim));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            maskedTextBoxtelno = new MaskedTextBox();
            buttonguncelle = new Button();
            labelSifre = new Label();
            textBoxSifre = new TextBox();
            labelTelno = new Label();
            textBoxMail = new TextBox();
            labelMail = new Label();
            textBoxsoyad = new TextBox();
            labelSoyad = new Label();
            labelad = new Label();
            textBoxad = new TextBox();
            listBoxurunler = new ListBox();
            labelUrunlerim = new Label();
            labeliban = new Label();
            maskedTextBoxiban = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(32, 31);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 136);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labeliban);
            panel1.Controls.Add(maskedTextBoxiban);
            panel1.Controls.Add(maskedTextBoxtelno);
            panel1.Controls.Add(buttonguncelle);
            panel1.Controls.Add(labelSifre);
            panel1.Controls.Add(textBoxSifre);
            panel1.Controls.Add(labelTelno);
            panel1.Controls.Add(textBoxMail);
            panel1.Controls.Add(labelMail);
            panel1.Controls.Add(textBoxsoyad);
            panel1.Controls.Add(labelSoyad);
            panel1.Controls.Add(labelad);
            panel1.Controls.Add(textBoxad);
            panel1.Location = new Point(58, 219);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 435);
            panel1.TabIndex = 2;
            // 
            // maskedTextBoxtelno
            // 
            maskedTextBoxtelno.BackColor = Color.OldLace;
            maskedTextBoxtelno.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxtelno.Location = new Point(123, 207);
            maskedTextBoxtelno.Margin = new Padding(4);
            maskedTextBoxtelno.Mask = "(999) 000-0000";
            maskedTextBoxtelno.Name = "maskedTextBoxtelno";
            maskedTextBoxtelno.Size = new Size(319, 30);
            maskedTextBoxtelno.TabIndex = 13;
            // 
            // buttonguncelle
            // 
            buttonguncelle.FlatStyle = FlatStyle.Flat;
            buttonguncelle.ForeColor = Color.OrangeRed;
            buttonguncelle.Location = new Point(229, 334);
            buttonguncelle.Name = "buttonguncelle";
            buttonguncelle.Size = new Size(136, 36);
            buttonguncelle.TabIndex = 12;
            buttonguncelle.Text = "GÜNCELLE";
            buttonguncelle.UseVisualStyleBackColor = true;
            buttonguncelle.Click += buttonguncelle_Click;
            // 
            // labelSifre
            // 
            labelSifre.AutoSize = true;
            labelSifre.ForeColor = Color.OrangeRed;
            labelSifre.Location = new Point(39, 292);
            labelSifre.Name = "labelSifre";
            labelSifre.Size = new Size(73, 26);
            labelSifre.TabIndex = 11;
            labelSifre.Text = "ŞİFRE:";
            // 
            // textBoxSifre
            // 
            textBoxSifre.BackColor = Color.OldLace;
            textBoxSifre.BorderStyle = BorderStyle.FixedSingle;
            textBoxSifre.Location = new Point(123, 289);
            textBoxSifre.Name = "textBoxSifre";
            textBoxSifre.PasswordChar = '*';
            textBoxSifre.Size = new Size(319, 30);
            textBoxSifre.TabIndex = 10;
            // 
            // labelTelno
            // 
            labelTelno.AutoSize = true;
            labelTelno.ForeColor = Color.OrangeRed;
            labelTelno.Location = new Point(36, 211);
            labelTelno.Name = "labelTelno";
            labelTelno.Size = new Size(81, 26);
            labelTelno.TabIndex = 9;
            labelTelno.Text = "TELNO:";
            // 
            // textBoxMail
            // 
            textBoxMail.BackColor = Color.OldLace;
            textBoxMail.BorderStyle = BorderStyle.FixedSingle;
            textBoxMail.Location = new Point(123, 160);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(319, 30);
            textBoxMail.TabIndex = 8;
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.ForeColor = Color.OrangeRed;
            labelMail.Location = new Point(39, 164);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(78, 26);
            labelMail.TabIndex = 7;
            labelMail.Text = "EMAİL:";
            // 
            // textBoxsoyad
            // 
            textBoxsoyad.BackColor = Color.OldLace;
            textBoxsoyad.BorderStyle = BorderStyle.FixedSingle;
            textBoxsoyad.Location = new Point(123, 110);
            textBoxsoyad.Name = "textBoxsoyad";
            textBoxsoyad.Size = new Size(319, 30);
            textBoxsoyad.TabIndex = 6;
            // 
            // labelSoyad
            // 
            labelSoyad.AutoSize = true;
            labelSoyad.ForeColor = Color.OrangeRed;
            labelSoyad.Location = new Point(33, 114);
            labelSoyad.Name = "labelSoyad";
            labelSoyad.Size = new Size(86, 26);
            labelSoyad.TabIndex = 5;
            labelSoyad.Text = "SOYADI:";
            // 
            // labelad
            // 
            labelad.AutoSize = true;
            labelad.ForeColor = Color.OrangeRed;
            labelad.Location = new Point(68, 60);
            labelad.Name = "labelad";
            labelad.Size = new Size(51, 26);
            labelad.TabIndex = 3;
            labelad.Text = "ADI:";
            // 
            // textBoxad
            // 
            textBoxad.BackColor = Color.OldLace;
            textBoxad.BorderStyle = BorderStyle.FixedSingle;
            textBoxad.Location = new Point(123, 56);
            textBoxad.Name = "textBoxad";
            textBoxad.Size = new Size(319, 30);
            textBoxad.TabIndex = 2;
            // 
            // listBoxurunler
            // 
            listBoxurunler.BackColor = Color.OldLace;
            listBoxurunler.FormattingEnabled = true;
            listBoxurunler.ItemHeight = 26;
            listBoxurunler.Location = new Point(561, 219);
            listBoxurunler.Name = "listBoxurunler";
            listBoxurunler.Size = new Size(401, 420);
            listBoxurunler.TabIndex = 3;
            // 
            // labelUrunlerim
            // 
            labelUrunlerim.AutoSize = true;
            labelUrunlerim.ForeColor = Color.OrangeRed;
            labelUrunlerim.Location = new Point(561, 190);
            labelUrunlerim.Name = "labelUrunlerim";
            labelUrunlerim.Size = new Size(127, 26);
            labelUrunlerim.TabIndex = 13;
            labelUrunlerim.Text = "ÜRÜNLERİM";
            // 
            // labeliban
            // 
            labeliban.AutoSize = true;
            labeliban.ForeColor = Color.OrangeRed;
            labeliban.Location = new Point(44, 256);
            labeliban.Margin = new Padding(4, 0, 4, 0);
            labeliban.Name = "labeliban";
            labeliban.Size = new Size(64, 26);
            labeliban.TabIndex = 21;
            labeliban.Text = "IBAN:";
            // 
            // maskedTextBoxiban
            // 
            maskedTextBoxiban.BackColor = Color.OldLace;
            maskedTextBoxiban.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxiban.Location = new Point(123, 252);
            maskedTextBoxiban.Margin = new Padding(4);
            maskedTextBoxiban.Mask = ">TR00 0000 0000 0000 0000 0000 00";
            maskedTextBoxiban.Name = "maskedTextBoxiban";
            maskedTextBoxiban.Size = new Size(319, 30);
            maskedTextBoxiban.TabIndex = 20;
            // 
            // Profilim
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(992, 710);
            Controls.Add(labelUrunlerim);
            Controls.Add(listBoxurunler);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Profilim";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profilim";
            Load += Profilim_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button buttonguncelle;
        private Label labelSifre;
        private TextBox textBoxSifre;
        private Label labelTelno;
        private TextBox textBoxMail;
        private Label labelMail;
        private TextBox textBoxsoyad;
        private Label labelSoyad;
        private Label labelad;
        private TextBox textBoxad;
        private ListBox listBoxurunler;
        private Label labelUrunlerim;
        private MaskedTextBox maskedTextBoxtelno;
        private Label labeliban;
        private MaskedTextBox maskedTextBoxiban;
    }
}