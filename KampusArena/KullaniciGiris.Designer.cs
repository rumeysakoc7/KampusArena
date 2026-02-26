
namespace KampusArena
{
    partial class Formkullanicigiris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formkullanicigiris));
            pictureBox1 = new PictureBox();
            textBoxmail = new TextBox();
            textBoxsifre = new TextBox();
            labelmail = new Label();
            label2 = new Label();
            buttonGiris = new Button();
            linkLabelkayitol = new LinkLabel();
            linkLabelSifremiunuttum = new LinkLabel();
            contextMenuEmail = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(61, 72);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 189);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBoxmail
            // 
            textBoxmail.BackColor = Color.OldLace;
            textBoxmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxmail.Location = new Point(170, 305);
            textBoxmail.Margin = new Padding(4);
            textBoxmail.Name = "textBoxmail";
            textBoxmail.Size = new Size(208, 30);
            textBoxmail.TabIndex = 1;
            textBoxmail.TextChanged += textBoxmail_TextChanged;
            // 
            // textBoxsifre
            // 
            textBoxsifre.BackColor = Color.OldLace;
            textBoxsifre.BorderStyle = BorderStyle.FixedSingle;
            textBoxsifre.Location = new Point(170, 364);
            textBoxsifre.Margin = new Padding(4);
            textBoxsifre.Name = "textBoxsifre";
            textBoxsifre.PasswordChar = '*';
            textBoxsifre.Size = new Size(208, 30);
            textBoxsifre.TabIndex = 2;
            // 
            // labelmail
            // 
            labelmail.AutoSize = true;
            labelmail.ForeColor = Color.OrangeRed;
            labelmail.Location = new Point(89, 305);
            labelmail.Margin = new Padding(4, 0, 4, 0);
            labelmail.Name = "labelmail";
            labelmail.Size = new Size(78, 26);
            labelmail.TabIndex = 5;
            labelmail.Text = "EMAİL:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.OrangeRed;
            label2.Location = new Point(89, 368);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 26);
            label2.TabIndex = 6;
            label2.Text = "ŞİFRE:";
            // 
            // buttonGiris
            // 
            buttonGiris.FlatStyle = FlatStyle.Flat;
            buttonGiris.ForeColor = Color.OrangeRed;
            buttonGiris.Location = new Point(182, 410);
            buttonGiris.Name = "buttonGiris";
            buttonGiris.Size = new Size(182, 41);
            buttonGiris.TabIndex = 7;
            buttonGiris.Text = "GİRİŞ YAP";
            buttonGiris.UseVisualStyleBackColor = true;
            buttonGiris.Click += buttonGiris_Click;
            // 
            // linkLabelkayitol
            // 
            linkLabelkayitol.AutoSize = true;
            linkLabelkayitol.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabelkayitol.Location = new Point(126, 480);
            linkLabelkayitol.Name = "linkLabelkayitol";
            linkLabelkayitol.Size = new Size(96, 26);
            linkLabelkayitol.TabIndex = 8;
            linkLabelkayitol.TabStop = true;
            linkLabelkayitol.Text = "KAYIT OL";
            linkLabelkayitol.LinkClicked += linkLabelkayitol_LinkClicked_1;
            // 
            // linkLabelSifremiunuttum
            // 
            linkLabelSifremiunuttum.AutoSize = true;
            linkLabelSifremiunuttum.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabelSifremiunuttum.Location = new Point(228, 480);
            linkLabelSifremiunuttum.Name = "linkLabelSifremiunuttum";
            linkLabelSifremiunuttum.Size = new Size(192, 26);
            linkLabelSifremiunuttum.TabIndex = 9;
            linkLabelSifremiunuttum.TabStop = true;
            linkLabelSifremiunuttum.Text = "ŞİFREMİ UNUTTUM";
            linkLabelSifremiunuttum.LinkClicked += linkLabelSifremiunuttum_LinkClicked_1;
            // 
            // contextMenuEmail
            // 
            contextMenuEmail.ImageScalingSize = new Size(20, 20);
            contextMenuEmail.Name = "contextMenuEmail";
            contextMenuEmail.Size = new Size(61, 4);
            // 
            // Formkullanicigiris
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(487, 544);
            Controls.Add(linkLabelSifremiunuttum);
            Controls.Add(linkLabelkayitol);
            Controls.Add(buttonGiris);
            Controls.Add(label2);
            Controls.Add(labelmail);
            Controls.Add(textBoxsifre);
            Controls.Add(textBoxmail);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Formkullanicigiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GİRİŞ SAYFASI";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void linkLabelsifremiunuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void linkLabelKayitol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBoxmail;
        private TextBox textBoxsifre;
        private Label labelmail;
        private Label label2;
        private Button buttonGiris;
        private LinkLabel linkLabelkayitol;
        private LinkLabel linkLabelSifremiunuttum;
        private ContextMenuStrip contextMenuEmail;
    }
}
