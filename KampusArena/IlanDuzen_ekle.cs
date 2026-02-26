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
    public partial class IlanDuzen_ekle : Form
    {
        private readonly UrunRepository _urunRepo = new UrunRepository();
        private readonly KategoriRepository _kategoriRepo = new KategoriRepository();
        private Kullanici _aktifKullanici;
        private int seciliUrunID = -1;

        public IlanDuzen_ekle(Kullanici kullanici)
        {
            InitializeComponent();
            _aktifKullanici = kullanici;
        }

        private void UrunlerimiYukle()
        {
            try
            {
                DataTable dt = _urunRepo.GetUrunlerim(_aktifKullanici.KullaniciID);
                dataGridViewurunlerim.DataSource = dt;

                dataGridViewurunlerim.Columns["Aktif"].Visible = false;
                dataGridViewurunlerim.Columns["SaticiID"].Visible = false;

                foreach (DataGridViewRow row in dataGridViewurunlerim.Rows)
                {
                    int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);
                    bool satildi = _urunRepo.UrunSatinAlinmisMi(urunID);
                    bool kirada = _urunRepo.UrunKiradaMi(urunID);

                    if (satildi)
                    {
                        row.DefaultCellStyle.BackColor = Color.IndianRed; 
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.Cells["UrunAdi"].Value += " (Satıldı)";
                    }
                    else if (kirada)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose; 
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        if (row.Cells["KiralamaDurumu"] is DataGridViewCheckBoxCell checkbox)
                        {
                            checkbox.Value = true;
                        }
                    }
                    else
                    {
                        if (row.Cells["KiralamaDurumu"] is DataGridViewCheckBoxCell checkbox)
                        {
                            checkbox.Value = false;
                        }

                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        
        private void buttonekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxkategori.SelectedIndex == -1 || string.IsNullOrWhiteSpace(textBoxurunad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxfiyat.Text) || (!radioButtonsatilik.Checked && !radioButtonKiralik.Checked))
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurunuz.");
                    return;
                }

                Urun yeniUrun = new Urun
                {
                    UrunAdi = textBoxurunad.Text,
                    Fiyat = decimal.Parse(textBoxfiyat.Text),
                    ResimYolu = textBoxresimyol.Text,
                    Aciklama = richTextBoxaciklama.Text,
                    Durum = radioButtonsatilik.Checked ? "Satılık" : "Kiralık",
                    KiralamaDurumu = false,
                    KategoriID = Convert.ToInt32(comboBoxkategori.SelectedValue),
                    SaticiID = _aktifKullanici.KullaniciID,
                    Aktif = true
                };

                if (_urunRepo.AddUrun(yeniUrun))
                {
                    MessageBox.Show("Ürün başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                    UrunlerimiYukle();
                }
                else
                {
                    MessageBox.Show("Ürün eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken beklenmeyen bir hata oluştu:\n" + ex.Message);
            }
        }
        private void Temizle()
        {
            textBoxurunad.Clear();
            textBoxfiyat.Clear();
            textBoxresimyol.Clear();
            richTextBoxaciklama.Clear();
            comboBoxkategori.SelectedIndex = -1;
            radioButtonsatilik.Checked = false;
            radioButtonKiralik.Checked = false;
            pictureBoxurun.Image = null;
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliUrunID == -1) return;

                if (_urunRepo.SoftDeleteUrun(seciliUrunID))
                {
                    MessageBox.Show("Ürün kaldırıldı.");
                    Temizle();
                    UrunlerimiYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliUrunID == -1)
                {
                    MessageBox.Show("Lütfen güncellenecek bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxkategori.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(textBoxurunad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxfiyat.Text) ||
                    (!radioButtonsatilik.Checked && !radioButtonKiralik.Checked))
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dataGridViewurunlerim.CurrentRow;
                string mevcutAd = row.Cells["UrunAdi"].Value.ToString();
                string mevcutFiyat = row.Cells["Fiyat"].Value.ToString();
                string mevcutAciklama = row.Cells["Aciklama"].Value.ToString();
                string mevcutResimYolu = row.Cells["ResimYolu"].Value.ToString();
                string mevcutDurum = row.Cells["Durum"].Value.ToString();
                int mevcutKategoriID = Convert.ToInt32(row.Cells["KategoriID"].Value);


                if (mevcutAd == textBoxurunad.Text.Trim() &&
                    mevcutFiyat == textBoxfiyat.Text.Trim() &&
                    mevcutAciklama == richTextBoxaciklama.Text.Trim() &&
                    mevcutResimYolu == textBoxresimyol.Text.Trim() &&
                    mevcutDurum == (radioButtonsatilik.Checked ? "Satılık" : "Kiralık") &&
                    mevcutKategoriID == Convert.ToInt32(comboBoxkategori.SelectedValue))
                {
                    MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Urun guncel = new Urun
                {
                    UrunID = seciliUrunID,
                    UrunAdi = textBoxurunad.Text.Trim(),
                    Fiyat = decimal.Parse(textBoxfiyat.Text.Trim()),
                    ResimYolu = textBoxresimyol.Text.Trim(),
                    Aciklama = richTextBoxaciklama.Text.Trim(),
                    Durum = radioButtonsatilik.Checked ? "Satılık" : "Kiralık",
                    KiralamaDurumu = false,
                    KategoriID = Convert.ToInt32(comboBoxkategori.SelectedValue),
                    SaticiID = _aktifKullanici.KullaniciID,
                    Aktif = true
                };

                if (_urunRepo.UpdateUrun(guncel))
                {
                    MessageBox.Show("Ürün güncellendi.");
                    Temizle();
                    UrunlerimiYukle();
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void KategoriYukle()
        {
            try
            {
                comboBoxkategori.DisplayMember = "KategoriAdi";
                comboBoxkategori.ValueMember = "KategoriID";
                comboBoxkategori.DataSource = _kategoriRepo.GetKategoriler();
                comboBoxkategori.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void dataGridViewurunlerim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewurunlerim.Rows[e.RowIndex];
                seciliUrunID = Convert.ToInt32(row.Cells["UrunID"].Value);
                textBoxurunad.Text = row.Cells["UrunAdi"].Value.ToString().Replace(" (Satıldı)", "");
                textBoxfiyat.Text = row.Cells["Fiyat"].Value.ToString();
                textBoxresimyol.Text = row.Cells["ResimYolu"].Value.ToString();
                richTextBoxaciklama.Text = row.Cells["Aciklama"].Value.ToString();
                comboBoxkategori.SelectedValue = row.Cells["KategoriID"].Value;
                radioButtonsatilik.Checked = row.Cells["Durum"].Value.ToString() == "Satılık";
                radioButtonKiralik.Checked = row.Cells["Durum"].Value.ToString() == "Kiralık";

                try
                {
                    string resimYolu = row.Cells["ResimYolu"].Value?.ToString();
                    textBoxresimyol.Text = resimYolu;

                    if (!string.IsNullOrWhiteSpace(resimYolu) && File.Exists(resimYolu))
                    {
                        pictureBoxurun.Image = Image.FromFile(resimYolu);
                        pictureBoxurun.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBoxurun.Image = null;
                        MessageBox.Show("Resim dosyası bulunamadı:\n" + resimYolu, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    pictureBoxurun.Image = null;
                    MessageBox.Show("Resim yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                bool satildi = _urunRepo.UrunSatinAlinmisMi(seciliUrunID);
                bool kirada = _urunRepo.UrunKiradaMi(seciliUrunID);

                if (satildi)
                {
                    buttonGuncelle.Enabled = false;
                    buttonSil.Enabled = false;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    MessageBox.Show("Bu ürün satılmıştır. Güncelleme veya silme yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kirada)
                {
                    buttonGuncelle.Enabled = false;
                    buttonSil.Enabled = false;
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                    MessageBox.Show("Bu ürün şu anda kiradadır. Kiralama süresi bitene kadar değiştirilemez.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    buttonGuncelle.Enabled = true;
                    buttonSil.Enabled = true;
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

        }

        private void IlanDuzen_ekle_Load(object sender, EventArgs e)
        {
            dataGridViewurunlerim.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewurunlerim.AllowUserToAddRows = false;
            KategoriYukle();
            UrunlerimiYukle();
        }
    }

}
