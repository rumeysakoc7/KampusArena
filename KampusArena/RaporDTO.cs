using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class RaporDTO
    {
        public DateTime Tarih { get; set; }
        public decimal ToplamSatis { get; set; }
        public decimal ToplamKiralama { get; set; }
        public decimal ToplamGelir { get; set; }
        public int ToplamDuyuru { get; set; }
    }

}
