namespace KampusArena
{
    partial class AdminOdemeOnay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminOdemeOnay));
            pictureBox1 = new PictureBox();
            buttononayla = new Button();
            labeldekont = new Label();
            pictureBoxdekont = new PictureBox();
            dataGridViewodeme = new DataGridView();
            buttonred = new Button();
            buttonteslimet = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxdekont).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewodeme).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 16);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 139);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // buttononayla
            // 
            buttononayla.FlatStyle = FlatStyle.Flat;
            buttononayla.ForeColor = Color.OrangeRed;
            buttononayla.Location = new Point(32, 679);
            buttononayla.Margin = new Padding(4);
            buttononayla.Name = "buttononayla";
            buttononayla.Size = new Size(316, 44);
            buttononayla.TabIndex = 4;
            buttononayla.Text = "ONAYLA";
            buttononayla.UseVisualStyleBackColor = true;
            buttononayla.Click += buttononayla_Click;
            // 
            // labeldekont
            // 
            labeldekont.AutoSize = true;
            labeldekont.ForeColor = Color.OrangeRed;
            labeldekont.Location = new Point(244, 16);
            labeldekont.Margin = new Padding(4, 0, 4, 0);
            labeldekont.Name = "labeldekont";
            labeldekont.Size = new Size(83, 26);
            labeldekont.TabIndex = 13;
            labeldekont.Text = "Dekont:";
            // 
            // pictureBoxdekont
            // 
            pictureBoxdekont.Location = new Point(244, 49);
            pictureBoxdekont.Margin = new Padding(4);
            pictureBoxdekont.Name = "pictureBoxdekont";
            pictureBoxdekont.Size = new Size(303, 163);
            pictureBoxdekont.TabIndex = 12;
            pictureBoxdekont.TabStop = false;
            // 
            // dataGridViewodeme
            // 
            dataGridViewodeme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewodeme.Location = new Point(16, 228);
            dataGridViewodeme.Name = "dataGridViewodeme";
            dataGridViewodeme.RowHeadersWidth = 51;
            dataGridViewodeme.Size = new Size(1142, 426);
            dataGridViewodeme.TabIndex = 14;
            dataGridViewodeme.CellClick += dataGridViewodeme_CellClick;
            // 
            // buttonred
            // 
            buttonred.FlatStyle = FlatStyle.Flat;
            buttonred.ForeColor = Color.OrangeRed;
            buttonred.Location = new Point(395, 679);
            buttonred.Margin = new Padding(4);
            buttonred.Name = "buttonred";
            buttonred.Size = new Size(316, 44);
            buttonred.TabIndex = 15;
            buttonred.Text = "REDDET";
            buttonred.UseVisualStyleBackColor = true;
            buttonred.Click += buttonred_Click;
            // 
            // buttonteslimet
            // 
            buttonteslimet.FlatStyle = FlatStyle.Flat;
            buttonteslimet.ForeColor = Color.OrangeRed;
            buttonteslimet.Location = new Point(748, 679);
            buttonteslimet.Margin = new Padding(4);
            buttonteslimet.Name = "buttonteslimet";
            buttonteslimet.Size = new Size(316, 44);
            buttonteslimet.TabIndex = 16;
            buttonteslimet.Text = "TESLİM EDİLDİ";
            buttonteslimet.UseVisualStyleBackColor = true;
            buttonteslimet.Click += buttonteslimet_Click;
            // 
            // AdminOdemeOnay
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1249, 774);
            Controls.Add(buttonteslimet);
            Controls.Add(buttonred);
            Controls.Add(dataGridViewodeme);
            Controls.Add(labeldekont);
            Controls.Add(pictureBoxdekont);
            Controls.Add(buttononayla);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "AdminOdemeOnay";
            Text = "AdminOdemeOnay";
            Load += AdminOdemeOnay_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxdekont).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewodeme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttononayla;
        private Label labeldekont;
        private PictureBox pictureBoxdekont;
        private DataGridView dataGridViewodeme;
        private Button buttonred;
        private Button buttonteslimet;
    }
}