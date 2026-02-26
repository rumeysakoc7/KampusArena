namespace KampusArena
{
    partial class DuyuruDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuyuruDuzenle));
            pictureBox1 = new PictureBox();
            richTextBoxduyuru = new RichTextBox();
            textBoxbaslik = new TextBox();
            label_bas_tar = new Label();
            buttonyayinla = new Button();
            dateTimePickerbaslangic = new DateTimePicker();
            dateTimePickerbitis = new DateTimePicker();
            checkBoxkaldir = new CheckBox();
            label_bitis_tar = new Label();
            labelbaslik = new Label();
            buttonduzenle = new Button();
            buttonTemizle = new Button();
            buttonKaldir = new Button();
            dataGridViewduyurularım = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewduyurularım).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(29, 30);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // richTextBoxduyuru
            // 
            richTextBoxduyuru.BackColor = Color.OldLace;
            richTextBoxduyuru.Location = new Point(1066, 290);
            richTextBoxduyuru.Margin = new Padding(4);
            richTextBoxduyuru.Name = "richTextBoxduyuru";
            richTextBoxduyuru.Size = new Size(662, 411);
            richTextBoxduyuru.TabIndex = 1;
            richTextBoxduyuru.Text = "";
            // 
            // textBoxbaslik
            // 
            textBoxbaslik.BackColor = Color.OldLace;
            textBoxbaslik.BorderStyle = BorderStyle.FixedSingle;
            textBoxbaslik.Location = new Point(1147, 725);
            textBoxbaslik.Margin = new Padding(4);
            textBoxbaslik.Name = "textBoxbaslik";
            textBoxbaslik.Size = new Size(581, 30);
            textBoxbaslik.TabIndex = 2;
            // 
            // label_bas_tar
            // 
            label_bas_tar.AutoSize = true;
            label_bas_tar.Location = new Point(40, 234);
            label_bas_tar.Margin = new Padding(4, 0, 4, 0);
            label_bas_tar.Name = "label_bas_tar";
            label_bas_tar.Size = new Size(161, 26);
            label_bas_tar.TabIndex = 3;
            label_bas_tar.Text = "Başlangıç Tarihi:";
            // 
            // buttonyayinla
            // 
            buttonyayinla.FlatStyle = FlatStyle.Flat;
            buttonyayinla.ForeColor = Color.OrangeRed;
            buttonyayinla.Location = new Point(1066, 767);
            buttonyayinla.Margin = new Padding(4);
            buttonyayinla.Name = "buttonyayinla";
            buttonyayinla.Size = new Size(320, 46);
            buttonyayinla.TabIndex = 4;
            buttonyayinla.Text = "YAYINLA";
            buttonyayinla.UseVisualStyleBackColor = true;
            buttonyayinla.Click += buttonyayinla_Click;
            // 
            // dateTimePickerbaslangic
            // 
            dateTimePickerbaslangic.Location = new Point(208, 227);
            dateTimePickerbaslangic.Name = "dateTimePickerbaslangic";
            dateTimePickerbaslangic.Size = new Size(309, 30);
            dateTimePickerbaslangic.TabIndex = 5;
            // 
            // dateTimePickerbitis
            // 
            dateTimePickerbitis.Location = new Point(659, 223);
            dateTimePickerbitis.Name = "dateTimePickerbitis";
            dateTimePickerbitis.Size = new Size(304, 30);
            dateTimePickerbitis.TabIndex = 6;
            // 
            // checkBoxkaldir
            // 
            checkBoxkaldir.AutoSize = true;
            checkBoxkaldir.ForeColor = Color.OrangeRed;
            checkBoxkaldir.Location = new Point(1004, 223);
            checkBoxkaldir.Name = "checkBoxkaldir";
            checkBoxkaldir.Size = new Size(176, 30);
            checkBoxkaldir.TabIndex = 7;
            checkBoxkaldir.Text = "Otomatik Kaldır";
            checkBoxkaldir.UseVisualStyleBackColor = true;
            // 
            // label_bitis_tar
            // 
            label_bitis_tar.AutoSize = true;
            label_bitis_tar.Location = new Point(535, 227);
            label_bitis_tar.Margin = new Padding(4, 0, 4, 0);
            label_bitis_tar.Name = "label_bitis_tar";
            label_bitis_tar.Size = new Size(117, 26);
            label_bitis_tar.TabIndex = 8;
            label_bitis_tar.Text = "Bitiş Tarihi:";
            // 
            // labelbaslik
            // 
            labelbaslik.AutoSize = true;
            labelbaslik.ForeColor = Color.OrangeRed;
            labelbaslik.Location = new Point(1066, 729);
            labelbaslik.Margin = new Padding(4, 0, 4, 0);
            labelbaslik.Name = "labelbaslik";
            labelbaslik.Size = new Size(73, 26);
            labelbaslik.TabIndex = 9;
            labelbaslik.Text = "Başlık:";
            // 
            // buttonduzenle
            // 
            buttonduzenle.FlatStyle = FlatStyle.Flat;
            buttonduzenle.ForeColor = Color.OrangeRed;
            buttonduzenle.Location = new Point(1408, 767);
            buttonduzenle.Margin = new Padding(4);
            buttonduzenle.Name = "buttonduzenle";
            buttonduzenle.Size = new Size(320, 46);
            buttonduzenle.TabIndex = 10;
            buttonduzenle.Text = "DÜZENLE";
            buttonduzenle.UseVisualStyleBackColor = true;
            buttonduzenle.Click += buttonduzenle_Click;
            // 
            // buttonTemizle
            // 
            buttonTemizle.FlatStyle = FlatStyle.Flat;
            buttonTemizle.ForeColor = Color.OrangeRed;
            buttonTemizle.Location = new Point(1408, 827);
            buttonTemizle.Margin = new Padding(4);
            buttonTemizle.Name = "buttonTemizle";
            buttonTemizle.Size = new Size(320, 46);
            buttonTemizle.TabIndex = 11;
            buttonTemizle.Text = "TEMİZLE";
            buttonTemizle.UseVisualStyleBackColor = true;
            buttonTemizle.Click += buttonTemizle_Click;
            // 
            // buttonKaldir
            // 
            buttonKaldir.FlatStyle = FlatStyle.Flat;
            buttonKaldir.ForeColor = Color.OrangeRed;
            buttonKaldir.Location = new Point(1066, 827);
            buttonKaldir.Margin = new Padding(4);
            buttonKaldir.Name = "buttonKaldir";
            buttonKaldir.Size = new Size(320, 46);
            buttonKaldir.TabIndex = 12;
            buttonKaldir.Text = "KALDIR";
            buttonKaldir.UseVisualStyleBackColor = true;
            buttonKaldir.Click += buttonKaldir_Click;
            // 
            // dataGridViewduyurularım
            // 
            dataGridViewduyurularım.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewduyurularım.Location = new Point(29, 290);
            dataGridViewduyurularım.Name = "dataGridViewduyurularım";
            dataGridViewduyurularım.RowHeadersWidth = 51;
            dataGridViewduyurularım.Size = new Size(983, 411);
            dataGridViewduyurularım.TabIndex = 13;
            dataGridViewduyurularım.CellClick += dataGridViewduyurularım_CellClick;
            // 
            // DuyuruDuzenle
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1841, 897);
            Controls.Add(dataGridViewduyurularım);
            Controls.Add(buttonKaldir);
            Controls.Add(buttonTemizle);
            Controls.Add(buttonduzenle);
            Controls.Add(labelbaslik);
            Controls.Add(label_bitis_tar);
            Controls.Add(checkBoxkaldir);
            Controls.Add(dateTimePickerbitis);
            Controls.Add(dateTimePickerbaslangic);
            Controls.Add(buttonyayinla);
            Controls.Add(label_bas_tar);
            Controls.Add(textBoxbaslik);
            Controls.Add(richTextBoxduyuru);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "DuyuruDuzenle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DuyuruDuzenle";
            WindowState = FormWindowState.Maximized;
            Load += DuyuruDuzenle_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewduyurularım).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private RichTextBox richTextBoxduyuru;
        private TextBox textBoxbaslik;
        private Label label_bas_tar;
        private Button buttonyayinla;
        private DateTimePicker dateTimePickerbaslangic;
        private DateTimePicker dateTimePickerbitis;
        private CheckBox checkBoxkaldir;
        private Label label_bitis_tar;
        private Label labelbaslik;
        private Button buttonduzenle;
        private Button buttonTemizle;
        private Button buttonKaldir;
        private DataGridView dataGridViewduyurularım;
    }
}