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
    public partial class FormSifremiunuttum : Form
    {
        private readonly KullaniciRepository _kullaniciRepository;

        public FormSifremiunuttum()
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
                MessageBox.Show("Giriş ekranına dönülürken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBoxmail.Text.Trim();
                string telefon = maskedTextBoxtelno.Text.Trim();
                string yeniSifre = textBoxsifre.Text.Trim();
                string sifreTekrar = textBoxsifretekrar.Text.Trim();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefon) ||
                    string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(sifreTekrar))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (yeniSifre != sifreTekrar)
                {
                    MessageBox.Show("Şifreler uyuşmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sifreMD5 = MD5_Sifreleme.MD5_Olustur(yeniSifre);

                bool sonuc = _kullaniciRepository.SifreGuncelle(email, telefon, sifreMD5);
                if (sonuc)
                {
                    MessageBox.Show("Şifreniz başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Formkullanicigiris girisFormu = new Formkullanicigiris();
                    girisFormu.Show();
                }
                else
                {
                    MessageBox.Show("E-posta ve telefon bilgileri eşleşmedi veya kullanıcı aktif değil.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şifre güncelleme sırasında bir hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
