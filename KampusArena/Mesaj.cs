using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class Mesaj
    {
        public int MesajID { get; set; }
        public int GonderenID { get; set; }
        public int AliciID { get; set; }
        public int UrunID { get; set; }
        public string MesajMetni { get; set; }
        public DateTime Tarih { get; set; }
        public decimal? FiyatTeklifi { get; set; } 
        public string Durum { get; set; } 
        public bool Aktif { get; set; } 
    }
}
