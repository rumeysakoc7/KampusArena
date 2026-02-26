using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KampusArena
{
    public partial class Odemeler : Form
    {
        private Urun _urun;
        private List<DateTime> doluTarihler = new List<DateTime>();

        public Odemeler(Urun urun)
        {
            InitializeComponent();
            _urun = urun;

        }

        private void Odemeler_Load(object sender, EventArgs e)
        {
            try
            {
                KiralamaRepository kiralamaRepo = new KiralamaRepository();
                doluTarihler = kiralamaRepo.GetirKiralananTarihAraliklari(_urun.UrunID);
                KiralananGunleriIsaretle();


                textBoxurunid.Text = _urun.UrunID.ToString();
                textBoxurunadi.Text = _urun.UrunAdi;
                textBoxfiyati.Text = _urun.Fiyat.ToString("C2");
                this.BeginInvoke(new Action(() => this.ActiveControl = null));

                if (!string.IsNullOrEmpty(_urun.ResimYolu) && File.Exists(_urun.ResimYolu))
                {
                    pictureBoxurun.Image = Image.FromFile(_urun.ResimYolu);
                    pictureBoxurun.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                paneltarihler.Visible = _urun.Durum == "Kiralık";

                comboBoxodemeturu.Items.Add("Havale/EFT");

                comboBoxadres.Items.AddRange(new string[]
                {
            "Merkez Kütüphane",
            "İktisadi ve İdari Bilimler Fakültesi",
            "Bilgisayar Mühendisliği Bölümü",
            "Mimarlık Fakültesi",
            "Sosyal Tesisler (Çarşı)",
            "Öğrenci İşleri Daire Başkanlığı",
            "Tıp Fakültesi Hastanesi Önü",
            "Uludağ Üniversitesi Metro Durağı",
            "Eğitim Fakültesi",
            "Kampüs Camii Önü"
                });

                comboBoxodemeturu.SelectedIndex = 0;
                comboBoxadres.SelectedIndex = 0;

                UrunRepository urunRepo = new UrunRepository();
                int saticiID = urunRepo.GetirUrunSahibiID(_urun.UrunID);

                if (saticiID != -1)
                {
                    KullaniciRepository kullaniciRepo = new KullaniciRepository();
                    DataTable dt = kullaniciRepo.GetKullanicilar().Select($"KullaniciID = {saticiID}").CopyToDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        string iban = dt.Rows[0]["IBAN"]?.ToString();
                        labeliban.Text = "Satıcının IBAN: " + iban;
                    }
                    else
                    {
                        labeliban.Text = "Satıcı IBAN bilgisi bulunamadı.";
                    }
                }
                else
                {
                    labeliban.Text = "Satıcı bilgisi alınamadı.";
                }
                buttononayla.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün detayları yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HesaplaToplamFiyat()
        {
            try
            {
                DateTime baslangic = dateTimePickerbaslangic.Value.Date;
                DateTime bitis = dateTimePickerbitis.Value.Date;

                if (bitis < baslangic)
                {
                    MessageBox.Show("Bitiş tarihi, başlangıç tarihinden önce olamaz!", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int gunSayisi = (bitis - baslangic).Days + 1;
                decimal toplamFiyat = gunSayisi * _urun.Fiyat;

                textBoxfiyati.Text = toplamFiyat.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiyat hesaplanırken hata oluştu: " + ex.Message);
            }
        }
        private string dekontDosyaYolu = string.Empty;
        private void buttononayla_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(dekontDosyaYolu))
                {
                    MessageBox.Show("Lütfen dekont yükleyiniz!", "Eksik Dekont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int urunID = _urun.UrunID;
                int musteriID = OturumKullanici.AktifKullanici.KullaniciID;
                string adres = comboBoxadres.SelectedItem?.ToString();
                string odemeYontemi = comboBoxodemeturu.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(adres) || string.IsNullOrEmpty(odemeYontemi))
                {
                    MessageBox.Show("Lütfen adres ve ödeme türünü seçiniz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Odeme odeme = new Odeme
                {
                    OdemeTutari = _urun.Fiyat,
                    OdemeTarihi = DateTime.Now,
                    OdemeYontemi = odemeYontemi,
                    KullaniciID = musteriID,
                    Aktif = true,
                    DekontYolu = dekontDosyaYolu
                };

                OdemeRepository odemeRepo = new OdemeRepository();

                if (_urun.Durum == "Satılık")
                {
                    SatisIslem satis = new SatisIslem
                    {
                        UrunID = urunID,
                        KullaniciID = musteriID,
                        Fiyat = _urun.Fiyat,
                        OdemeDurumu = "Beklemede",
                        SatisTarihi = DateTime.Now,
                        Aktif = true
                    };

                    SatisRepository satisRepo = new SatisRepository();
                    int satisID = satisRepo.SatisEkle(satis);

                    if (satisID > 0)
                    {
                        odeme.SatisID = satisID;
                        bool odemeBasarili = odemeRepo.OdemeEkle(odeme);

                        if (odemeBasarili)
                            MessageBox.Show("Satış işlemi ve ödeme kaydedildi! Lütfen yönetici onayını bekleyin.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_urun.Durum == "Kiralık")
                {
                    DateTime baslangic = dateTimePickerbaslangic.Value.Date;
                    DateTime bitis = dateTimePickerbitis.Value.Date;

                    if (bitis < baslangic)
                    {
                        MessageBox.Show("Bitiş tarihi başlangıçtan önce olamaz!", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int gunSayisi = (bitis - baslangic).Days + 1;
                    decimal toplam = gunSayisi * _urun.Fiyat;

                    KiralamaIslem kiralama = new KiralamaIslem
                    {
                        UrunID = urunID,
                        KullaniciID = musteriID,
                        BaslangicTarihi = baslangic,
                        BitisTarihi = bitis,
                        KiralamaDurumu = "Beklemede",
                        TeslimDurumu = "Hazırlanıyor",
                        OdemeDurumu = "Beklemede",
                        Aktif = true,
                        Adres = comboBoxadres.SelectedItem?.ToString(),
                        Saat = "14:00"
                    };

                    KiralamaRepository kiraRepo = new KiralamaRepository();
                    int kiralamaID = kiraRepo.KiralamaEkle(kiralama);

                    if (kiralamaID > 0)
                    {
                        odeme.KiralamaID = kiralamaID;
                        odeme.OdemeTutari = toplam;

                        bool odemeBasarili = odemeRepo.OdemeEkle(odeme);

                        if (odemeBasarili)
                            MessageBox.Show("Kiralama işlemi ve ödeme kaydedildi! Lütfen yönetici onayını bekleyin.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TarihUygunlugunuKontrolEt()
        {
            DateTime baslangic = dateTimePickerbaslangic.Value.Date;
            DateTime bitis = dateTimePickerbitis.Value.Date;

            if (bitis < baslangic)
                return;

            for (DateTime tarih = baslangic; tarih <= bitis; tarih = tarih.AddDays(1))
            {
                if (doluTarihler.Contains(tarih))
                {
                    MessageBox.Show("❌ Lütfen kiralama tarihlerinizi ürünün boşta olduğu günlere göre seçiniz!", "Uygun Olmayan Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void KiralananGunleriIsaretle()
        {
            calendarKiralama.BoldedDates = doluTarihler.ToArray();
        }

        private void dateTimePickerbaslangic_ValueChanged(object sender, EventArgs e)
        {
            HesaplaToplamFiyat();
            TarihUygunlugunuKontrolEt();
        }

        private void dateTimePickerbitis_ValueChanged(object sender, EventArgs e)
        {
            HesaplaToplamFiyat();
            TarihUygunlugunuKontrolEt();
        }

        private void buttondekontYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Dekont Yükle";
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string kaynakDosya = ofd.FileName;

                    string dekontKlasoru = Path.Combine(Application.StartupPath, "Dekontlar");
                    if (!Directory.Exists(dekontKlasoru))
                        Directory.CreateDirectory(dekontKlasoru);

                    string benzersizAd = Guid.NewGuid().ToString() + Path.GetExtension(kaynakDosya);
                    string hedefDosya = Path.Combine(dekontKlasoru, benzersizAd);

                    File.Copy(kaynakDosya, hedefDosya, true);

                    pictureBoxdekont.Image = Image.FromFile(hedefDosya);
                    pictureBoxdekont.SizeMode = PictureBoxSizeMode.StretchImage;
                    dekontDosyaYolu = hedefDosya; 
                    buttononayla.Enabled = true;
                }
            }
        }
    }
}