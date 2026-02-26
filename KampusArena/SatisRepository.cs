using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class SatisRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public SatisRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public int SatisEkle(SatisIslem satis)
        {
            string query = @"INSERT INTO SatisIslemleri 
                            (UrunID, KullaniciID, Fiyat, OdemeDurumu, SatisTarihi, Aktif)
                            OUTPUT INSERTED.SatisID
                            VALUES (@UrunID, @KullaniciID, @Fiyat, @OdemeDurumu, @SatisTarihi, @Aktif)";

            SqlParameter[] parameters = {
                new SqlParameter("@UrunID", satis.UrunID),
                new SqlParameter("@KullaniciID", satis.KullaniciID),
                new SqlParameter("@Fiyat", satis.Fiyat),
                new SqlParameter("@OdemeDurumu", satis.OdemeDurumu),
                new SqlParameter("@SatisTarihi", satis.SatisTarihi),
                new SqlParameter("@Aktif", satis.Aktif)
            };

            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        public int SonEklenenSatisID()
        {
            string query = "SELECT TOP 1 SatisID FROM SatisIslemleri ORDER BY SatisID DESC";
            return (int)_dbHelper.ExecuteScalar(query);
        }

        public List<GelirTakipDTO> GetirKullaniciSatislari(int kullaniciID)
        {
            string query = @"
    SELECT U.UrunAdi, 'Satış' AS IslemTuru, S.Fiyat AS Tutar, S.SatisTarihi AS Tarih
    FROM SatisIslemleri S
    JOIN Urunler U ON S.UrunID = U.UrunID
    WHERE U.SaticiID = @kullaniciID AND S.Aktif = 1";

            SqlParameter[] param = { new SqlParameter("@kullaniciID", kullaniciID) };

            DataTable dt = _dbHelper.ExecuteQuery(query, param);
            List<GelirTakipDTO> liste = new List<GelirTakipDTO>();

            foreach (DataRow row in dt.Rows)
            {
                liste.Add(new GelirTakipDTO
                {
                    UrunAdi = row["UrunAdi"].ToString(),
                    IslemTuru = row["IslemTuru"].ToString(),
                    Tutar = Convert.ToDecimal(row["Tutar"]),
                    Tarih = Convert.ToDateTime(row["Tarih"])
                });
            }

            return liste;
        }


    }
}
