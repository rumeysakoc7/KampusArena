using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class Odeme
    {
        public int OdemeID { get; set; }
        public int? SatisID { get; set; }          
        public int? KiralamaID { get; set; }     
        public decimal OdemeTutari { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string OdemeYontemi { get; set; }
        public int KullaniciID { get; set; }
        public bool Aktif { get; set; }
        public string DekontYolu { get; set; }

    }
}
