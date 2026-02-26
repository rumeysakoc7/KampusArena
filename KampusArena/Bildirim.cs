using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class Bildirim
    {
        public int BildirimID { get; set; }
        public int KullaniciID { get; set; }
        public string BildirimMetni { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }
        public bool Aktif { get; set; }
        public int UrunID { get; set; }
        public int GonderenID { get; set; }

    }

}
