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
    public partial class KayitOLcs : Form
    {
        private readonly KullaniciRepository _kullaniciRepository;
        public KayitOLcs()
        {
            InitializeComponent();
            _kullaniciRepository = new KullaniciRepository();
        }

        private void buttoniptal_Click(object sender, EventArgs e)
        {

            try
            {
                this.Close();
                Formkullanicigiris girisFormu = new Formkullanicigiris();
                girisFormu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş ekranına dönüş sırasında hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonkayitol_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (!checkBoxonay.Checked)
                {
                    MessageBox.Show("Kayıt olabilmek için kişisel veri işleme onayını vermeniz gerekmektedir.",
                        "Onay Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ad = textBoxad.Text.Trim();
                string soyad = textBoxsoyad.Text.Trim();
                string email = textBoxmail.Text.Trim().ToLower();
                string sifre = textBoxsifre.Text.Trim();
                string telefon = maskedTextBoxtelno.Text.Trim();
                string IBAN = maskedTextBoxiban.Text.Trim();
                string kullaniciTipi = comboBoxKullaniciTipi.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(kullaniciTipi) || !maskedTextBoxtelno.MaskFull || !maskedTextBoxiban.MaskFull)
                {
                    MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Lütfen geçerli bir email adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_kullaniciRepository.EmailVarMi(email))
                {
                    if (!_kullaniciRepository.AktifMi(email))
                    {
                        DialogResult sonuc = MessageBox.Show(
                            "Bu e-posta adresiyle daha önceden kayıt olunmuş ama hesabınız pasif durumda. \n" +
                            "Hesabınızı yeniden aktif hale getirmek ve bilgilerinizi güncellemek ister misiniz?",
                            "Hesap Pasif",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (sonuc == DialogResult.Yes)
                        {
                            Kullanici guncelle = new Kullanici
                            {
                                Ad = ad,
                                Soyad = soyad,
                                Email = email,
                                Sifre = MD5_Sifreleme.MD5_Olustur(sifre),
                                Telefon = string.IsNullOrEmpty(telefon) ? null : telefon,
                                IBAN = string.IsNullOrEmpty(maskedTextBoxiban.Text.Replace(" ", "").Trim()) ? null : maskedTextBoxiban.Text.Trim(),
                                KullaniciTipi = kullaniciTipi,
                                KayitTarihi = DateTime.Now,
                                Aktif = true
                            };

                            if (_kullaniciRepository.UpdateKullaniciByEmail(guncelle))
                            {
                                MessageBox.Show("Hesabınız yeniden aktif hale getirildi ve bilgileriniz güncellendi.",
                                    "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                new Formkullanicigiris().Show();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Hesap güncellenirken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu e-posta adresi ile zaten aktif bir kayıt bulunuyor.",
                            "Zaten Kayıtlı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Kullanici yeniKullanici = new Kullanici
                {
                    Ad = ad,
                    Soyad = soyad,
                    Email = email,
                    Sifre = MD5_Sifreleme.MD5_Olustur(sifre),
                    Telefon = string.IsNullOrEmpty(telefon) ? null : telefon,
                    IBAN = string.IsNullOrEmpty(maskedTextBoxiban.Text.Replace(" ", "").Trim()) ? null : maskedTextBoxiban.Text.Trim(),
                    KullaniciTipi = kullaniciTipi,
                    KayitTarihi = DateTime.Now,
                    Aktif = true
                };

                bool basarili = _kullaniciRepository.AddKullanici(yeniKullanici);
                if (basarili)
                {
                    MessageBox.Show("Kayıt başarıyla tamamlandı! Giriş yapabilirsiniz.",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    new Formkullanicigiris().Show();
                }
                else
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt sırasında bir hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KayitOLcs_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxKullaniciTipi.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
