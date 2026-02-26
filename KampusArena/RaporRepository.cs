using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class RaporRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public RaporRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public RaporDTO GetirRaporVerileri(int kullaniciID, DateTime baslangic, DateTime bitis)
        {
            string query = @"
SELECT
    (SELECT ISNULL(SUM(S.Fiyat), 0) 
     FROM SatisIslemleri S 
     JOIN Urunler U ON S.UrunID = U.UrunID 
     WHERE U.SaticiID = @kullaniciID 
       AND S.SatisTarihi BETWEEN @baslangic AND @bitis 
       AND S.Aktif = 1) AS ToplamSatis,

    (SELECT ISNULL(SUM(O.OdemeTutari), 0) 
     FROM KiralamaIslemleri K 
     JOIN Urunler U ON K.UrunID = U.UrunID 
     JOIN Odemeler O ON O.KiralamaID = K.KiralamaID 
     WHERE U.SaticiID = @kullaniciID 
       AND K.BaslangicTarihi BETWEEN @baslangic AND @bitis 
       AND K.Aktif = 1 
       AND O.Aktif = 1 
       AND O.OdemeDurumu = 'Ödendi') AS ToplamKiralama,

    (SELECT COUNT(*) FROM Duyurular 
     WHERE KullaniciID = @kullaniciID 
       AND Tarih BETWEEN @baslangic AND @bitis) AS ToplamDuyuru

";


            SqlParameter[] parameters = {
                new SqlParameter("@kullaniciID", kullaniciID),
                new SqlParameter("@baslangic", baslangic),
                new SqlParameter("@bitis", bitis)
            };

            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new RaporDTO
                {
                    Tarih = DateTime.Now,
                    ToplamSatis = Convert.ToDecimal(dr["ToplamSatis"]),
                    ToplamKiralama = Convert.ToDecimal(dr["ToplamKiralama"]),
                    ToplamGelir = Convert.ToDecimal(dr["ToplamSatis"]) + Convert.ToDecimal(dr["ToplamKiralama"]),
                    ToplamDuyuru = Convert.ToInt32(dr["ToplamDuyuru"])
                };
            }
            return null;
        }
        public void KaydetRaporVeritabanina(RaporDTO rapor, int kullaniciID)
        {
            string query = @"INSERT INTO Raporlar (Tarih, ToplamKiralama, ToplamSatis, ToplamGelir, ToplamDuyuru)
                     VALUES (@Tarih, @ToplamKiralama, @ToplamSatis, @ToplamGelir, @ToplamDuyuru)";

            SqlParameter[] parametreler = {
        new SqlParameter("@Tarih", rapor.Tarih),
        new SqlParameter("@ToplamKiralama", rapor.ToplamKiralama),
        new SqlParameter("@ToplamSatis", rapor.ToplamSatis),
        new SqlParameter("@ToplamGelir", rapor.ToplamGelir),
        new SqlParameter("@ToplamDuyuru", rapor.ToplamDuyuru)
    };

            _dbHelper.ExecuteNonQuery(query, parametreler);
        }
        public List<RaporDTO> GetirTumRaporlar()
        {
            string query = "SELECT * FROM Raporlar ORDER BY Tarih DESC";
            DataTable dt = _dbHelper.ExecuteQuery(query);
            List<RaporDTO> liste = new List<RaporDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                liste.Add(new RaporDTO
                {
                    Tarih = Convert.ToDateTime(dr["Tarih"]),
                    ToplamSatis = Convert.ToDecimal(dr["ToplamSatis"]),
                    ToplamKiralama = Convert.ToDecimal(dr["ToplamKiralama"]),
                    ToplamGelir = Convert.ToDecimal(dr["ToplamGelir"]),
                    ToplamDuyuru = Convert.ToInt32(dr["ToplamDuyuru"])
                });
            }

            return liste;
        }
    }
}
