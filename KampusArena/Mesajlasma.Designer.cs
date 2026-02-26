namespace KampusArena
{
    partial class Mesajlasma
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            labelkullanicibilgi = new Label();
            richTextBoxmesaj = new RichTextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            buttonTeklifiReddet = new Button();
            buttonTeklifiGeriAl = new Button();
            labelTeklifInfo = new Label();
            buttonTeklifiKabulEt = new Button();
            numericTeklif = new NumericUpDown();
            labelTeklif = new Label();
            buttonsohbetisil = new Button();
            panel3 = new Panel();
            pictureBoxurun = new PictureBox();
            labelurunadi = new Label();
            buttonGeriDon = new Button();
            buttongonder = new Button();
            textBoxmesaj = new TextBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericTeklif).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurun).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(pictureBox2);
            flowLayoutPanel1.Controls.Add(labelkullanicibilgi);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Margin = new Padding(4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(413, 683);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(4, 4);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 45);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // labelkullanicibilgi
            // 
            labelkullanicibilgi.AutoSize = true;
            labelkullanicibilgi.Location = new Point(69, 0);
            labelkullanicibilgi.Margin = new Padding(4, 0, 4, 0);
            labelkullanicibilgi.Name = "labelkullanicibilgi";
            labelkullanicibilgi.Size = new Size(136, 26);
            labelkullanicibilgi.TabIndex = 3;
            labelkullanicibilgi.Text = "Kullanıcı Bilgi";
            // 
            // richTextBoxmesaj
            // 
            richTextBoxmesaj.BackColor = Color.OldLace;
            richTextBoxmesaj.Location = new Point(4, 97);
            richTextBoxmesaj.Margin = new Padding(4);
            richTextBoxmesaj.Name = "richTextBoxmesaj";
            richTextBoxmesaj.Size = new Size(725, 500);
            richTextBoxmesaj.TabIndex = 2;
            richTextBoxmesaj.Text = "";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 728);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonTeklifiReddet);
            panel2.Controls.Add(buttonTeklifiGeriAl);
            panel2.Controls.Add(labelTeklifInfo);
            panel2.Controls.Add(buttonTeklifiKabulEt);
            panel2.Controls.Add(numericTeklif);
            panel2.Controls.Add(labelTeklif);
            panel2.Controls.Add(buttonsohbetisil);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(buttongonder);
            panel2.Controls.Add(textBoxmesaj);
            panel2.Controls.Add(richTextBoxmesaj);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(454, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(906, 728);
            panel2.TabIndex = 8;
            // 
            // buttonTeklifiReddet
            // 
            buttonTeklifiReddet.FlatStyle = FlatStyle.Flat;
            buttonTeklifiReddet.ForeColor = Color.OrangeRed;
            buttonTeklifiReddet.Location = new Point(193, 643);
            buttonTeklifiReddet.Margin = new Padding(4);
            buttonTeklifiReddet.Name = "buttonTeklifiReddet";
            buttonTeklifiReddet.Size = new Size(161, 32);
            buttonTeklifiReddet.TabIndex = 14;
            buttonTeklifiReddet.Text = "Teklifi Reddet";
            buttonTeklifiReddet.UseVisualStyleBackColor = true;
            buttonTeklifiReddet.Visible = false;
            buttonTeklifiReddet.Click += buttonTeklifiReddet_Click;
            // 
            // buttonTeklifiGeriAl
            // 
            buttonTeklifiGeriAl.FlatStyle = FlatStyle.Flat;
            buttonTeklifiGeriAl.ForeColor = Color.OrangeRed;
            buttonTeklifiGeriAl.Location = new Point(189, 685);
            buttonTeklifiGeriAl.Margin = new Padding(4);
            buttonTeklifiGeriAl.Name = "buttonTeklifiGeriAl";
            buttonTeklifiGeriAl.Size = new Size(165, 32);
            buttonTeklifiGeriAl.TabIndex = 13;
            buttonTeklifiGeriAl.Text = "Teklifi Geri Al";
            buttonTeklifiGeriAl.UseVisualStyleBackColor = true;
            buttonTeklifiGeriAl.Visible = false;
            buttonTeklifiGeriAl.Click += buttonTeklifiGeriAl_Click;
            // 
            // labelTeklifInfo
            // 
            labelTeklifInfo.AutoSize = true;
            labelTeklifInfo.ForeColor = Color.OrangeRed;
            labelTeklifInfo.Location = new Point(354, 685);
            labelTeklifInfo.Name = "labelTeklifInfo";
            labelTeklifInfo.Size = new Size(0, 26);
            labelTeklifInfo.TabIndex = 12;
            labelTeklifInfo.Visible = false;
            // 
            // buttonTeklifiKabulEt
            // 
            buttonTeklifiKabulEt.FlatStyle = FlatStyle.Flat;
            buttonTeklifiKabulEt.ForeColor = Color.OrangeRed;
            buttonTeklifiKabulEt.Location = new Point(8, 645);
            buttonTeklifiKabulEt.Margin = new Padding(4);
            buttonTeklifiKabulEt.Name = "buttonTeklifiKabulEt";
            buttonTeklifiKabulEt.Size = new Size(177, 32);
            buttonTeklifiKabulEt.TabIndex = 11;
            buttonTeklifiKabulEt.Text = "Teklifi Kabul Et";
            buttonTeklifiKabulEt.UseVisualStyleBackColor = true;
            buttonTeklifiKabulEt.Visible = false;
            buttonTeklifiKabulEt.Click += buttonTeklifiKabulEt_Click;
            // 
            // numericTeklif
            // 
            numericTeklif.DecimalPlaces = 2;
            numericTeklif.Location = new Point(563, 645);
            numericTeklif.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericTeklif.Name = "numericTeklif";
            numericTeklif.Size = new Size(166, 30);
            numericTeklif.TabIndex = 10;
            numericTeklif.Visible = false;
            // 
            // labelTeklif
            // 
            labelTeklif.AutoSize = true;
            labelTeklif.ForeColor = Color.OrangeRed;
            labelTeklif.Location = new Point(400, 645);
            labelTeklif.Name = "labelTeklif";
            labelTeklif.Size = new Size(157, 26);
            labelTeklif.TabIndex = 2;
            labelTeklif.Text = "Teklif Fiyatı (₺):";
            // 
            // buttonsohbetisil
            // 
            buttonsohbetisil.FlatStyle = FlatStyle.Flat;
            buttonsohbetisil.ForeColor = Color.OrangeRed;
            buttonsohbetisil.Location = new Point(8, 685);
            buttonsohbetisil.Margin = new Padding(4);
            buttonsohbetisil.Name = "buttonsohbetisil";
            buttonsohbetisil.Size = new Size(166, 33);
            buttonsohbetisil.TabIndex = 9;
            buttonsohbetisil.Text = "Sohbeti Sil";
            buttonsohbetisil.UseVisualStyleBackColor = true;
            buttonsohbetisil.Click += buttonsohbetisil_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(pictureBoxurun);
            panel3.Controls.Add(labelurunadi);
            panel3.Controls.Add(buttonGeriDon);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(906, 90);
            panel3.TabIndex = 8;
            // 
            // pictureBoxurun
            // 
            pictureBoxurun.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxurun.Location = new Point(7, 9);
            pictureBoxurun.Name = "pictureBoxurun";
            pictureBoxurun.Size = new Size(158, 76);
            pictureBoxurun.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxurun.TabIndex = 1;
            pictureBoxurun.TabStop = false;
            // 
            // labelurunadi
            // 
            labelurunadi.AutoSize = true;
            labelurunadi.ForeColor = Color.OrangeRed;
            labelurunadi.Location = new Point(171, 8);
            labelurunadi.Name = "labelurunadi";
            labelurunadi.Size = new Size(111, 26);
            labelurunadi.TabIndex = 0;
            labelurunadi.Text = "ÜRÜN ADI:";
            // 
            // buttonGeriDon
            // 
            buttonGeriDon.FlatStyle = FlatStyle.Flat;
            buttonGeriDon.ForeColor = Color.OrangeRed;
            buttonGeriDon.Location = new Point(803, 4);
            buttonGeriDon.Margin = new Padding(4);
            buttonGeriDon.Name = "buttonGeriDon";
            buttonGeriDon.Size = new Size(97, 32);
            buttonGeriDon.TabIndex = 14;
            buttonGeriDon.Text = "↩ Geri";
            buttonGeriDon.UseVisualStyleBackColor = true;
            buttonGeriDon.Visible = false;
            buttonGeriDon.Click += buttonGeriDon_Click;
            // 
            // buttongonder
            // 
            buttongonder.FlatStyle = FlatStyle.Flat;
            buttongonder.ForeColor = Color.OrangeRed;
            buttongonder.Location = new Point(618, 595);
            buttongonder.Margin = new Padding(4);
            buttongonder.Name = "buttongonder";
            buttongonder.Size = new Size(111, 46);
            buttongonder.TabIndex = 7;
            buttongonder.Text = "Gönder";
            buttongonder.UseVisualStyleBackColor = true;
            buttongonder.Click += buttongonder_Click;
            // 
            // textBoxmesaj
            // 
            textBoxmesaj.BackColor = Color.OldLace;
            textBoxmesaj.Location = new Point(4, 611);
            textBoxmesaj.Margin = new Padding(4);
            textBoxmesaj.Name = "textBoxmesaj";
            textBoxmesaj.Size = new Size(606, 30);
            textBoxmesaj.TabIndex = 6;
            // 
            // Mesajlasma
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1360, 728);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Mesajlasma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mesajlasma";
            Load += Mesajlasma_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericTeklif).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurun).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox richTextBoxmesaj;
        private Label labelkullanicibilgi;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private Button buttongonder;
        private TextBox textBoxmesaj;
        private Panel panel3;
        private PictureBox pictureBoxurun;
        private Label labelurunadi;
        private Button buttonsohbetisil;
        private NumericUpDown numericTeklif;
        private Label labelTeklif;
        private Label labelTeklifInfo;
        private Button buttonTeklifiKabulEt;
        private Button buttonTeklifiGeriAl;
        private Button buttonGeriDon;
        private Button buttonTeklifiReddet;
    }
}