namespace KampusArena
{
    partial class SatisVeKiralikTakip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisVeKiralikTakip));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dataGridViewgelir = new DataGridView();
            pictureBox1 = new PictureBox();
            radioButtonsatilik = new RadioButton();
            radioButtonkiralik = new RadioButton();
            dateTimePickerbaslangic = new DateTimePicker();
            dateTimePickerbitis = new DateTimePicker();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridViewgelir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewgelir
            // 
            dataGridViewgelir.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewgelir.Location = new Point(40, 244);
            dataGridViewgelir.Name = "dataGridViewgelir";
            dataGridViewgelir.RowHeadersWidth = 51;
            dataGridViewgelir.Size = new Size(677, 649);
            dataGridViewgelir.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(40, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // radioButtonsatilik
            // 
            radioButtonsatilik.AutoSize = true;
            radioButtonsatilik.ForeColor = Color.OrangeRed;
            radioButtonsatilik.Location = new Point(39, 208);
            radioButtonsatilik.Name = "radioButtonsatilik";
            radioButtonsatilik.Size = new Size(105, 30);
            radioButtonsatilik.TabIndex = 2;
            radioButtonsatilik.TabStop = true;
            radioButtonsatilik.Text = "SATILIK";
            radioButtonsatilik.UseVisualStyleBackColor = true;
            radioButtonsatilik.CheckedChanged += radioButtonsatilik_CheckedChanged;
            // 
            // radioButtonkiralik
            // 
            radioButtonkiralik.AutoSize = true;
            radioButtonkiralik.ForeColor = Color.OrangeRed;
            radioButtonkiralik.Location = new Point(166, 208);
            radioButtonkiralik.Name = "radioButtonkiralik";
            radioButtonkiralik.Size = new Size(109, 30);
            radioButtonkiralik.TabIndex = 3;
            radioButtonkiralik.TabStop = true;
            radioButtonkiralik.Text = "KİRALIK";
            radioButtonkiralik.UseVisualStyleBackColor = true;
            radioButtonkiralik.CheckedChanged += radioButtonkiralik_CheckedChanged;
            // 
            // dateTimePickerbaslangic
            // 
            dateTimePickerbaslangic.Location = new Point(518, 167);
            dateTimePickerbaslangic.Name = "dateTimePickerbaslangic";
            dateTimePickerbaslangic.Size = new Size(294, 30);
            dateTimePickerbaslangic.TabIndex = 4;
            dateTimePickerbaslangic.ValueChanged += dateTimePickerbaslangic_ValueChanged;
            // 
            // dateTimePickerbitis
            // 
            dateTimePickerbitis.Location = new Point(849, 165);
            dateTimePickerbitis.Name = "dateTimePickerbitis";
            dateTimePickerbitis.Size = new Size(295, 30);
            dateTimePickerbitis.TabIndex = 5;
            dateTimePickerbitis.ValueChanged += dateTimePickerbitis_ValueChanged;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(739, 336);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(558, 375);
            chart1.TabIndex = 6;
            chart1.Text = "chart1";
            // 
            // SatisVeKiralikTakip
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1497, 1055);
            Controls.Add(chart1);
            Controls.Add(dateTimePickerbitis);
            Controls.Add(dateTimePickerbaslangic);
            Controls.Add(radioButtonkiralik);
            Controls.Add(radioButtonsatilik);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridViewgelir);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "SatisVeKiralikTakip";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SatisVeKiralikTakip";
            WindowState = FormWindowState.Maximized;
            Load += SatisVeKiralikTakip_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewgelir).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewgelir;
        private PictureBox pictureBox1;
        private RadioButton radioButtonsatilik;
        private RadioButton radioButtonkiralik;
        private DateTimePicker dateTimePickerbaslangic;
        private DateTimePicker dateTimePickerbitis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}