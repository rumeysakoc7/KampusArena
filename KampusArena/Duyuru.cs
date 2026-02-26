using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class Duyuru
    {
        public int DuyuruID { get; set; }
        public int KullaniciID { get; set; } 
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime SonTarih { get; set; }
        public bool Aktif { get; set; }
        public bool OtomatikKaldir { get; set; }

    }
}
