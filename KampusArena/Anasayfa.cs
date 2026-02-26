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
    public partial class Anasayfa : Form
    {
        private readonly DuyuruRepository _duyuruRepo = new DuyuruRepository();
        private readonly BildirimRepository _bildirimRepo = new BildirimRepository();
        private readonly Kullanici _kullanici;
        private string yetki;
        private Kullanici girisYapanKullanici;
      

        public Anasayfa(Kullanici kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            yetki = kullanici.KullaniciTipi;
            girisYapanKullanici = kullanici;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                new SatisVeKiralikTakip(OturumKullanici.AktifKullanici).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form açılırken hata oluştu:\n" + ex.Message);
            }

        }
     
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            try
            {
                BildirimRepository bildirimRepo = new BildirimRepository();
                int okunmamis = bildirimRepo.GetirOkunmamisBildirimSayisi(_kullanici.KullaniciID);

                if (okunmamis > 0)
                    buttonBildirimler.Text = $"Bildirimler ({okunmamis})";
                else
                    buttonBildirimler.Text = "Bildirimler";

                timerKiralamaKontrol.Start();

                dataGridViewduyurular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewduyurular.AllowUserToAddRows = false;


                OturumYonetici.Baslat(this);
                YukleDuyurular("DESC");

                buttonurunler.Enabled = false;
                buttonDuyuru.Enabled = false;
                buttonSatisKiralama.Enabled = false;
                buttonilanduzen.Enabled = false;
                buttonBildirimler.Enabled = false;
                buttonProfilim.Enabled = false;
                buttonKategoriler.Enabled = false;
                buttonRaporlar.Enabled = false;
                buttonkullanicilar.Enabled = false;
                groupBoxadmin.Visible = false;
                buttonodemeonay.Enabled = false;

                var ortakKullaniciTipleri = new[] { "Öğrenci", "Akademisyen", "Personel" };

                if (yetki == "Admin")
                {
                    buttonurunler.Enabled = true;
                    buttonDuyuru.Enabled = true;
                    buttonSatisKiralama.Enabled = true;
                    buttonilanduzen.Enabled = true;
                    buttonBildirimler.Enabled = true;
                    buttonProfilim.Enabled = true;
                    buttonKategoriler.Enabled = true;
                    buttonRaporlar.Enabled = true;
                    buttonkullanicilar.Enabled = true;
                    buttonodemeonay.Enabled = true;
                    buttonmesajlar.Enabled = true;
                    groupBoxadmin.Visible = true;
                }
                else if (ortakKullaniciTipleri.Contains(yetki.Trim(), StringComparer.OrdinalIgnoreCase))

                {
                    buttonurunler.Enabled = true;
                    buttonDuyuru.Enabled = true;
                    buttonSatisKiralama.Enabled = true;
                    buttonilanduzen.Enabled = true;
                    buttonBildirimler.Enabled = true;
                    buttonmesajlar.Enabled=true;
                    buttonProfilim.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Geçersiz kullanıcı tipi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anasayfa yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonKategoriler_Click(object sender, EventArgs e)
        {
            try
            {
                new Kategoriler().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler formu açılamadı:\n" + ex.Message);
            }

        }

        private void buttonurunler_Click(object sender, EventArgs e)
        {
            try
            {
                new Urunlercs().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler formu açılamadı:\n" + ex.Message);
            }
        }

        private void buttonDuyuru_Click(object sender, EventArgs e)
        {
            try
            {
                DuyuruDuzenle duyuruForm = new DuyuruDuzenle(girisYapanKullanici, this);
                duyuruForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru düzenleme formu açılamadı:\n" + ex.Message);
            }
        }

        private void buttonilanduzen_Click(object sender, EventArgs e)
        {
            try
            {
                new IlanDuzen_ekle(girisYapanKullanici).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İlan düzenleme formu açılamadı:\n" + ex.Message);
            }
        }

        private void buttonBildirimler_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Bildirimler(_kullanici); 
                frm.FormClosed += (s, args) => BildirimGuncelle(); 
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bildirimler formu açılamadı:\n" + ex.Message);
            }
        }

        private void buttonProfilim_Click(object sender, EventArgs e)
        {
            try
            {
                new Profilim().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profilim formu açılamadı:\n" + ex.Message);
            }
        }


        private void buttonRaporlar_Click(object sender, EventArgs e)
        {
            try
            {
                new Raporlar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Raporlar formu açılamadı:\n" + ex.Message);
            }
        }

        private void buttonkullanicilar_Click(object sender, EventArgs e)
        {
            try
            {
                new Kullanicilarcs().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar formu açılamadı:\n" + ex.Message);
            }
        }


        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                OturumYonetici.Durdur();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çıkış sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void YukleDuyurular(string siralama = "DESC")
        {
            try
            {
                dataGridViewduyurular.DataSource = _duyuruRepo.GetDuyurularWithUserInfo(siralama);
                _duyuruRepo.OtomatikKaldirGecerliligiKontrolEt();
                dataGridViewduyurular.Columns["Tarih"].HeaderText = "Başlangıç Tarihi";
                dataGridViewduyurular.Columns["SonTarih"].HeaderText = "Bitiş Tarihi";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyurular yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radioButtonenyeniler_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (radioButtonenyeniler.Checked)
                    YukleDuyurular("DESC");
            }
            catch (Exception ex)
            {
                MessageBox.Show("En yeni duyurular yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void radioButtoneskiler_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtoneskiler.Checked)
                    YukleDuyurular("ASC");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eski duyurular yüklenirken hata oluştu:\n" + ex.Message);
            }
        }
        public void DuyurulariGuncelle()
        {
            YukleDuyurular("DESC");
        }

        private void dataGridViewduyurular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dataGridViewduyurular.Rows[e.RowIndex];
                    string baslik = row.Cells["Baslik"].Value.ToString();
                    string aciklama = row.Cells["Aciklama"].Value.ToString();
                    string yayinlayan = row.Cells["KullaniciAdi"].Value.ToString();
                    string tip = row.Cells["KullaniciTipi"].Value.ToString();
                    string tarih = Convert.ToDateTime(row.Cells["PaylasimTarihi"].Value).ToString("dd MMMM yyyy");

                    MessageBox.Show(
                        $"Paylaşan: {yayinlayan} ({tip})\nTarih: {tarih}\n\n{baslik}\n\n{aciklama}",
                        "DUYURU DETAY",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru detayı görüntülenemedi:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonodemeonay_Click(object sender, EventArgs e)
        {
            try
            {
                if (yetki == "Admin")
                {
                    AdminOdemeOnay form = new AdminOdemeOnay();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Bu sayfaya sadece adminler erişebilir.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme onay formu açılamadı:\n" + ex.Message);
            }
        }

        private void timerKiralamaKontrol_Tick(object sender, EventArgs e)
        {
            KiralamaRepository repo = new KiralamaRepository();
            var liste = repo.GetTeslimHatirlatilacakKullanicilar();

            foreach (var item in liste)
            {
                MailGonderici.KiralamaBitmedenBildirimGonder(
                    item.Email,
                    item.AdSoyad,
                    item.UrunAdi,
                    item.BitisTarihi,
                    item.Adres,
                    item.Saat
                );
                repo.BildirimGonderildiOlarakIsaretle(item.Email, item.BitisTarihi);
            }

        }

        private void buttonmesajlar_Click(object sender, EventArgs e)
        {
            try
            {
                new Mesajlasma().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajlaşma formu açılamadı:\n" + ex.Message);
            }
        }

        public void BildirimGuncelle()
        {
            BildirimRepository repo = new BildirimRepository();
            int okunmamis = repo.GetirOkunmamisBildirimSayisi(_kullanici.KullaniciID);

            if (okunmamis > 0)
                buttonBildirimler.Text = $"Bildirimler ({okunmamis})";
            else
                buttonBildirimler.Text = "Bildirimler";
        }

    }
}
