using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class SatisIslem
    {
        public int UrunID { get; set; }
        public int KullaniciID { get; set; }
        public decimal Fiyat { get; set; }
        public string OdemeDurumu { get; set; }
        public DateTime SatisTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
