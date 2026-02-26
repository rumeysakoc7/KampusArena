namespace KampusArena
{
    partial class FormUrunDetay
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
            pictureBoxurun = new PictureBox();
            labelfiyat = new Label();
            labelurunadi = new Label();
            labelaciklama = new Label();
            richTextBoxaciklama = new RichTextBox();
            buttoodeme = new Button();
            labelsatici = new Label();
            buttonteklifVer = new Button();
            buttonSorusor = new Button();
            labelTeklifDurum = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurun).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxurun
            // 
            pictureBoxurun.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxurun.Location = new Point(65, 34);
            pictureBoxurun.Margin = new Padding(4);
            pictureBoxurun.Name = "pictureBoxurun";
            pictureBoxurun.Size = new Size(139, 139);
            pictureBoxurun.TabIndex = 4;
            pictureBoxurun.TabStop = false;
            // 
            // labelfiyat
            // 
            labelfiyat.AutoSize = true;
            labelfiyat.ForeColor = Color.OrangeRed;
            labelfiyat.Location = new Point(238, 81);
            labelfiyat.Margin = new Padding(4, 0, 4, 0);
            labelfiyat.Name = "labelfiyat";
            labelfiyat.Size = new Size(0, 24);
            labelfiyat.TabIndex = 12;
            // 
            // labelurunadi
            // 
            labelurunadi.AutoSize = true;
            labelurunadi.ForeColor = Color.OrangeRed;
            labelurunadi.Location = new Point(238, 38);
            labelurunadi.Margin = new Padding(4, 0, 4, 0);
            labelurunadi.Name = "labelurunadi";
            labelurunadi.Size = new Size(0, 24);
            labelurunadi.TabIndex = 11;
            // 
            // labelaciklama
            // 
            labelaciklama.AutoSize = true;
            labelaciklama.ForeColor = Color.OrangeRed;
            labelaciklama.Location = new Point(65, 192);
            labelaciklama.Margin = new Padding(4, 0, 4, 0);
            labelaciklama.Name = "labelaciklama";
            labelaciklama.Size = new Size(122, 24);
            labelaciklama.TabIndex = 17;
            labelaciklama.Text = "AÇIKLAMASI:";
            // 
            // richTextBoxaciklama
            // 
            richTextBoxaciklama.BackColor = Color.OldLace;
            richTextBoxaciklama.Location = new Point(65, 219);
            richTextBoxaciklama.Name = "richTextBoxaciklama";
            richTextBoxaciklama.ReadOnly = true;
            richTextBoxaciklama.Size = new Size(358, 287);
            richTextBoxaciklama.TabIndex = 16;
            richTextBoxaciklama.Text = "";
            // 
            // buttoodeme
            // 
            buttoodeme.FlatStyle = FlatStyle.Flat;
            buttoodeme.ForeColor = Color.OrangeRed;
            buttoodeme.Location = new Point(65, 513);
            buttoodeme.Margin = new Padding(4);
            buttoodeme.Name = "buttoodeme";
            buttoodeme.Size = new Size(180, 42);
            buttoodeme.TabIndex = 18;
            buttoodeme.Text = "ÖDEME YAP";
            buttoodeme.UseVisualStyleBackColor = true;
            buttoodeme.Click += buttoodeme_Click;
            // 
            // labelsatici
            // 
            labelsatici.AutoSize = true;
            labelsatici.ForeColor = Color.OrangeRed;
            labelsatici.Location = new Point(238, 128);
            labelsatici.Name = "labelsatici";
            labelsatici.Size = new Size(63, 24);
            labelsatici.TabIndex = 19;
            labelsatici.Text = "Satıcı:";
            // 
            // buttonteklifVer
            // 
            buttonteklifVer.FlatStyle = FlatStyle.Flat;
            buttonteklifVer.ForeColor = Color.OrangeRed;
            buttonteklifVer.Location = new Point(253, 513);
            buttonteklifVer.Margin = new Padding(4);
            buttonteklifVer.Name = "buttonteklifVer";
            buttonteklifVer.Size = new Size(162, 42);
            buttonteklifVer.TabIndex = 20;
            buttonteklifVer.Text = "TEKLİF VER";
            buttonteklifVer.UseVisualStyleBackColor = true;
            buttonteklifVer.Click += buttonteklifVer_Click;
            // 
            // buttonSorusor
            // 
            buttonSorusor.FlatStyle = FlatStyle.Flat;
            buttonSorusor.ForeColor = Color.OrangeRed;
            buttonSorusor.Location = new Point(65, 587);
            buttonSorusor.Margin = new Padding(4);
            buttonSorusor.Name = "buttonSorusor";
            buttonSorusor.Size = new Size(358, 42);
            buttonSorusor.TabIndex = 21;
            buttonSorusor.Text = "ÜRÜN İLE İLGİLİ SORU SOR ";
            buttonSorusor.UseVisualStyleBackColor = true;
            buttonSorusor.Click += buttonSorusor_Click;
            // 
            // labelTeklifDurum
            // 
            labelTeklifDurum.AutoSize = true;
            labelTeklifDurum.ForeColor = Color.OrangeRed;
            labelTeklifDurum.Location = new Point(65, 559);
            labelTeklifDurum.Name = "labelTeklifDurum";
            labelTeklifDurum.Size = new Size(390, 24);
            labelTeklifDurum.TabIndex = 22;
            labelTeklifDurum.Text = "Bu ürüne ait bir teklif zaten kabul edilmiştir.";
            labelTeklifDurum.Visible = false;
            // 
            // FormUrunDetay
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(523, 660);
            Controls.Add(labelTeklifDurum);
            Controls.Add(buttonSorusor);
            Controls.Add(buttonteklifVer);
            Controls.Add(labelsatici);
            Controls.Add(buttoodeme);
            Controls.Add(labelaciklama);
            Controls.Add(richTextBoxaciklama);
            Controls.Add(labelfiyat);
            Controls.Add(labelurunadi);
            Controls.Add(pictureBoxurun);
            Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormUrunDetay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormUrunDetay";
            Load += FormUrunDetay_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxurun).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxurun;
        private Label labelfiyat;
        private Label labelurunadi;
        private Label labelaciklama;
        private RichTextBox richTextBoxaciklama;
        private Button buttoodeme;
        private Label labelsatici;
        private Button buttonteklifVer;
        private Button buttonSorusor;
        private Label labelTeklifDurum;
    }
}