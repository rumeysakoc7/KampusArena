namespace KampusArena
{
    partial class FormSifremiunuttum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSifremiunuttum));
            labelSifre = new Label();
            textBoxsifre = new TextBox();
            buttonguncelle = new Button();
            pictureBox1 = new PictureBox();
            textBoxsifretekrar = new TextBox();
            labelsifretekrar = new Label();
            maskedTextBoxtelno = new MaskedTextBox();
            labeltelno = new Label();
            buttoniptal = new Button();
            textBoxmail = new TextBox();
            labelmail = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelSifre
            // 
            labelSifre.AutoSize = true;
            labelSifre.ForeColor = Color.OrangeRed;
            labelSifre.Location = new Point(92, 219);
            labelSifre.Name = "labelSifre";
            labelSifre.Size = new Size(73, 26);
            labelSifre.TabIndex = 0;
            labelSifre.Text = "ŞİFRE:";
            // 
            // textBoxsifre
            // 
            textBoxsifre.BackColor = Color.OldLace;
            textBoxsifre.BorderStyle = BorderStyle.FixedSingle;
            textBoxsifre.Location = new Point(176, 215);
            textBoxsifre.Name = "textBoxsifre";
            textBoxsifre.PasswordChar = '*';
            textBoxsifre.Size = new Size(190, 30);
            textBoxsifre.TabIndex = 1;
            // 
            // buttonguncelle
            // 
            buttonguncelle.FlatStyle = FlatStyle.Flat;
            buttonguncelle.ForeColor = Color.OrangeRed;
            buttonguncelle.Location = new Point(47, 372);
            buttonguncelle.Name = "buttonguncelle";
            buttonguncelle.Size = new Size(181, 40);
            buttonguncelle.TabIndex = 2;
            buttonguncelle.Text = "GÜNCELLE";
            buttonguncelle.UseVisualStyleBackColor = true;
            buttonguncelle.Click += buttonguncelle_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 117);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // textBoxsifretekrar
            // 
            textBoxsifretekrar.BackColor = Color.OldLace;
            textBoxsifretekrar.BorderStyle = BorderStyle.FixedSingle;
            textBoxsifretekrar.Location = new Point(176, 260);
            textBoxsifretekrar.Name = "textBoxsifretekrar";
            textBoxsifretekrar.PasswordChar = '*';
            textBoxsifretekrar.Size = new Size(190, 30);
            textBoxsifretekrar.TabIndex = 5;
            // 
            // labelsifretekrar
            // 
            labelsifretekrar.AutoSize = true;
            labelsifretekrar.ForeColor = Color.OrangeRed;
            labelsifretekrar.Location = new Point(17, 264);
            labelsifretekrar.Name = "labelsifretekrar";
            labelsifretekrar.Size = new Size(153, 26);
            labelsifretekrar.TabIndex = 4;
            labelsifretekrar.Text = "ŞİFRE TEKRAR:";
            // 
            // maskedTextBoxtelno
            // 
            maskedTextBoxtelno.BackColor = Color.OldLace;
            maskedTextBoxtelno.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxtelno.Location = new Point(176, 307);
            maskedTextBoxtelno.Mask = "(999) 000-0000";
            maskedTextBoxtelno.Name = "maskedTextBoxtelno";
            maskedTextBoxtelno.Size = new Size(190, 30);
            maskedTextBoxtelno.TabIndex = 6;
            // 
            // labeltelno
            // 
            labeltelno.AutoSize = true;
            labeltelno.ForeColor = Color.OrangeRed;
            labeltelno.Location = new Point(84, 311);
            labeltelno.Name = "labeltelno";
            labeltelno.Size = new Size(81, 26);
            labeltelno.TabIndex = 7;
            labeltelno.Text = "TELNO:";
            // 
            // buttoniptal
            // 
            buttoniptal.FlatStyle = FlatStyle.Flat;
            buttoniptal.ForeColor = Color.OrangeRed;
            buttoniptal.Location = new Point(248, 372);
            buttoniptal.Name = "buttoniptal";
            buttoniptal.Size = new Size(181, 40);
            buttoniptal.TabIndex = 8;
            buttoniptal.Text = "İPTAL";
            buttoniptal.UseVisualStyleBackColor = true;
            buttoniptal.Click += buttoniptal_Click;
            // 
            // textBoxmail
            // 
            textBoxmail.BackColor = Color.OldLace;
            textBoxmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxmail.Location = new Point(176, 166);
            textBoxmail.Name = "textBoxmail";
            textBoxmail.Size = new Size(190, 30);
            textBoxmail.TabIndex = 10;
            // 
            // labelmail
            // 
            labelmail.AutoSize = true;
            labelmail.ForeColor = Color.OrangeRed;
            labelmail.Location = new Point(92, 170);
            labelmail.Name = "labelmail";
            labelmail.Size = new Size(78, 26);
            labelmail.TabIndex = 9;
            labelmail.Text = "EMAİL:";
            // 
            // FormSifremiunuttum
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(451, 470);
            Controls.Add(textBoxmail);
            Controls.Add(labelmail);
            Controls.Add(buttoniptal);
            Controls.Add(labeltelno);
            Controls.Add(maskedTextBoxtelno);
            Controls.Add(textBoxsifretekrar);
            Controls.Add(labelsifretekrar);
            Controls.Add(pictureBox1);
            Controls.Add(buttonguncelle);
            Controls.Add(textBoxsifre);
            Controls.Add(labelSifre);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "FormSifremiunuttum";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSifremiunuttum";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSifre;
        private TextBox textBoxsifre;
        private Button buttonguncelle;
        private PictureBox pictureBox1;
        private TextBox textBoxsifretekrar;
        private Label labelsifretekrar;
        private MaskedTextBox maskedTextBoxtelno;
        private Label labeltelno;
        private Button buttoniptal;
        private TextBox textBoxmail;
        private Label labelmail;
    }
}