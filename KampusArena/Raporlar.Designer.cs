namespace KampusArena
{
    partial class Raporlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raporlar));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pictureBox1 = new PictureBox();
            dataGridViewRapor = new DataGridView();
            dateTimePickerbaslangic = new DateTimePicker();
            dateTimePickerbitis = new DateTimePicker();
            buttonolustur = new Button();
            chartRapor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRapor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRapor).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 16);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewRapor
            // 
            dataGridViewRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRapor.Location = new Point(52, 245);
            dataGridViewRapor.Margin = new Padding(4);
            dataGridViewRapor.Name = "dataGridViewRapor";
            dataGridViewRapor.RowHeadersWidth = 51;
            dataGridViewRapor.Size = new Size(983, 664);
            dataGridViewRapor.TabIndex = 1;
            dataGridViewRapor.CellClick += dataGridViewRapor_CellClick;
            dataGridViewRapor.CellFormatting += dataGridViewRapor_CellFormatting;
            // 
            // dateTimePickerbaslangic
            // 
            dateTimePickerbaslangic.Location = new Point(358, 208);
            dateTimePickerbaslangic.Margin = new Padding(4);
            dateTimePickerbaslangic.Name = "dateTimePickerbaslangic";
            dateTimePickerbaslangic.Size = new Size(292, 30);
            dateTimePickerbaslangic.TabIndex = 2;
            // 
            // dateTimePickerbitis
            // 
            dateTimePickerbitis.Location = new Point(658, 207);
            dateTimePickerbitis.Margin = new Padding(4);
            dateTimePickerbitis.Name = "dateTimePickerbitis";
            dateTimePickerbitis.Size = new Size(307, 30);
            dateTimePickerbitis.TabIndex = 3;
            // 
            // buttonolustur
            // 
            buttonolustur.FlatStyle = FlatStyle.Flat;
            buttonolustur.ForeColor = Color.OrangeRed;
            buttonolustur.Location = new Point(52, 189);
            buttonolustur.Name = "buttonolustur";
            buttonolustur.Size = new Size(266, 48);
            buttonolustur.TabIndex = 4;
            buttonolustur.Text = "RAPOR OLUŞTUR";
            buttonolustur.UseVisualStyleBackColor = true;
            buttonolustur.Click += buttonolustur_Click;
            // 
            // chartRapor
            // 
            chartArea1.Name = "ChartArea1";
            chartRapor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartRapor.Legends.Add(legend1);
            chartRapor.Location = new Point(1076, 268);
            chartRapor.Name = "chartRapor";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartRapor.Series.Add(series1);
            chartRapor.Size = new Size(403, 445);
            chartRapor.TabIndex = 5;
            chartRapor.Text = "chart1";
            // 
            // Raporlar
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1606, 991);
            Controls.Add(chartRapor);
            Controls.Add(buttonolustur);
            Controls.Add(dateTimePickerbitis);
            Controls.Add(dateTimePickerbaslangic);
            Controls.Add(dataGridViewRapor);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Raporlar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raporlar";
            WindowState = FormWindowState.Maximized;
            Load += Raporlar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRapor).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRapor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewRapor;
        private DateTimePicker dateTimePickerbaslangic;
        private DateTimePicker dateTimePickerbitis;
        private Button buttonolustur;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRapor;
    }
}