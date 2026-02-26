using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string KullaniciTipi { get; set; }
        public bool Aktif { get; set; }
        public string IBAN { get; set; }

    }
}
