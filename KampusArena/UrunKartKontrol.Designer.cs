namespace KampusArena
{
    partial class UrunKartKontrol
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            labeldurum = new Label();
            labelfiyat = new Label();
            pictureBoxurunresim = new PictureBox();
            labelurunad = new Label();
            buttondetaylar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurunresim).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labeldurum);
            panel1.Controls.Add(labelfiyat);
            panel1.Controls.Add(pictureBoxurunresim);
            panel1.Controls.Add(labelurunad);
            panel1.Controls.Add(buttondetaylar);
            panel1.Location = new Point(4, 4);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 354);
            panel1.TabIndex = 1;
            // 
            // labeldurum
            // 
            labeldurum.AutoSize = true;
            labeldurum.ForeColor = Color.OrangeRed;
            labeldurum.Location = new Point(4, 257);
            labeldurum.Margin = new Padding(4, 0, 4, 0);
            labeldurum.Name = "labeldurum";
            labeldurum.Size = new Size(146, 26);
            labeldurum.TabIndex = 11;
            labeldurum.Text = "Kiralık/Satılık:";
            // 
            // labelfiyat
            // 
            labelfiyat.AutoSize = true;
            labelfiyat.ForeColor = Color.OrangeRed;
            labelfiyat.Location = new Point(85, 231);
            labelfiyat.Margin = new Padding(4, 0, 4, 0);
            labelfiyat.Name = "labelfiyat";
            labelfiyat.Size = new Size(63, 26);
            labelfiyat.TabIndex = 10;
            labelfiyat.Text = "Fiyat:";
            // 
            // pictureBoxurunresim
            // 
            pictureBoxurunresim.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxurunresim.Location = new Point(85, 22);
            pictureBoxurunresim.Margin = new Padding(4);
            pictureBoxurunresim.Name = "pictureBoxurunresim";
            pictureBoxurunresim.Size = new Size(167, 140);
            pictureBoxurunresim.TabIndex = 1;
            pictureBoxurunresim.TabStop = false;
            // 
            // labelurunad
            // 
            labelurunad.AutoSize = true;
            labelurunad.ForeColor = Color.OrangeRed;
            labelurunad.Location = new Point(51, 180);
            labelurunad.Margin = new Padding(4, 0, 4, 0);
            labelurunad.Name = "labelurunad";
            labelurunad.Size = new Size(99, 26);
            labelurunad.TabIndex = 8;
            labelurunad.Text = "Ürün Adı:";
            labelurunad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttondetaylar
            // 
            buttondetaylar.FlatStyle = FlatStyle.Flat;
            buttondetaylar.ForeColor = Color.Coral;
            buttondetaylar.Location = new Point(157, 300);
            buttondetaylar.Margin = new Padding(4);
            buttondetaylar.Name = "buttondetaylar";
            buttondetaylar.Size = new Size(149, 39);
            buttondetaylar.TabIndex = 9;
            buttondetaylar.Text = "Detaylar...";
            buttondetaylar.UseVisualStyleBackColor = true;
            buttondetaylar.Click += buttondetaylar_Click;
            // 
            // UrunKartKontrol
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            Controls.Add(panel1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "UrunKartKontrol";
            Size = new Size(831, 581);
            Load += UrunKartKontrol_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxurunresim).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labeldurum;
        private Label labelfiyat;
        private PictureBox pictureBoxurunresim;
        private Label labelurunad;
        private Button buttondetaylar;
    }
}
