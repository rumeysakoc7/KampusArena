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
    public partial class Profilim : Form
    {
        public Profilim()
        {
            InitializeComponent();
        }

        private void Profilim_Load(object sender, EventArgs e)
        {
            try
            {
                var aktifKullanici = OturumKullanici.AktifKullanici;
                if (aktifKullanici == null)
                {
                    MessageBox.Show("Kullanıcı oturumu bulunamadı.");
                    return;
                }

                KullaniciRepository repo = new KullaniciRepository();
                DataTable dt = repo.GetKullanicilar().Select($"KullaniciID = {aktifKullanici.KullaniciID}").CopyToDataTable();

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    textBoxad.Text = row["Ad"].ToString();
                    textBoxsoyad.Text = row["Soyad"].ToString();
                    textBoxMail.Text = row["Email"].ToString();
                    maskedTextBoxtelno.Text = row["Telefon"].ToString();
                    textBoxSifre.Text = row["Sifre"].ToString();
                    maskedTextBoxiban.Text = row["IBAN"]?.ToString(); 
                }

                
                UrunRepository urunRepo = new UrunRepository();
                List<string> urunler = urunRepo.GetirKullaniciUrunleri(aktifKullanici.KullaniciID);
                listBoxurunler.Items.Clear();
                listBoxurunler.Items.AddRange(urunler.ToArray());
                listBoxurunler.HorizontalScrollbar = true;

                int maxWidth = 0;
                using (Graphics g = listBoxurunler.CreateGraphics())
                {
                    foreach (var item in listBoxurunler.Items)
                    {
                        int itemWidth = (int)g.MeasureString(item.ToString(), listBoxurunler.Font).Width;
                        if (itemWidth > maxWidth)
                            maxWidth = itemWidth;
                    }
                }
                listBoxurunler.HorizontalExtent = maxWidth + 10;
                this.ActiveControl = buttonguncelle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profil yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxsoyad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxMail.Text) ||
                    string.IsNullOrWhiteSpace(maskedTextBoxtelno.Text) ||
                    string.IsNullOrWhiteSpace(textBoxSifre.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!maskedTextBoxiban.MaskFull)
                {
                    MessageBox.Show("Lütfen geçerli ve eksiksiz bir IBAN giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var aktif = OturumKullanici.AktifKullanici;

                if (textBoxad.Text.Trim() == aktif.Ad &&
                    textBoxsoyad.Text.Trim() == aktif.Soyad &&
                    textBoxMail.Text.Trim() == aktif.Email &&
                    maskedTextBoxtelno.Text.Trim() == aktif.Telefon &&
                    textBoxSifre.Text.Trim() == aktif.Sifre &&
                    maskedTextBoxiban.Text.Trim() == (aktif.IBAN ?? ""))
                {
                    MessageBox.Show("Hiçbir değişiklik yapılmadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var guncel = new Kullanici
                {
                    KullaniciID = aktif.KullaniciID,
                    Ad = textBoxad.Text.Trim(),
                    Soyad = textBoxsoyad.Text.Trim(),
                    Email = textBoxMail.Text.Trim(),
                    Telefon = maskedTextBoxtelno.Text.Trim(),
                    Sifre = textBoxSifre.Text.Trim(),
                    KullaniciTipi = aktif.KullaniciTipi,
                    Aktif = true,
                    IBAN = maskedTextBoxiban.Text.Trim() 
                };

                bool basarili = new KullaniciRepository().UpdateKullanici(guncel);

                if (basarili)
                {
                    MessageBox.Show("Bilgileriniz başarıyla güncellendi.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OturumKullanici.AktifKullanici = guncel; 
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
