using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public string Durum { get; set; } 
        public bool KiralamaDurumu { get; set; } 
        public int KategoriID { get; set; }
        public int SaticiID { get; set; }
        public bool Aktif { get; set; }
    }

}
