using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class KiralamaIslem
    {
        public int UrunID { get; set; }
        public int KullaniciID { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string KiralamaDurumu { get; set; }
        public string TeslimDurumu { get; set; }
        public string OdemeDurumu { get; set; }
        public bool Aktif { get; set; }
        public string Adres { get; set; }
        public string Saat { get; set; }

    }
}
