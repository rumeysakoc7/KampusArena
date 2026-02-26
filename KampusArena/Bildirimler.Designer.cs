namespace KampusArena
{
    partial class Bildirimler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bildirimler));
            pictureBox1 = new PictureBox();
            radioButtonenyeniler = new RadioButton();
            radioButtoneskiler = new RadioButton();
            listBoxBildirimler = new ListBox();
            buttontemizle = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // radioButtonenyeniler
            // 
            radioButtonenyeniler.AutoSize = true;
            radioButtonenyeniler.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            radioButtonenyeniler.ForeColor = Color.OrangeRed;
            radioButtonenyeniler.Location = new Point(641, 101);
            radioButtonenyeniler.Name = "radioButtonenyeniler";
            radioButtonenyeniler.Size = new Size(107, 25);
            radioButtonenyeniler.TabIndex = 25;
            radioButtonenyeniler.TabStop = true;
            radioButtonenyeniler.Text = "En Yeniler";
            radioButtonenyeniler.UseVisualStyleBackColor = true;
            radioButtonenyeniler.CheckedChanged += radioButtonenyeniler_CheckedChanged;
            // 
            // radioButtoneskiler
            // 
            radioButtoneskiler.AutoSize = true;
            radioButtoneskiler.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            radioButtoneskiler.ForeColor = Color.OrangeRed;
            radioButtoneskiler.Location = new Point(754, 101);
            radioButtoneskiler.Name = "radioButtoneskiler";
            radioButtoneskiler.Size = new Size(107, 25);
            radioButtoneskiler.TabIndex = 24;
            radioButtoneskiler.TabStop = true;
            radioButtoneskiler.Text = "En Eskiler";
            radioButtoneskiler.UseVisualStyleBackColor = true;
            radioButtoneskiler.CheckedChanged += radioButtoneskiler_CheckedChanged;
            // 
            // listBoxBildirimler
            // 
            listBoxBildirimler.FormattingEnabled = true;
            listBoxBildirimler.ItemHeight = 26;
            listBoxBildirimler.Location = new Point(54, 165);
            listBoxBildirimler.Name = "listBoxBildirimler";
            listBoxBildirimler.Size = new Size(776, 394);
            listBoxBildirimler.TabIndex = 26;
            listBoxBildirimler.DoubleClick += listBoxBildirimler_DoubleClick;
            // 
            // buttontemizle
            // 
            buttontemizle.FlatStyle = FlatStyle.Flat;
            buttontemizle.ForeColor = Color.OrangeRed;
            buttontemizle.Location = new Point(549, 565);
            buttontemizle.Name = "buttontemizle";
            buttontemizle.Size = new Size(281, 35);
            buttontemizle.TabIndex = 27;
            buttontemizle.Text = "Bildirim Kutusunu Temizle";
            buttontemizle.UseVisualStyleBackColor = true;
            buttontemizle.Click += buttontemizle_Click;
            // 
            // Bildirimler
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(935, 612);
            Controls.Add(buttontemizle);
            Controls.Add(listBoxBildirimler);
            Controls.Add(radioButtonenyeniler);
            Controls.Add(radioButtoneskiler);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Bildirimler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bildirimler";
            Load += Bildirimler_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private RadioButton radioButtonenyeniler;
        private RadioButton radioButtoneskiler;
        private ListBox listBoxBildirimler;
        private Button buttontemizle;
    }
}