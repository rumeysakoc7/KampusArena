using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace KampusArena
{
    public partial class SatisVeKiralikTakip : Form
    {
        private readonly Kullanici _girisYapan;

        public SatisVeKiralikTakip(Kullanici girisYapan)
        {
            InitializeComponent();
            _girisYapan = girisYapan;
        }
        private List<GelirTakipDTO> AktifVeri = new List<GelirTakipDTO>();

        private void TariheGoreFiltrele()
        {
            DateTime baslangic = dateTimePickerbaslangic.Value.Date;
            DateTime bitis = dateTimePickerbitis.Value.Date.AddDays(1).AddTicks(-1); 

            var filtreli = AktifVeri
                .Where(x => x.Tarih >= baslangic && x.Tarih <= bitis)
                .ToList();

            dataGridViewgelir.DataSource = filtreli;
            GrafikGuncelleToplam(filtreli); 
        }


        private void SatisVeKiralikTakip_Load(object sender, EventArgs e)
        {
            radioButtonsatilik.Checked = true; 
            VeriYukleVeFiltrele();             

            dataGridViewgelir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewgelir.AllowUserToAddRows = false;
        }

        private void GrafikGuncelleToplam(List<GelirTakipDTO> veri)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Tarih Aralığına Göre Toplam Gelir");
            var area = chart1.ChartAreas[0];
            area.AxisX.Title = "İşlem Türü";
            area.AxisY.Title = "Toplam Gelir (₺)";
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.Interval = 1;

            var seri = chart1.Series.Add("Toplam Gelir");
            seri.ChartType = SeriesChartType.Column;
            seri.BorderWidth = 4;
            seri.IsValueShownAsLabel = true;
            seri["BarLabelStyle"] = "Outside"; 
            seri.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            seri.LabelForeColor = Color.Black;

            decimal toplamSatis = veri.Where(v => v.IslemTuru == "Satış").Sum(v => v.Tutar);
            decimal toplamKira = veri.Where(v => v.IslemTuru == "Kiralık").Sum(v => v.Tutar);

            int sIndex = seri.Points.AddXY("Satış", toplamSatis);
            seri.Points[sIndex].Color = Color.SteelBlue;
            seri.Points[sIndex].Label = $"{toplamSatis:C2}";

            int kIndex = seri.Points.AddXY("Kiralama", toplamKira);
            seri.Points[kIndex].Color = Color.Orange;
            seri.Points[kIndex].Label = $"{toplamKira:C2}";

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = (double)Math.Ceiling(Math.Max(toplamSatis, toplamKira) / 100) * 100 + 100;
        }

        private void radioButtonsatilik_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonsatilik.Checked)
                VeriYukleVeFiltrele();
        }
        private void VeriYukleVeFiltrele()
        {
            SatisRepository satisRepo = new SatisRepository();
            KiralamaRepository kiraRepo = new KiralamaRepository();

            if (radioButtonsatilik.Checked)
            {
                AktifVeri = satisRepo.GetirKullaniciSatislari(_girisYapan.KullaniciID);
            }
            else if (radioButtonkiralik.Checked)
            {
                AktifVeri = kiraRepo.GetirKullaniciKiralamalari(_girisYapan.KullaniciID);
            }

            TariheGoreFiltrele();
        }


        private void radioButtonkiralik_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonkiralik.Checked)
                VeriYukleVeFiltrele();
        }

        private void dateTimePickerbaslangic_ValueChanged(object sender, EventArgs e)
        {
            TariheGoreFiltrele();
        }

        private void dateTimePickerbitis_ValueChanged(object sender, EventArgs e)
        {
            TariheGoreFiltrele();
        }
    }
}
