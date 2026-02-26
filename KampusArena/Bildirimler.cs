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
    public partial class Bildirimler : Form
    {
        private readonly Kullanici _girisYapan;
        public Bildirimler(Kullanici kullanici)
        {
            InitializeComponent();
            _girisYapan = kullanici;
        }

        private List<Bildirim> _bildirimListesi;

        private void BildirimleriYukle(string siralama)
        {
            try
            {
                BildirimRepository repo = new BildirimRepository();
                _bildirimListesi = repo.GetirKullaniciBildirimleri(_girisYapan.KullaniciID, siralama);

                listBoxBildirimler.Items.Clear();
                foreach (var b in _bildirimListesi)
                {
                    listBoxBildirimler.Items.Add($"{b.Tarih:g} - {b.BildirimMetni}");
                }

                repo.TumBildirimleriOkunduYap(_girisYapan.KullaniciID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bildirimler yüklenirken hata oluştu:\n" + ex.Message);
            }
        }


        private void Bildirimler_Load(object sender, EventArgs e)
        {
            radioButtonenyeniler.Checked = true;
        }

        private void radioButtonenyeniler_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonenyeniler.Checked)
                BildirimleriYukle("DESC");
        }

        private void radioButtoneskiler_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtoneskiler.Checked)
                BildirimleriYukle("ASC");
        }

        private void listBoxBildirimler_DoubleClick(object sender, EventArgs e)
        {
            int secilenIndex = listBoxBildirimler.SelectedIndex;
            if (secilenIndex >= 0 && secilenIndex < _bildirimListesi.Count)
            {
                var secilenBildirim = _bildirimListesi[secilenIndex];
                if (secilenBildirim.UrunID > 0 && secilenBildirim.GonderenID > 0)
                {
                    UrunRepository urunRepo = new UrunRepository();
                    Urun urun = urunRepo.GetirUrunByID(secilenBildirim.UrunID);

                    if (urun != null)
                    {
                        Mesajlasma mesajForm = new Mesajlasma(urun, secilenBildirim.GonderenID);
                        mesajForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ürün bulunamadı.");
                    }

                }
                else
                {
                    MessageBox.Show("Bu bildirim yönlendirilemez (veriler eksik).");
                }
            }
        }

        private void buttontemizle_Click(object sender, EventArgs e)
        {
            var onay = MessageBox.Show("Tüm bildirimleri silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                BildirimRepository repo = new BildirimRepository();
                bool sonuc = repo.TumBildirimleriPasifYap(_girisYapan.KullaniciID);

                if (sonuc)
                {
                    MessageBox.Show("Bildirim kutusu başarıyla temizlendi.");
                    listBoxBildirimler.Items.Clear(); 
                }
                else
                {
                    MessageBox.Show("Bildirimler silinemedi.");
                }
            }
        }
    }
}
