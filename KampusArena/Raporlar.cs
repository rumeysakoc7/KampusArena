using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KampusArena
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        public void buttonolustur_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime baslangic = dateTimePickerbaslangic.Value.Date;
                DateTime bitis = dateTimePickerbitis.Value.Date.AddDays(1).AddTicks(-1); 

                RaporRepository repo = new RaporRepository();
                int kullaniciID = OturumKullanici.AktifKullanici.KullaniciID; 
                var rapor = repo.GetirRaporVerileri(kullaniciID, baslangic, bitis);

                if (rapor != null)
                {
                    chartRapor.Series.Clear();
                    chartRapor.Titles.Clear();
                    chartRapor.Titles.Add("Gelir Dağılımı");

                    var sSeries = chartRapor.Series.Add("Satış");
                    sSeries.Points.AddXY("Satış", rapor.ToplamSatis);
                    sSeries.Color = Color.SteelBlue;
                    sSeries.IsValueShownAsLabel = true;
                    sSeries.Points[0].Label = $"{rapor.ToplamSatis:C2}";

                    var kSeries = chartRapor.Series.Add("Kiralama");
                    kSeries.Points.AddXY("Kiralama", rapor.ToplamKiralama);
                    kSeries.Color = Color.Orange;
                    kSeries.IsValueShownAsLabel = true;
                    kSeries.Points[0].Label = $"{rapor.ToplamKiralama:C2}";

                    dataGridViewRapor.Rows.Clear();
                    dataGridViewRapor.Columns.Clear();

                    dataGridViewRapor.Columns.Add("Tarih", "Tarih");
                    dataGridViewRapor.Columns.Add("ToplamSat", "Toplam Satış");
                    dataGridViewRapor.Columns.Add("ToplamKir", "Toplam Kiralama");
                    dataGridViewRapor.Columns.Add("ToplamGel", "Toplam Gelir");
                    dataGridViewRapor.Columns.Add("ToplamDuy", "Toplam Duyuru");

                    dataGridViewRapor.Rows.Add(
                        rapor.Tarih.ToString("g"),
                        rapor.ToplamSatis,
                        rapor.ToplamKiralama,
                        rapor.ToplamGelir,
                        rapor.ToplamDuyuru
                    );

                    repo.KaydetRaporVeritabanina(rapor, kullaniciID);
                    RaporlariYukle();
                }
                else
                {
                    MessageBox.Show("Seçilen tarihlerde işlem bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }
        private void RaporlariYukle()
        {
            dataGridViewRapor.Rows.Clear();
            dataGridViewRapor.Columns.Clear();

            dataGridViewRapor.Columns.Add("Tarih", "Tarih");
            dataGridViewRapor.Columns.Add("ToplamSat", "Toplam Satış");
            dataGridViewRapor.Columns.Add("ToplamKir", "Toplam Kiralama");
            dataGridViewRapor.Columns.Add("ToplamGel", "Toplam Gelir");
            dataGridViewRapor.Columns.Add("ToplamDuy", "Toplam Duyuru");

            RaporRepository repo = new RaporRepository();
            var raporlar = repo.GetirTumRaporlar(); 

            foreach (var r in raporlar)
            {
                dataGridViewRapor.Rows.Add(r.Tarih.ToString("g"), r.ToplamSatis, r.ToplamKiralama, r.ToplamGelir, r.ToplamDuyuru);
            }
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            RaporlariYukle();
            dataGridViewRapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRapor.AllowUserToAddRows = false;

        }

        private void dataGridViewRapor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow secilenSatir = dataGridViewRapor.Rows[e.RowIndex];

                decimal satis = Convert.ToDecimal(secilenSatir.Cells["ToplamSat"].Value);
                decimal kiralama = Convert.ToDecimal(secilenSatir.Cells["ToplamKir"].Value);

                chartRapor.Series.Clear();
                chartRapor.Titles.Clear();
                chartRapor.Titles.Add("Seçilen Rapor - Gelir Dağılımı");

                var seriSatis = chartRapor.Series.Add("Satış");
                var seriKiralama = chartRapor.Series.Add("Kiralama");

                var dpSatis = seriSatis.Points.AddXY("Satış", satis);
                seriSatis.Points[0].Label = $"{satis} ₺";

                var dpKiralama = seriKiralama.Points.AddXY("Kiralama", kiralama);
                seriKiralama.Points[0].Label = $"{kiralama} ₺";
            }
        }

    

        private void dataGridViewRapor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = dataGridViewRapor.Columns[e.ColumnIndex].Name;

            if ((columnName == "ToplamSat" || columnName == "ToplamKir" || columnName == "ToplamGel") && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal deger))
                {
                    e.Value = $"{deger:N2} ₺"; 
                    e.FormattingApplied = true;
                }
            }
        }

    }
}
