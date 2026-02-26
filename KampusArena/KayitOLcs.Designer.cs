namespace KampusArena
{
    partial class KayitOLcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KayitOLcs));
            pictureBox1 = new PictureBox();
            textBoxad = new TextBox();
            labelad = new Label();
            maskedTextBoxtelno = new MaskedTextBox();
            buttonkayitol = new Button();
            labelSoyad = new Label();
            textBoxsoyad = new TextBox();
            textBoxmail = new TextBox();
            labelmail = new Label();
            textBoxsifre = new TextBox();
            labelsifre = new Label();
            labeltelno = new Label();
            buttoniptal = new Button();
            labelkullanicitipi = new Label();
            comboBoxKullaniciTipi = new ComboBox();
            checkBoxonay = new CheckBox();
            labeliban = new Label();
            maskedTextBoxiban = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(138, 27);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(324, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBoxad
            // 
            textBoxad.BackColor = Color.OldLace;
            textBoxad.BorderStyle = BorderStyle.FixedSingle;
            textBoxad.Location = new Point(197, 228);
            textBoxad.Margin = new Padding(4);
            textBoxad.Name = "textBoxad";
            textBoxad.Size = new Size(305, 30);
            textBoxad.TabIndex = 1;
            // 
            // labelad
            // 
            labelad.AutoSize = true;
            labelad.ForeColor = Color.OrangeRed;
            labelad.Location = new Point(138, 232);
            labelad.Margin = new Padding(4, 0, 4, 0);
            labelad.Name = "labelad";
            labelad.Size = new Size(51, 26);
            labelad.TabIndex = 2;
            labelad.Text = "ADI:";
            // 
            // maskedTextBoxtelno
            // 
            maskedTextBoxtelno.BackColor = Color.OldLace;
            maskedTextBoxtelno.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxtelno.Location = new Point(197, 441);
            maskedTextBoxtelno.Margin = new Padding(4);
            maskedTextBoxtelno.Mask = "(999) 000-0000";
            maskedTextBoxtelno.Name = "maskedTextBoxtelno";
            maskedTextBoxtelno.Size = new Size(305, 30);
            maskedTextBoxtelno.TabIndex = 3;
            // 
            // buttonkayitol
            // 
            buttonkayitol.FlatStyle = FlatStyle.Flat;
            buttonkayitol.ForeColor = Color.OrangeRed;
            buttonkayitol.Location = new Point(85, 599);
            buttonkayitol.Margin = new Padding(4);
            buttonkayitol.Name = "buttonkayitol";
            buttonkayitol.Size = new Size(199, 37);
            buttonkayitol.TabIndex = 4;
            buttonkayitol.Text = "KAYIT OL";
            buttonkayitol.UseVisualStyleBackColor = true;
            buttonkayitol.Click += buttonkayitol_Click;
            // 
            // labelSoyad
            // 
            labelSoyad.AutoSize = true;
            labelSoyad.ForeColor = Color.OrangeRed;
            labelSoyad.Location = new Point(110, 290);
            labelSoyad.Margin = new Padding(4, 0, 4, 0);
            labelSoyad.Name = "labelSoyad";
            labelSoyad.Size = new Size(86, 26);
            labelSoyad.TabIndex = 5;
            labelSoyad.Text = "SOYADI:";
            // 
            // textBoxsoyad
            // 
            textBoxsoyad.BackColor = Color.OldLace;
            textBoxsoyad.BorderStyle = BorderStyle.FixedSingle;
            textBoxsoyad.Location = new Point(197, 288);
            textBoxsoyad.Margin = new Padding(4);
            textBoxsoyad.Name = "textBoxsoyad";
            textBoxsoyad.Size = new Size(305, 30);
            textBoxsoyad.TabIndex = 6;
            // 
            // textBoxmail
            // 
            textBoxmail.BackColor = Color.OldLace;
            textBoxmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxmail.Location = new Point(197, 337);
            textBoxmail.Margin = new Padding(4);
            textBoxmail.Name = "textBoxmail";
            textBoxmail.Size = new Size(305, 30);
            textBoxmail.TabIndex = 8;
            // 
            // labelmail
            // 
            labelmail.AutoSize = true;
            labelmail.ForeColor = Color.OrangeRed;
            labelmail.Location = new Point(115, 341);
            labelmail.Margin = new Padding(4, 0, 4, 0);
            labelmail.Name = "labelmail";
            labelmail.Size = new Size(78, 26);
            labelmail.TabIndex = 7;
            labelmail.Text = "EMAİL:";
            // 
            // textBoxsifre
            // 
            textBoxsifre.BackColor = Color.OldLace;
            textBoxsifre.BorderStyle = BorderStyle.FixedSingle;
            textBoxsifre.Location = new Point(197, 389);
            textBoxsifre.Margin = new Padding(4);
            textBoxsifre.Name = "textBoxsifre";
            textBoxsifre.PasswordChar = '*';
            textBoxsifre.Size = new Size(305, 30);
            textBoxsifre.TabIndex = 10;
            // 
            // labelsifre
            // 
            labelsifre.AutoSize = true;
            labelsifre.ForeColor = Color.OrangeRed;
            labelsifre.Location = new Point(115, 393);
            labelsifre.Margin = new Padding(4, 0, 4, 0);
            labelsifre.Name = "labelsifre";
            labelsifre.Size = new Size(73, 26);
            labelsifre.TabIndex = 9;
            labelsifre.Text = "ŞİFRE:";
            // 
            // labeltelno
            // 
            labeltelno.AutoSize = true;
            labeltelno.ForeColor = Color.OrangeRed;
            labeltelno.Location = new Point(107, 445);
            labeltelno.Margin = new Padding(4, 0, 4, 0);
            labeltelno.Name = "labeltelno";
            labeltelno.Size = new Size(81, 26);
            labeltelno.TabIndex = 11;
            labeltelno.Text = "TELNO:";
            // 
            // buttoniptal
            // 
            buttoniptal.FlatStyle = FlatStyle.Flat;
            buttoniptal.ForeColor = Color.OrangeRed;
            buttoniptal.Location = new Point(303, 599);
            buttoniptal.Margin = new Padding(4);
            buttoniptal.Name = "buttoniptal";
            buttoniptal.Size = new Size(199, 37);
            buttoniptal.TabIndex = 12;
            buttoniptal.Text = "İPTAL";
            buttoniptal.UseVisualStyleBackColor = true;
            buttoniptal.Click += buttoniptal_Click;
            // 
            // labelkullanicitipi
            // 
            labelkullanicitipi.AutoSize = true;
            labelkullanicitipi.ForeColor = Color.OrangeRed;
            labelkullanicitipi.Location = new Point(27, 542);
            labelkullanicitipi.Margin = new Padding(4, 0, 4, 0);
            labelkullanicitipi.Name = "labelkullanicitipi";
            labelkullanicitipi.Size = new Size(161, 26);
            labelkullanicitipi.TabIndex = 13;
            labelkullanicitipi.Text = "KULLANICI TİPİ:";
            // 
            // comboBoxKullaniciTipi
            // 
            comboBoxKullaniciTipi.BackColor = Color.OldLace;
            comboBoxKullaniciTipi.FlatStyle = FlatStyle.System;
            comboBoxKullaniciTipi.FormattingEnabled = true;
            comboBoxKullaniciTipi.Items.AddRange(new object[] { "Öğrenci", "Akademisyen", "Personel", "Admin" });
            comboBoxKullaniciTipi.Location = new Point(195, 534);
            comboBoxKullaniciTipi.Name = "comboBoxKullaniciTipi";
            comboBoxKullaniciTipi.Size = new Size(307, 34);
            comboBoxKullaniciTipi.TabIndex = 14;
            // 
            // checkBoxonay
            // 
            checkBoxonay.AutoSize = true;
            checkBoxonay.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            checkBoxonay.Location = new Point(81, 654);
            checkBoxonay.Name = "checkBoxonay";
            checkBoxonay.Size = new Size(421, 46);
            checkBoxonay.TabIndex = 15;
            checkBoxonay.Text = "Kişisel verilerimin sistemde saklanmasını ve\r\n e-posta bilgilendirmesi almayı kabul ediyorum.\r\n";
            checkBoxonay.UseVisualStyleBackColor = true;
            // 
            // labeliban
            // 
            labeliban.AutoSize = true;
            labeliban.ForeColor = Color.OrangeRed;
            labeliban.Location = new Point(107, 492);
            labeliban.Margin = new Padding(4, 0, 4, 0);
            labeliban.Name = "labeliban";
            labeliban.Size = new Size(64, 26);
            labeliban.TabIndex = 17;
            labeliban.Text = "IBAN:";
            // 
            // maskedTextBoxiban
            // 
            maskedTextBoxiban.BackColor = Color.OldLace;
            maskedTextBoxiban.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxiban.Location = new Point(197, 488);
            maskedTextBoxiban.Margin = new Padding(4);
            maskedTextBoxiban.Mask = ">TR00 0000 0000 0000 0000 0000 00";
            maskedTextBoxiban.Name = "maskedTextBoxiban";
            maskedTextBoxiban.Size = new Size(305, 30);
            maskedTextBoxiban.TabIndex = 16;
            // 
            // KayitOLcs
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(567, 727);
            Controls.Add(labeliban);
            Controls.Add(maskedTextBoxiban);
            Controls.Add(checkBoxonay);
            Controls.Add(comboBoxKullaniciTipi);
            Controls.Add(labelkullanicitipi);
            Controls.Add(buttoniptal);
            Controls.Add(labeltelno);
            Controls.Add(textBoxsifre);
            Controls.Add(labelsifre);
            Controls.Add(textBoxmail);
            Controls.Add(labelmail);
            Controls.Add(textBoxsoyad);
            Controls.Add(labelSoyad);
            Controls.Add(buttonkayitol);
            Controls.Add(maskedTextBoxtelno);
            Controls.Add(labelad);
            Controls.Add(textBoxad);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "KayitOLcs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KayitOLcs";
            Load += KayitOLcs_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBoxad;
        private Label labelad;
        private MaskedTextBox maskedTextBoxtelno;
        private Button buttonkayitol;
        private Label labelSoyad;
        private TextBox textBoxsoyad;
        private TextBox textBoxmail;
        private Label labelmail;
        private TextBox textBoxsifre;
        private Label labelsifre;
        private Label labeltelno;
        private Button buttoniptal;
        private Label labelkullanicitipi;
        private ComboBox comboBoxKullaniciTipi;
        private CheckBox checkBoxonay;
        private Label labeliban;
        private MaskedTextBox maskedTextBoxiban;
    }
}