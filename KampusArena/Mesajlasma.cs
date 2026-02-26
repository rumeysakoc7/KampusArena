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
    public partial class Mesajlasma : Form
    {
        private Kullanici _girisYapan;
        private int aliciID;
        private Urun _urun;
        private MesajRepository repo;

        public Mesajlasma(Urun urun)
        {
            InitializeComponent();
            _urun = urun;
            _girisYapan = OturumKullanici.AktifKullanici; 
            repo = new MesajRepository();

            UrunRepository urunRepo = new UrunRepository();
            _urun.SaticiID = urunRepo.GetirUrunSahibiID(_urun.UrunID);
        }

        public Mesajlasma(Urun urun, int digerKullaniciID)
        {
            InitializeComponent();
            _urun = urun;
            _girisYapan = OturumKullanici.AktifKullanici;
            aliciID = digerKullaniciID;
            repo = new MesajRepository();
        }

        public Mesajlasma()
        {
            InitializeComponent();
            _girisYapan = OturumKullanici.AktifKullanici;
            repo = new MesajRepository();
        }
        public void TeklifModuAc()
        {
            labelTeklif.Visible = true;
            numericTeklif.Visible = true;
        }

        private void MesajlariYukle()
        {
            try
            {
                if (_urun.Durum == "Kiralık")
                {
                    labelTeklif.Visible = false;
                }

                _urun.SaticiID = new UrunRepository().GetirUrunSahibiID(_urun.UrunID);

                richTextBoxmesaj.Clear();
                buttonTeklifiKabulEt.Visible = false;
                buttonTeklifiReddet.Visible = false;
                labelTeklifInfo.Visible = false;

                if (_urun != null && aliciID > 0)
                {
                    var mesajlar = repo.GetirMesajlar(_girisYapan.KullaniciID, aliciID, _urun.UrunID);
                    if (mesajlar.Count == 0)
                        mesajlar = repo.GetirMesajlar(aliciID, _girisYapan.KullaniciID, _urun.UrunID);

                    KullaniciRepository kRepo = new KullaniciRepository();
                    var tumKullanicilar = kRepo.GetKullanicilar();

                    foreach (var mesaj in mesajlar)
                    {
                        var dr = tumKullanicilar.Select($"KullaniciID = {mesaj.GonderenID}");
                        string gonderenAdSoyad = dr.Length > 0
                            ? $"{dr[0]["Ad"]} {dr[0]["Soyad"]}"
                            : "Bilinmiyor";

                        string mesajIcerik = $"{gonderenAdSoyad}: {mesaj.MesajMetni}";

                        if (mesaj.FiyatTeklifi.HasValue)
                        {
                            mesajIcerik += $"  (💸 Teklif: {mesaj.FiyatTeklifi.Value:C2})";

                            if (mesaj.Durum == "Teklif - Kabul")
                                mesajIcerik += " ✅ (Teklif kabul edildi)";
                            else if (mesaj.Durum == "Teklif - Reddedildi")
                                mesajIcerik += " ❌ (Teklif reddedildi)";

                            if (_girisYapan.KullaniciID == _urun.SaticiID && mesaj.Durum == "Teklif - Beklemede")
                            {
                                buttonTeklifiKabulEt.Visible = true;
                                buttonTeklifiReddet.Visible = true;
                                labelTeklifInfo.Visible = true;
                                labelTeklifInfo.Text = $"Gönderen: {gonderenAdSoyad} - Teklif: {mesaj.FiyatTeklifi:C2}";
                                buttonTeklifiKabulEt.Tag = mesaj;
                                buttonTeklifiReddet.Tag = mesaj;
                            }

                            if (_girisYapan.KullaniciID == mesaj.GonderenID && mesaj.Durum == "Teklif - Kabul")
                            {
                                buttonTeklifiGeriAl.Visible = true;
                                buttonTeklifiGeriAl.Tag = mesaj;
                            }
                        }

                        richTextBoxmesaj.AppendText(mesajIcerik + Environment.NewLine);

                        if (mesaj.AliciID == _girisYapan.KullaniciID && mesaj.Durum == "Okunmadı")
                        {
                            repo.MesajOkunduYap(mesaj.MesajID);
                        }
                    }

                    richTextBoxmesaj.SelectionStart = richTextBoxmesaj.Text.Length;
                    richTextBoxmesaj.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajlar yüklenirken hata: " + ex.Message);
            }
        }


        private void BtnKullanici_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Kullanici secilenKullanici)
            {
                aliciID = secilenKullanici.KullaniciID;
                labelkullanicibilgi.Text = secilenKullanici.Ad + " " + secilenKullanici.Soyad;

                buttonGeriDon.Visible = true;

                MesajlariYukle();
            }
        }


        private void BtnUrun_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Urun secilenUrun)
            {
                _urun = secilenUrun;
                flowLayoutPanel1.Controls.Clear();

                Label lbl = new Label();
                lbl.Text = secilenUrun.UrunAdi;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lbl.ForeColor = Color.Red;
                lbl.AutoSize = true;
                flowLayoutPanel1.Controls.Add(lbl);

                UrunRepository urunRepo = new UrunRepository();
                aliciID = urunRepo.GetirUrunSahibiID(_urun.UrunID);

                labelurunadi.Text = _urun.UrunAdi;
                pictureBoxurun.ImageLocation = _urun.ResimYolu;
                KullaniciRepository kRepo = new KullaniciRepository();
                var dt = kRepo.GetKullanicilar().Select($"KullaniciID = {aliciID}").CopyToDataTable();
                labelkullanicibilgi.Text = dt.Rows[0]["Ad"] + " " + dt.Rows[0]["Soyad"];

                var gonderenler = repo.GetirBanaMesajAtanKullanicilar(_urun.UrunID, _girisYapan.KullaniciID);
                foreach (var kullanici in gonderenler)
                {
                    Button btnKullanici = new Button();
                    btnKullanici.Text = kullanici.Ad + " " + kullanici.Soyad;
                    btnKullanici.Tag = kullanici;
                    btnKullanici.Width = flowLayoutPanel1.Width - 10;
                    btnKullanici.Height = 40;
                    btnKullanici.Click += BtnKullanici_Click;
                    flowLayoutPanel1.Controls.Add(btnKullanici);
                }
            }
        }


        private void YukleMesajUrunleri()
        {
            flowLayoutPanel1.Controls.Clear();

            var urunler = repo.GetirMesajlasilanUrunler(_girisYapan.KullaniciID);

            foreach (var urun in urunler)
            {
                Button btn = new Button();
                btn.Text = urun.UrunAdi;
                btn.Width = flowLayoutPanel1.Width - 10;
                btn.Height = 50;
                btn.Tag = urun;
                btn.BackColor = Color.PeachPuff;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Click += BtnUrun_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void Mesajlasma_Load(object sender, EventArgs e)
        {
            try
            {
                buttonGeriDon.Visible = false;
                buttonTeklifiKabulEt.Visible = false;
                labelTeklifInfo.Visible = false;
                labelTeklif.Visible = numericTeklif.Visible;
                buttonTeklifiReddet.Visible = false;


                if (_urun != null)
                {
                    UrunRepository urunRepo = new UrunRepository();
                    _urun.SaticiID = urunRepo.GetirUrunSahibiID(_urun.UrunID);

                    if (aliciID == 0)
                    {
                        aliciID = _urun.SaticiID;
                    }


                    labelurunadi.Text = _urun.UrunAdi;
                    pictureBoxurun.ImageLocation = _urun.ResimYolu;

                    KullaniciRepository kRepo = new KullaniciRepository();
                    var dt = kRepo.GetKullanicilar().Select($"KullaniciID = {aliciID}").CopyToDataTable();
                    labelkullanicibilgi.Text = dt.Rows[0]["Ad"] + " " + dt.Rows[0]["Soyad"];

                    MesajlariYukle();
                }

                else
                {
                    labelurunadi.Text = "Gelen Mesajlarım";
                    pictureBoxurun.Image = null;
                    labelkullanicibilgi.Text = _girisYapan.Ad + " " + _girisYapan.Soyad;

                    YukleMesajUrunleri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void buttongonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxmesaj.Text))
                {
                    MessageBox.Show("Lütfen mesaj giriniz.");
                    return;
                }

                decimal? teklif = null;
                string durum = "Okunmadı";

                if (numericTeklif.Visible && numericTeklif.Value > 0)
                {
                    teklif = numericTeklif.Value;
                    durum = "Teklif - Beklemede";
                }

                Mesaj mesaj = new Mesaj
                {
                    GonderenID = _girisYapan.KullaniciID,
                    AliciID = aliciID,
                    UrunID = _urun.UrunID,
                    MesajMetni = textBoxmesaj.Text,
                    Tarih = DateTime.Now,
                    FiyatTeklifi = teklif,
                    Durum = durum,
                    Aktif = true
                };

                bool eklendi = repo.MesajEkle(mesaj);
                if (eklendi)
                {
                    BildirimRepository bildirimRepo = new BildirimRepository();
                    bool zatenVar = bildirimRepo.BildirimVarMi(aliciID, _urun.UrunID, _girisYapan.KullaniciID);

                    if (!zatenVar)
                    {
                        Bildirim yeniBildirim = new Bildirim
                        {
                            KullaniciID = aliciID,
                            BildirimMetni = "Yeni bir mesajınız var.",
                            Tarih = DateTime.Now,
                            Durum = false,
                            Aktif = true,
                            UrunID = _urun.UrunID,
                            GonderenID = _girisYapan.KullaniciID
                        };
                        bildirimRepo.BildirimEkle(yeniBildirim);
                    }

                    textBoxmesaj.Clear();
                    if (numericTeklif.Visible)
                        numericTeklif.Value = 0;

                    MesajlariYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj gönderilirken hata: " + ex.Message);
            }
        }


        private void buttonsohbetisil_Click(object sender, EventArgs e)
        {
            if (_urun == null || aliciID == 0)
            {
                MessageBox.Show("Lütfen önce bir kullanıcı ve ürün seçin.");
                return;
            }

            var onay = MessageBox.Show("Bu sohbeti silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (onay == DialogResult.Yes)
            {
                bool basarili = repo.SohbetiPasifYap(_girisYapan.KullaniciID, aliciID, _urun.UrunID);

                if (basarili)
                {
                    MessageBox.Show("Sohbet başarıyla silindi.");
                    richTextBoxmesaj.Clear();
                    YukleMesajUrunleri();
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void buttonTeklifiKabulEt_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonTeklifiKabulEt.Tag is Mesaj teklifMesaj)
                {
                    UrunRepository urunRepo = new UrunRepository();
                    bool fiyatGuncellendi = urunRepo.FiyatGuncelle(teklifMesaj.UrunID, teklifMesaj.FiyatTeklifi.Value);

                    bool durumGuncellendi = repo.TeklifDurumuGuncelle(teklifMesaj.MesajID, "Teklif - Kabul");

                    if (fiyatGuncellendi && durumGuncellendi)
                    {
                        Mesaj otomatikMesaj = new Mesaj
                        {
                            GonderenID = _girisYapan.KullaniciID,
                            AliciID = teklifMesaj.GonderenID,
                            UrunID = teklifMesaj.UrunID,
                            MesajMetni = "✅ Teklifiniz kabul edilmiştir. Satın alma işlemini gerçekleştirebilirsiniz. Not: Ürünü satın almayacaksanız teklifinizi geri çekmeyi unutmayın.",
                            Tarih = DateTime.Now,
                            FiyatTeklifi = null,
                            Durum = "Okunmadı",
                            Aktif = true
                        };

                        repo.MesajEkle(otomatikMesaj);

                        repo.DigerTeklifleriReddet(teklifMesaj.UrunID, teklifMesaj.MesajID);

                        MessageBox.Show("Teklif kabul edildi. Ürün fiyatı güncellendi ve kullanıcı bilgilendirildi.");

                        buttonTeklifiKabulEt.Visible = false;
                        labelTeklifInfo.Visible = false;

                        MesajlariYukle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teklif kabul edilirken hata oluştu: " + ex.Message);
            }
        }

        private void buttonTeklifiGeriAl_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonTeklifiGeriAl.Tag is Mesaj mesaj)
                {
                    var onay = MessageBox.Show("Teklifi geri almak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        bool basarili = repo.TeklifGeriAl(mesaj.MesajID);
                        if (basarili)
                        {
                            MessageBox.Show("✅ Teklif geri alındı. Ürün yeniden tekliflere açıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            buttonTeklifiGeriAl.Visible = false;
                            MesajlariYukle();
                        }
                        else
                        {
                            MessageBox.Show("Teklif geri alınamadı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGeriDon_Click(object sender, EventArgs e)
        {
            _urun = null;
            aliciID = 0;

            labelurunadi.Text = "Gelen Mesajlarım";
            labelkullanicibilgi.Text = _girisYapan.Ad + " " + _girisYapan.Soyad;
            pictureBoxurun.Image = null;

            labelTeklif.Visible = false;
            numericTeklif.Visible = false;
            buttonTeklifiKabulEt.Visible = false;
            labelTeklifInfo.Visible = false;
            buttonTeklifiGeriAl.Visible = false;
            buttonTeklifiReddet.Visible = false;


            buttonGeriDon.Visible = false;
            YukleMesajUrunleri();
            richTextBoxmesaj.Clear();
        }

        private void buttonTeklifiReddet_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonTeklifiReddet.Tag is Mesaj teklifMesaj)
                {
                    var onay = MessageBox.Show("Bu teklifi reddetmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        bool durumGuncellendi = repo.TeklifDurumuGuncelle(teklifMesaj.MesajID, "Teklif - Reddedildi");

                        if (durumGuncellendi)
                        {
                            
                            Mesaj bilgiMesaji = new Mesaj
                            {
                                GonderenID = _girisYapan.KullaniciID,
                                AliciID = teklifMesaj.GonderenID,
                                UrunID = teklifMesaj.UrunID,
                                MesajMetni = "❌ Gönderdiğiniz teklif satıcı tarafından reddedildi.",
                                Tarih = DateTime.Now,
                                FiyatTeklifi = null,
                                Durum = "Okunmadı",
                                Aktif = true
                            };
                            repo.MesajEkle(bilgiMesaji);

                            MessageBox.Show("Teklif reddedildi ve kullanıcıya bilgi mesajı gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            buttonTeklifiKabulEt.Visible = false;
                            buttonTeklifiReddet.Visible = false;
                            labelTeklifInfo.Visible = false;

                            MesajlariYukle();
                        }
                        else
                        {
                            MessageBox.Show("Teklif reddedilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teklif reddedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
