using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace KampusArena
{
    public class MailGonderici
    {
        public static void KiralamaBitmedenBildirimGonder(string aliciEmail, string kullaniciAdSoyad, string urunAdi, DateTime bitisTarihi, string adres, string saat)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kampusarena.7@gmail.com");
                mail.To.Add(aliciEmail);

                mail.Subject = $"Kiralama Süresi Yaklaşıyor: {urunAdi}";
                mail.Body = $"Sayın {kullaniciAdSoyad},\n\n" +
                            $"Kiralamış olduğunuz **{urunAdi}** adlı ürünün süresi **{bitisTarihi:dd.MM.yyyy}** tarihinde sona erecektir.\n" +
                            $"Lütfen ürünü saat **{saat}**'de, şu adrese teslim ediniz:\n\n" +
                            $"📍 {adres}\n\n" +
                            $"İyi günler dileriz.\n\n" +
                            $"— KampüsArena Yönetimi";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("kampusarena.7@gmail.com", "nygd syld rhos xzmk");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
