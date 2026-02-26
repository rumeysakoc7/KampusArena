using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace KampusArena
{
    public partial class Formkullanicigiris : Form
    {
        private readonly KullaniciRepository _kullaniciRepository;


        public Formkullanicigiris()
        {
            InitializeComponent();
            _kullaniciRepository = new KullaniciRepository();
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBoxmail.Text.Trim();
                string sifre = MD5_Sifreleme.MD5_Olustur(textBoxsifre.Text.Trim());

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
                {
                    MessageBox.Show("Lütfen email ve þifreyi doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kullanici = _kullaniciRepository.Login(email, sifre);

                if (kullanici != null)
                {
                    if (!kullanici.Aktif)
                    {
                        MessageBox.Show("Hesabýnýz pasif durumda. Lütfen yöneticiyle iletiþime geçin.", "Eriþim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    OturumKullanici.AktifKullanici = kullanici;
                    Anasayfa anaSayfa = new Anasayfa(kullanici);
                    anaSayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email veya þifre yanlýþ, lütfen tekrar deneyin.", "Giriþ Baþarýsýz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriþ sýrasýnda bir hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelkayitol_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                KayitOLcs kayitolForm = new KayitOLcs();
                kayitolForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayýt sayfasý açýlýrken hata oluþtu:\n" + ex.Message);
            }
        }

        private void linkLabelSifremiunuttum_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FormSifremiunuttum sifremiunuttumForm = new FormSifremiunuttum();
                sifremiunuttumForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Þifre yenileme ekraný açýlýrken hata oluþtu:\n" + ex.Message);
            }
        }

        private void textBoxmail_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxmail.Text;
            int atIndex = text.IndexOf('@');

            if (atIndex >= 0 && text.Length <= atIndex + 1)
            {
                string girilenIlkKisim = text.Substring(0, atIndex + 1);
                contextMenuEmail.Items.Clear();

                string[] domainler = { "gmail.com", "hotmail.com", "outlook.com", "ogr.uludag.edu.tr" };
                foreach (var domain in domainler)
                {
                    var item = new ToolStripMenuItem(girilenIlkKisim + domain);
                    item.Click += (s, args) =>
                    {
                        textBoxmail.Text = item.Text;
                        textBoxmail.SelectionStart = textBoxmail.Text.Length;
                    };
                    contextMenuEmail.Items.Add(item);
                }

                if (text.EndsWith("@"))
                {
                    contextMenuEmail.Show(textBoxmail, new Point(0, textBoxmail.Height));
                }
                else
                {
                    contextMenuEmail.Hide();
                }
            }
            else
            {
                contextMenuEmail.Hide();
            }
        }
    }
}
