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

    public partial class FormUrunDetay : Form
    {
        private readonly Urun _urun;
        public FormUrunDetay(Urun urun)
        {
            InitializeComponent();
            _urun = urun;
        }

        private void FormUrunDetay_Load(object sender, EventArgs e)
        {
            try
            {
                UrunRepository urunRepo = new UrunRepository();
                _urun.SaticiID = urunRepo.GetirUrunSahibiID(_urun.UrunID);

                labelurunadi.Text = "Ürün: " + _urun.UrunAdi;
                labelfiyat.Text = "Fiyat: " + _urun.Fiyat.ToString("C2");
                richTextBoxaciklama.Text = _urun.Aciklama;

                if (!string.IsNullOrEmpty(_urun.ResimYolu) && File.Exists(_urun.ResimYolu))
                {
                    pictureBoxurun.Image = Image.FromFile(_urun.ResimYolu);
                    pictureBoxurun.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBoxurun.Image = null;
                    pictureBoxurun.BackColor = Color.LightGray;
                }

                KullaniciRepository kullaniciRepo = new KullaniciRepository();
                string saticiAd = kullaniciRepo.GetirAdSoyad(_urun.SaticiID);
                labelsatici.Text = "Satıcı: " + saticiAd;

                MesajRepository mesajRepo = new MesajRepository();
                bool teklifVarMi = mesajRepo.TeklifZatenKabulEdildiMi(_urun.UrunID);
                if (teklifVarMi)
                {
                    buttonteklifVer.Enabled = false;
                    buttonteklifVer.Text = "Teklif Kabul Edildi";
                    labelTeklifDurum.Visible = true;
                }
                else
                {
                    labelTeklifDurum.Visible = false;
                }
                if (_urun.Durum == "Kiralık")
                {
                    buttonteklifVer.Visible = false;
                }
                else
                {
                    buttonteklifVer.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Detaylar yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttoodeme_Click(object sender, EventArgs e)
        {
            try
            {
                Odemeler odemeForm = new Odemeler(_urun);
                odemeForm.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme sayfasına geçerken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonteklifVer_Click(object sender, EventArgs e)
        {
           try
    {
        if (_urun.Durum != "Satılık")
        {
            MessageBox.Show("Sadece satılık ürünlere teklif verilebilir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_urun.SaticiID == 0)
        {
            UrunRepository urunRepo = new UrunRepository();
            _urun.SaticiID = urunRepo.GetirUrunSahibiID(_urun.UrunID);
        }

        Mesajlasma mesajlasmaForm = new Mesajlasma(_urun);
        mesajlasmaForm.TeklifModuAc();
        this.Hide();
        mesajlasmaForm.ShowDialog();
        this.Show();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Mesajlaşma sayfasına geçerken hata oluştu:\n" + ex.Message,
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void buttonSorusor_Click(object sender, EventArgs e)
        {
            try
            {
                Mesajlasma mesajlasmaForm = new Mesajlasma(_urun);
                this.Hide();
                mesajlasmaForm.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajlaşma sayfasına geçerken hata oluştu:\n" + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
