namespace KampusArena
{
    partial class Odemeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Odemeler));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            labeliban = new Label();
            labelodemetur = new Label();
            comboBoxodemeturu = new ComboBox();
            labeladres = new Label();
            textBoxurunid = new TextBox();
            labelurunId = new Label();
            textBoxfiyati = new TextBox();
            labelUrunfiyat = new Label();
            textBoxurunadi = new TextBox();
            comboBoxadres = new ComboBox();
            labelurunadi = new Label();
            pictureBoxurun = new PictureBox();
            buttononayla = new Button();
            dateTimePickerbitis = new DateTimePicker();
            dateTimePickerbaslangic = new DateTimePicker();
            label_bas_tarih = new Label();
            label_bitis_tarih = new Label();
            paneltarihler = new Panel();
            labeluyarı = new Label();
            calendarKiralama = new MonthCalendar();
            pictureBoxdekont = new PictureBox();
            buttondekontYukle = new Button();
            labeldekont = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurun).BeginInit();
            paneltarihler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxdekont).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labeliban);
            panel1.Controls.Add(labelodemetur);
            panel1.Controls.Add(comboBoxodemeturu);
            panel1.Controls.Add(labeladres);
            panel1.Controls.Add(textBoxurunid);
            panel1.Controls.Add(labelurunId);
            panel1.Controls.Add(textBoxfiyati);
            panel1.Controls.Add(labelUrunfiyat);
            panel1.Controls.Add(textBoxurunadi);
            panel1.Controls.Add(comboBoxadres);
            panel1.Controls.Add(labelurunadi);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(28, 384);
            panel1.Name = "panel1";
            panel1.Size = new Size(522, 327);
            panel1.TabIndex = 1;
            // 
            // labeliban
            // 
            labeliban.AutoSize = true;
            labeliban.ForeColor = Color.OrangeRed;
            labeliban.Location = new Point(13, 282);
            labeliban.Name = "labeliban";
            labeliban.Size = new Size(118, 26);
            labeliban.TabIndex = 10;
            labeliban.Text = "Satıcı IBAN:";
            // 
            // labelodemetur
            // 
            labelodemetur.AutoSize = true;
            labelodemetur.ForeColor = Color.OrangeRed;
            labelodemetur.Location = new Point(13, 236);
            labelodemetur.Name = "labelodemetur";
            labelodemetur.Size = new Size(128, 26);
            labelodemetur.TabIndex = 9;
            labelodemetur.Text = "Ödeme Türü:";
            // 
            // comboBoxodemeturu
            // 
            comboBoxodemeturu.BackColor = Color.OldLace;
            comboBoxodemeturu.FlatStyle = FlatStyle.System;
            comboBoxodemeturu.FormattingEnabled = true;
            comboBoxodemeturu.Location = new Point(150, 228);
            comboBoxodemeturu.Name = "comboBoxodemeturu";
            comboBoxodemeturu.Size = new Size(319, 34);
            comboBoxodemeturu.TabIndex = 8;
            // 
            // labeladres
            // 
            labeladres.AutoSize = true;
            labeladres.ForeColor = Color.OrangeRed;
            labeladres.Location = new Point(63, 187);
            labeladres.Name = "labeladres";
            labeladres.Size = new Size(70, 26);
            labeladres.TabIndex = 7;
            labeladres.Text = "Adres:";
            // 
            // textBoxurunid
            // 
            textBoxurunid.BackColor = Color.OldLace;
            textBoxurunid.BorderStyle = BorderStyle.FixedSingle;
            textBoxurunid.Location = new Point(150, 39);
            textBoxurunid.Name = "textBoxurunid";
            textBoxurunid.ReadOnly = true;
            textBoxurunid.Size = new Size(319, 30);
            textBoxurunid.TabIndex = 6;
            // 
            // labelurunId
            // 
            labelurunId.AutoSize = true;
            labelurunId.ForeColor = Color.OrangeRed;
            labelurunId.Location = new Point(43, 39);
            labelurunId.Name = "labelurunId";
            labelurunId.Size = new Size(90, 26);
            labelurunId.TabIndex = 5;
            labelurunId.Text = "Ürün ID:";
            // 
            // textBoxfiyati
            // 
            textBoxfiyati.BackColor = Color.OldLace;
            textBoxfiyati.BorderStyle = BorderStyle.FixedSingle;
            textBoxfiyati.Location = new Point(150, 133);
            textBoxfiyati.Name = "textBoxfiyati";
            textBoxfiyati.ReadOnly = true;
            textBoxfiyati.Size = new Size(319, 30);
            textBoxfiyati.TabIndex = 4;
            // 
            // labelUrunfiyat
            // 
            labelUrunfiyat.AutoSize = true;
            labelUrunfiyat.ForeColor = Color.OrangeRed;
            labelUrunfiyat.Location = new Point(13, 137);
            labelUrunfiyat.Name = "labelUrunfiyat";
            labelUrunfiyat.Size = new Size(120, 26);
            labelUrunfiyat.TabIndex = 3;
            labelUrunfiyat.Text = "Ürün Fiyatı:";
            // 
            // textBoxurunadi
            // 
            textBoxurunadi.BackColor = Color.OldLace;
            textBoxurunadi.BorderStyle = BorderStyle.FixedSingle;
            textBoxurunadi.Location = new Point(150, 81);
            textBoxurunadi.Name = "textBoxurunadi";
            textBoxurunadi.ReadOnly = true;
            textBoxurunadi.Size = new Size(319, 30);
            textBoxurunadi.TabIndex = 2;
            // 
            // comboBoxadres
            // 
            comboBoxadres.BackColor = Color.OldLace;
            comboBoxadres.FlatStyle = FlatStyle.System;
            comboBoxadres.FormattingEnabled = true;
            comboBoxadres.Location = new Point(150, 179);
            comboBoxadres.Name = "comboBoxadres";
            comboBoxadres.Size = new Size(319, 34);
            comboBoxadres.TabIndex = 1;
            // 
            // labelurunadi
            // 
            labelurunadi.AutoSize = true;
            labelurunadi.ForeColor = Color.OrangeRed;
            labelurunadi.Location = new Point(34, 85);
            labelurunadi.Name = "labelurunadi";
            labelurunadi.Size = new Size(99, 26);
            labelurunadi.TabIndex = 0;
            labelurunadi.Text = "Ürün Adı:";
            // 
            // pictureBoxurun
            // 
            pictureBoxurun.Location = new Point(42, 165);
            pictureBoxurun.Name = "pictureBoxurun";
            pictureBoxurun.Size = new Size(264, 170);
            pictureBoxurun.TabIndex = 2;
            pictureBoxurun.TabStop = false;
            // 
            // buttononayla
            // 
            buttononayla.FlatStyle = FlatStyle.Flat;
            buttononayla.ForeColor = Color.OrangeRed;
            buttononayla.Location = new Point(320, 729);
            buttononayla.Name = "buttononayla";
            buttononayla.Size = new Size(230, 34);
            buttononayla.TabIndex = 3;
            buttononayla.Text = "ONAYLA";
            buttononayla.UseVisualStyleBackColor = true;
            buttononayla.Click += buttononayla_Click;
            // 
            // dateTimePickerbitis
            // 
            dateTimePickerbitis.CalendarFont = new Font("Sitka Text", 9F, FontStyle.Bold);
            dateTimePickerbitis.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            dateTimePickerbitis.Location = new Point(144, 53);
            dateTimePickerbitis.Name = "dateTimePickerbitis";
            dateTimePickerbitis.Size = new Size(233, 26);
            dateTimePickerbitis.TabIndex = 4;
            dateTimePickerbitis.ValueChanged += dateTimePickerbitis_ValueChanged;
            // 
            // dateTimePickerbaslangic
            // 
            dateTimePickerbaslangic.CalendarFont = new Font("Sitka Text", 9F, FontStyle.Bold);
            dateTimePickerbaslangic.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            dateTimePickerbaslangic.Location = new Point(144, 21);
            dateTimePickerbaslangic.Name = "dateTimePickerbaslangic";
            dateTimePickerbaslangic.Size = new Size(233, 26);
            dateTimePickerbaslangic.TabIndex = 5;
            dateTimePickerbaslangic.ValueChanged += dateTimePickerbaslangic_ValueChanged;
            // 
            // label_bas_tarih
            // 
            label_bas_tarih.AutoSize = true;
            label_bas_tarih.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            label_bas_tarih.ForeColor = Color.OrangeRed;
            label_bas_tarih.Location = new Point(9, 21);
            label_bas_tarih.Name = "label_bas_tarih";
            label_bas_tarih.Size = new Size(137, 21);
            label_bas_tarih.TabIndex = 6;
            label_bas_tarih.Text = "Başlangıç Tarihi:";
            // 
            // label_bitis_tarih
            // 
            label_bitis_tarih.AutoSize = true;
            label_bitis_tarih.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            label_bitis_tarih.ForeColor = Color.OrangeRed;
            label_bitis_tarih.Location = new Point(39, 58);
            label_bitis_tarih.Name = "label_bitis_tarih";
            label_bitis_tarih.Size = new Size(99, 21);
            label_bitis_tarih.TabIndex = 7;
            label_bitis_tarih.Text = "Bitiş Tarihi:";
            // 
            // paneltarihler
            // 
            paneltarihler.Controls.Add(labeluyarı);
            paneltarihler.Controls.Add(calendarKiralama);
            paneltarihler.Controls.Add(label_bitis_tarih);
            paneltarihler.Controls.Add(dateTimePickerbaslangic);
            paneltarihler.Controls.Add(dateTimePickerbitis);
            paneltarihler.Controls.Add(label_bas_tarih);
            paneltarihler.ForeColor = SystemColors.ControlText;
            paneltarihler.Location = new Point(364, 44);
            paneltarihler.Name = "paneltarihler";
            paneltarihler.Size = new Size(419, 334);
            paneltarihler.TabIndex = 8;
            // 
            // labeluyarı
            // 
            labeluyarı.AutoSize = true;
            labeluyarı.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labeluyarı.ForeColor = Color.Black;
            labeluyarı.Location = new Point(9, 88);
            labeluyarı.Name = "labeluyarı";
            labeluyarı.Size = new Size(386, 24);
            labeluyarı.TabIndex = 12;
            labeluyarı.Text = "⚠️ Kalın (bold) günler dolu olan tarihlerdir.";
            // 
            // calendarKiralama
            // 
            calendarKiralama.Location = new Point(20, 121);
            calendarKiralama.Name = "calendarKiralama";
            calendarKiralama.TabIndex = 12;
            // 
            // pictureBoxdekont
            // 
            pictureBoxdekont.Location = new Point(575, 414);
            pictureBoxdekont.Name = "pictureBoxdekont";
            pictureBoxdekont.Size = new Size(269, 184);
            pictureBoxdekont.TabIndex = 9;
            pictureBoxdekont.TabStop = false;
            // 
            // buttondekontYukle
            // 
            buttondekontYukle.FlatStyle = FlatStyle.Flat;
            buttondekontYukle.ForeColor = Color.OrangeRed;
            buttondekontYukle.Location = new Point(605, 628);
            buttondekontYukle.Name = "buttondekontYukle";
            buttondekontYukle.Size = new Size(220, 49);
            buttondekontYukle.TabIndex = 10;
            buttondekontYukle.Text = "DEKONT YÜKLE";
            buttondekontYukle.UseVisualStyleBackColor = true;
            buttondekontYukle.Click += buttondekontYukle_Click;
            // 
            // labeldekont
            // 
            labeldekont.AutoSize = true;
            labeldekont.ForeColor = Color.OrangeRed;
            labeldekont.Location = new Point(575, 385);
            labeldekont.Name = "labeldekont";
            labeldekont.Size = new Size(171, 26);
            labeldekont.TabIndex = 11;
            labeldekont.Text = "Yüklenen Dekont:";
            // 
            // Odemeler
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(888, 825);
            Controls.Add(labeldekont);
            Controls.Add(buttondekontYukle);
            Controls.Add(pictureBoxdekont);
            Controls.Add(paneltarihler);
            Controls.Add(buttononayla);
            Controls.Add(pictureBoxurun);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Odemeler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Odemeler";
            Load += Odemeler_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurun).EndInit();
            paneltarihler.ResumeLayout(false);
            paneltarihler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxdekont).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private TextBox textBoxurunadi;
        private ComboBox comboBoxadres;
        private Label labelurunadi;
        private PictureBox pictureBoxurun;
        private Label labelodemetur;
        private ComboBox comboBoxodemeturu;
        private Label labeladres;
        private TextBox textBoxurunid;
        private Label labelurunId;
        private TextBox textBoxfiyati;
        private Label labelUrunfiyat;
        private Button buttononayla;
        private DateTimePicker dateTimePickerbitis;
        private DateTimePicker dateTimePickerbaslangic;
        private Label label_bas_tarih;
        private Label label_bitis_tarih;
        private Panel paneltarihler;
        private Label labeliban;
        private PictureBox pictureBoxdekont;
        private Button buttondekontYukle;
        private Label labeldekont;
        private MonthCalendar calendarKiralama;
        private Label labeluyarı;
    }
}