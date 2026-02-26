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
    public partial class Urunlercs : Form
    {
        private readonly UrunRepository _urunRepo = new UrunRepository();
        private readonly KategoriRepository _kategoriRepo = new KategoriRepository();
        public Urunlercs()
        {
            InitializeComponent();
        }

        private void Urunlercs_Load(object sender, EventArgs e)
        {
            try
            {
                this.BeginInvoke(new Action(() => this.ActiveControl = null));
                radioButtonsatilik.Checked = false;
                radioButtonKiralik.Checked = false;
                KategoriYukle();
                UrunleriFiltrele();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme sırasında hata oluştu: " + ex.Message);
            }
        }


        private void UrunleriYukle(string durum)
        {
            try
            {
                flowLayoutPanelUrunler.Controls.Clear();
                List<Urun> urunler = _urunRepo.GetUrunlerByDurum(durum);

                foreach (var urun in urunler)
                {
                    UrunKartKontrol kart = new UrunKartKontrol();
                    kart.UrunBilgisiAyarla(urun);
                    kart.Margin = new Padding(5);
                    flowLayoutPanelUrunler.Controls.Add(kart);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void radioButtonsatilik_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonsatilik.Checked)


                    UrunleriFiltrele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satılık filtreleme sırasında hata: " + ex.Message);
            }
        }

        private void radioButtonKiralik_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonKiralik.Checked)


                    UrunleriFiltrele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralık filtreleme sırasında hata: " + ex.Message);
            }
        }

        private void KategoriYukle()
        {
            try
            {
                DataTable dt = _kategoriRepo.GetKategoriler();
                DataRow yeniSatir = dt.NewRow();
                yeniSatir["KategoriID"] = -1;
                yeniSatir["KategoriAdi"] = "Tüm Kategoriler";
                dt.Rows.InsertAt(yeniSatir, 0);

                comboBoxKategori.DisplayMember = "KategoriAdi";
                comboBoxKategori.ValueMember = "KategoriID";
                comboBoxKategori.DataSource = dt;
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori yüklenirken hata: " + ex.Message);
            }

        }

        private void UrunleriFiltrele()
        {
            try
            {
                string arama = textBoxara.Text;
                string durum = null;
                if (radioButtonsatilik.Checked)
                    durum = "Satılık";
                else if (radioButtonKiralik.Checked)
                    durum = "Kiralık";


                int? kategoriID = comboBoxKategori.SelectedValue is int id && id != -1 ? id : (int?)null;

                var urunler = _urunRepo.GetFiltreliUrunler(durum, arama, kategoriID);

                flowLayoutPanelUrunler.Controls.Clear();

                foreach (var urun in urunler)
                {
                    if (_urunRepo.UrunSatinAlinmisMi(urun.UrunID))
                        continue; 

                    UrunKartKontrol kart = new UrunKartKontrol();
                    kart.UrunBilgisiAyarla(urun);
                    kart.Margin = new Padding(10);
                    flowLayoutPanelUrunler.Controls.Add(kart);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler filtrelenirken hata oluştu: " + ex.Message);
            }
        }


        private void textBoxara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UrunleriFiltrele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında hata oluştu: " + ex.Message);
            }
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UrunleriFiltrele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori filtreleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void radioButtonsatilik_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                UrunleriFiltrele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori filtreleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void radioButtonKiralik_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                UrunleriFiltrele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori filtreleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void buttontumunugoster_Click(object sender, EventArgs e)
        {
            try
            {
                radioButtonsatilik.Checked = false;
                radioButtonKiralik.Checked = false;

                string arama = textBoxara.Text;
                int? kategoriID = comboBoxKategori.SelectedValue is int id && id != -1 ? id : (int?)null;

               
                var urunler = _urunRepo.GetFiltreliUrunler(null, arama, kategoriID);

                flowLayoutPanelUrunler.Controls.Clear();

                foreach (var urun in urunler)
                {
                    if (_urunRepo.UrunSatinAlinmisMi(urun.UrunID))
                        continue;

                    UrunKartKontrol kart = new UrunKartKontrol();
                    kart.UrunBilgisiAyarla(urun);
                    kart.Margin = new Padding(10);
                    flowLayoutPanelUrunler.Controls.Add(kart);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüm ürünler yüklenirken hata oluştu: " + ex.Message);
            }

        }
    }
}
