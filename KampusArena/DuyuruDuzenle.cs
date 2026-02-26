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
    
    public partial class DuyuruDuzenle : Form
    {
        private readonly DuyuruRepository _duyuruRepo = new DuyuruRepository();
        private int seciliDuyuruId = -1;
        private Kullanici _aktifKullanici;
        private Anasayfa _anasayfa;

        public DuyuruDuzenle(Kullanici kullanici, Anasayfa anasayfa)
        {
            InitializeComponent();
            _aktifKullanici = kullanici;
            _anasayfa = anasayfa;
        }

        private void DuyuruDuzenle_Load(object sender, EventArgs e)
        {
            try
            {
                checkBoxkaldir.Checked = false;
                dateTimePickerbaslangic.Value = DateTime.Today;
                dateTimePickerbitis.Value = DateTime.Today.AddDays(7);
                YukleDuyurular();
               dataGridViewduyurularım.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewduyurularım.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyurular yüklenirken hata oluştu: " + ex.Message);
            }
        }
        private void YukleDuyurular()
        {
            try
            {
                dataGridViewduyurularım.DataSource = _duyuruRepo.GetDuyurularim(_aktifKullanici.KullaniciID);
                dataGridViewduyurularım.Columns["Aktif"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyurular getirilemedi: " + ex.Message);
            }

        }
        private void buttonyayinla_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxbaslik.Text) ||
            string.IsNullOrWhiteSpace(richTextBoxduyuru.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Duyuru duyuru = new Duyuru
                {
                    KullaniciID = _aktifKullanici.KullaniciID,
                    Baslik = textBoxbaslik.Text,
                    Aciklama = richTextBoxduyuru.Text,
                    Tarih = dateTimePickerbaslangic.Value,
                    SonTarih = dateTimePickerbitis.Value,
                    Aktif = true,
                    OtomatikKaldir = checkBoxkaldir.Checked,

                };

                if (_duyuruRepo.AddDuyuru(duyuru))
                {
                    MessageBox.Show("Duyuru yayınlandı.");
                    YukleDuyurular();
                    Temizle();
                    _anasayfa?.DuyurulariGuncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru yayınlanamadı: " + ex.Message);
            }
        }

        private void buttonduzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliDuyuruId == -1) return;

                if (string.IsNullOrWhiteSpace(textBoxbaslik.Text) || string.IsNullOrWhiteSpace(richTextBoxduyuru.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                DataGridViewRow row = dataGridViewduyurularım.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r.Cells["DuyuruID"].Value) == seciliDuyuruId);

                if (row == null) return;

                bool degisiklikVar =
                    textBoxbaslik.Text != row.Cells["Baslik"].Value.ToString() ||
                    richTextBoxduyuru.Text != row.Cells["Aciklama"].Value.ToString() ||
                    dateTimePickerbaslangic.Value.Date != Convert.ToDateTime(row.Cells["Tarih"].Value).Date ||
                    dateTimePickerbitis.Value.Date != Convert.ToDateTime(row.Cells["SonTarih"].Value).Date ||
                    checkBoxkaldir.Checked != Convert.ToBoolean(row.Cells["OtomatikKaldir"].Value);

                if (!degisiklikVar)
                {
                    MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Duyuru duyuru = new Duyuru
                {
                    DuyuruID = seciliDuyuruId,
                    Baslik = textBoxbaslik.Text,
                    Aciklama = richTextBoxduyuru.Text,
                    Tarih = dateTimePickerbaslangic.Value,
                    SonTarih = dateTimePickerbitis.Value,
                    Aktif = true,
                    OtomatikKaldir = checkBoxkaldir.Checked
                };

                if (_duyuruRepo.UpdateDuyuru(duyuru))
                {
                    MessageBox.Show("Duyuru güncellendi.");
                    YukleDuyurular();
                    Temizle();
                    _anasayfa?.DuyurulariGuncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru güncellenemedi: " + ex.Message);
            }
        }

        private void buttonKaldir_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliDuyuruId == -1) return;

                if (_duyuruRepo.SoftDeleteDuyuru(seciliDuyuruId))
                {
                    MessageBox.Show("Duyuru kaldırıldı.");
                    YukleDuyurular();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru kaldırılırken hata oluştu: " + ex.Message);
            }
        }

        private void Temizle()
        {
            seciliDuyuruId = -1;
            textBoxbaslik.Clear();
            richTextBoxduyuru.Clear();
            dateTimePickerbaslangic.Value = DateTime.Today;
            dateTimePickerbitis.Value = DateTime.Today.AddDays(7);
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            try
            {
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alanlar temizlenirken hata oluştu: " + ex.Message);
            }
        }

        private void dataGridViewduyurularım_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dataGridViewduyurularım.Rows[e.RowIndex];
                    seciliDuyuruId = Convert.ToInt32(row.Cells["DuyuruID"].Value);
                    textBoxbaslik.Text = row.Cells["Baslik"].Value.ToString();
                    richTextBoxduyuru.Text = row.Cells["Aciklama"].Value.ToString();
                    dateTimePickerbaslangic.Value = Convert.ToDateTime(row.Cells["Tarih"].Value);
                    dateTimePickerbitis.Value = Convert.ToDateTime(row.Cells["SonTarih"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru bilgileri yüklenemedi: " + ex.Message);
            }
        }
    }
}
