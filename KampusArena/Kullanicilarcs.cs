using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KampusArena
{
    public partial class Kullanicilarcs : Form
    {
        private readonly KullaniciRepository _kullaniciRepository;
        public Kullanicilarcs()
        {
            InitializeComponent();
            _kullaniciRepository = new KullaniciRepository();
        }

        private void Kullanicilarcs_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxKullanicitip.SelectedIndex = -1;
                radioButtonaktif.Checked = true;
                YukleKullanicilar(true);
                
                dataGridView1.CurrentCellDirtyStateChanged += (s, ev) =>
                {
                    if (dataGridView1.IsCurrentCellDirty)
                        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sayfa yüklenirken bir hata oluştu.\n" + ex.Message);
            }
        }


        private void YukleKullanicilar(bool aktif)
        {
            try
            {
                dataGridView1.DataSource = _kullaniciRepository.GetKullanicilar(aktif);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenemedi.\n" + ex.Message);
            }
        }


        private void radioButtonaktif_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonaktif.Checked)
                YukleKullanicilar(true);
        }

        private void radioButtonpasif_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonpasif.Checked)
                YukleKullanicilar(false);
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxsoyad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxmail.Text) ||
                    string.IsNullOrWhiteSpace(textBoxsifre.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxKullanicitip.Text))
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!maskedTextBoxtelnmo.MaskFull)
                {
                    MessageBox.Show("Lütfen geçerli bir telefon numarası girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!maskedTextBoxiban.MaskFull)
                {
                    MessageBox.Show("Lütfen geçerli bir IBAN girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string email = textBoxmail.Text.Trim().ToLower();

                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Lütfen geçerli bir email adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_kullaniciRepository.EmailVarMi(email))
                {
                    if (_kullaniciRepository.AktifMi(email))
                    {
                        MessageBox.Show("Bu e-posta ile zaten kayıtlı bir kullanıcı var.");
                        return;
                    }
                    else
                    {
                        bool aktifEdildi = _kullaniciRepository.KullaniciyiAktifEt(email);
                        if (aktifEdildi)
                        {
                            MessageBox.Show("Pasif kullanıcı aktifleştirildi.");
                            YukleKullanicilar(true);
                            return;
                        }
                    }
                }

                Kullanici yeni = new Kullanici
                {
                    Ad = textBoxad.Text,
                    Soyad = textBoxsoyad.Text,
                    Email = email,
                    Telefon = maskedTextBoxtelnmo.Text,
                    Sifre = MD5_Sifreleme.MD5_Olustur(textBoxsifre.Text),
                    KullaniciTipi = comboBoxKullanicitip.Text,
                    KayitTarihi = DateTime.Now,
                    Aktif = true,
                    IBAN = string.IsNullOrEmpty(maskedTextBoxiban.Text.Replace(" ", "").Trim()) ? null : maskedTextBoxiban.Text.Trim()
                };

                if (_kullaniciRepository.AddKullanici(yeni))
                {
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                    YukleKullanicilar(true);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı eklenirken hata oluştu.\n" + ex.Message);
            }

        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null) return;

                int kullaniciId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);

                if (_kullaniciRepository.DeleteKullaniciPasif(kullaniciId))
                {
                    MessageBox.Show("Kullanıcı pasifleştirildi.");
                    YukleKullanicilar(radioButtonaktif.Checked);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işleminde hata oluştu.\n" + ex.Message);
            }
        }

        private void buttonguncelle_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.CurrentRow == null) return;

                if (string.IsNullOrWhiteSpace(textBoxad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxsoyad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxmail.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxKullanicitip.Text))
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(maskedTextBoxtelnmo.Text) || maskedTextBoxtelnmo.Text.Contains("_"))
                {
                    MessageBox.Show("Telefon numarası bu alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!maskedTextBoxiban.MaskFull)
                {
                    MessageBox.Show("Lütfen geçerli ve eksiksiz bir IBAN girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int kullaniciId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);

                string yeniAd = textBoxad.Text.Trim();
                string yeniSoyad = textBoxsoyad.Text.Trim();
                string yeniEmail = textBoxmail.Text.Trim().ToLower();
                string yeniTelefon = maskedTextBoxtelnmo.Text.Trim();
                string yeniTip = comboBoxKullanicitip.Text;
                string yeniSifre = string.IsNullOrWhiteSpace(textBoxsifre.Text)
                    ? _kullaniciRepository.GetCurrentPassword(kullaniciId)
                    : MD5_Sifreleme.MD5_Olustur(textBoxsifre.Text);
                bool yeniAktif = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Aktif"].Value);

                DataGridViewRow row = dataGridView1.CurrentRow;
                string mevcutAd = row.Cells["Ad"].Value.ToString();
                string mevcutSoyad = row.Cells["Soyad"].Value.ToString();
                string mevcutEmail = row.Cells["Email"].Value.ToString().ToLower();
                string mevcutTelefon = row.Cells["Telefon"].Value?.ToString();
                string mevcutTip = row.Cells["KullaniciTipi"].Value.ToString();
                string mevcutSifre = _kullaniciRepository.GetCurrentPassword(kullaniciId);
                bool mevcutAktif = Convert.ToBoolean(row.Cells["Aktif"].Value);

                bool aktiflikDegisti = _kullaniciRepository.GetAktifDurumu(kullaniciId) != yeniAktif;

                string yeniIBAN = maskedTextBoxiban.Text.Trim();
                string mevcutIBAN = row.Cells["IBAN"]?.Value?.ToString() ?? "";

                if (mevcutAd == yeniAd &&
                    mevcutSoyad == yeniSoyad &&
                    mevcutEmail == yeniEmail &&
                    mevcutTelefon == yeniTelefon &&
                    mevcutTip == yeniTip &&
                    mevcutSifre == yeniSifre &&
                    !aktiflikDegisti &&
                    mevcutIBAN == yeniIBAN)
                {
                    MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Kullanici guncel = new Kullanici
                {
                    KullaniciID = kullaniciId,
                    Ad = yeniAd,
                    Soyad = yeniSoyad,
                    Email = yeniEmail,
                    Telefon = yeniTelefon,
                    Sifre = yeniSifre,
                    KullaniciTipi = yeniTip,
                    Aktif = yeniAktif,
                    IBAN = yeniIBAN 
                };

                if (_kullaniciRepository.UpdateKullanici(guncel))
                {
                    MessageBox.Show("Kullanıcı başarıyla güncellendi.");
                    YukleKullanicilar(radioButtonaktif.Checked);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu.\n" + ex.Message);
            }
        }

        private void Temizle()
        {
            textBoxad.Clear();
            textBoxsoyad.Clear();
            textBoxmail.Clear();
            maskedTextBoxtelnmo.Clear();
            textBoxsifre.Clear();
            comboBoxKullanicitip.SelectedIndex = -1;
            maskedTextBoxiban.Clear();
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    textBoxad.Text = row.Cells["Ad"].Value.ToString();
                    textBoxsoyad.Text = row.Cells["Soyad"].Value.ToString();
                    textBoxmail.Text = row.Cells["Email"].Value.ToString();
                    maskedTextBoxtelnmo.Text = row.Cells["Telefon"].Value.ToString();
                    textBoxsifre.Text = "";
                    comboBoxKullanicitip.Text = row.Cells["KullaniciTipi"].Value.ToString();
                    maskedTextBoxiban.Text = row.Cells["IBAN"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satır seçerken hata oluştu.\n" + ex.Message);
            }
        }

        private void textBoxara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aranan = textBoxara.Text.Trim();

                if (string.IsNullOrEmpty(aranan))
                {
                    YukleKullanicilar(radioButtonaktif.Checked);
                }
                else
                {
                    dataGridView1.DataSource = _kullaniciRepository.AraKullanicilar(aranan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama işlemi sırasında hata oluştu.\n" + ex.Message);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
