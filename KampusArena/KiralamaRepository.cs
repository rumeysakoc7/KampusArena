using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class KiralamaRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public KiralamaRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public int KiralamaEkle(KiralamaIslem kiralama)
        {
            string query = @"INSERT INTO KiralamaIslemleri 
        (UrunID, KullaniciID, BaslangicTarihi, BitisTarihi, KiralamaDurumu, TeslimDurumu, OdemeDurumu, Aktif, Adres, Saat)
        OUTPUT INSERTED.KiralamaID
        VALUES (@UrunID, @KullaniciID, @BaslangicTarihi, @BitisTarihi, @KiralamaDurumu, @TeslimDurumu, @OdemeDurumu, @Aktif, @Adres, @Saat)";

            SqlParameter[] parameters = {
        new SqlParameter("@UrunID", kiralama.UrunID),
        new SqlParameter("@KullaniciID", kiralama.KullaniciID),
        new SqlParameter("@BaslangicTarihi", kiralama.BaslangicTarihi),
        new SqlParameter("@BitisTarihi", kiralama.BitisTarihi),
        new SqlParameter("@KiralamaDurumu", kiralama.KiralamaDurumu),
        new SqlParameter("@TeslimDurumu", kiralama.TeslimDurumu),
        new SqlParameter("@OdemeDurumu", kiralama.OdemeDurumu),
        new SqlParameter("@Aktif", kiralama.Aktif),
        new SqlParameter("@Adres", kiralama.Adres),
        new SqlParameter("@Saat", kiralama.Saat)
    };

            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public int SonEklenenKiralamaID()
        {
            string query = "SELECT TOP 1 KiralamaID FROM KiralamaIslemleri ORDER BY KiralamaID DESC";
            return (int)_dbHelper.ExecuteScalar(query);
        }

        public bool KiralamaDurumuGuncelle(int kiralamaID, string yeniDurum)
        {
            string query = "UPDATE KiralamaIslemleri SET KiralamaDurumu = @durum WHERE KiralamaID = @id";

            SqlParameter[] parameters = {
        new SqlParameter("@durum", yeniDurum),
        new SqlParameter("@id", kiralamaID)
    };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool TeslimDurumunuGuncelle(int kiralamaID, string yeniDurum)
        {
            string query;

            SqlParameter[] parameters;

            if (yeniDurum == "Teslim Edildi")
            {
                query = @"UPDATE KiralamaIslemleri 
                  SET TeslimDurumu = @durum, TeslimTarihi = @tarih 
                  WHERE KiralamaID = @id";

                parameters = new SqlParameter[] {
            new SqlParameter("@durum", yeniDurum),
            new SqlParameter("@tarih", DateTime.Now),
            new SqlParameter("@id", kiralamaID)
        };
            }
            else
            {
                query = @"UPDATE KiralamaIslemleri 
                  SET TeslimDurumu = @durum 
                  WHERE KiralamaID = @id";

                parameters = new SqlParameter[] {
            new SqlParameter("@durum", yeniDurum),
            new SqlParameter("@id", kiralamaID)
        };
            }

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<DateTime> GetirKiralananTarihAraliklari(int urunID)
        {
            List<DateTime> tarihListesi = new List<DateTime>();
            string query = @"
        SELECT BaslangicTarihi, BitisTarihi 
        FROM KiralamaIslemleri 
        WHERE UrunID = @urunID AND OdemeDurumu = 'Ödendi' AND Aktif = 1";

            SqlParameter[] parameters = {
        new SqlParameter("@urunID", urunID)
    };

            DataTable dt = new DatabaseHelper().ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                DateTime baslangic = Convert.ToDateTime(row["BaslangicTarihi"]);
                DateTime bitis = Convert.ToDateTime(row["BitisTarihi"]);

                for (DateTime tarih = baslangic; tarih <= bitis; tarih = tarih.AddDays(1))
                {
                    tarihListesi.Add(tarih);
                }
            }

            return tarihListesi;
        }
        public List<(string Email, string AdSoyad, string UrunAdi, DateTime BitisTarihi, string Adres, string Saat)> GetTeslimHatirlatilacakKullanicilar()
        {
            string query = @"
    SELECT k.Email, k.Ad + ' ' + k.Soyad AS AdSoyad, u.UrunAdi, ki.BitisTarihi, ki.Adres, ki.Saat
    FROM KiralamaIslemleri ki
    JOIN Kullanicilar k ON ki.KullaniciID = k.KullaniciID
    JOIN Urunler u ON ki.UrunID = u.UrunID
    WHERE ki.OdemeDurumu = 'Ödendi'
      AND ki.TeslimDurumu = 'Hazırlanıyor'
      AND ki.BildirimGonderildi = 0
      AND CAST(ki.BitisTarihi AS DATE) = CAST(DATEADD(DAY, 1, GETDATE()) AS DATE)";

            DataTable dt = _dbHelper.ExecuteQuery(query);
            List<(string, string, string, DateTime, string, string)> liste = new();

            foreach (DataRow row in dt.Rows)
            {
                liste.Add((
                    row["Email"].ToString(),
                    row["AdSoyad"].ToString(),
                    row["UrunAdi"].ToString(),
                    Convert.ToDateTime(row["BitisTarihi"]),
                    row["Adres"].ToString(),
                    row["Saat"].ToString()
                ));
            }

            return liste;
        }


        public void BildirimGonderildiOlarakIsaretle(string email, DateTime bitisTarihi)
        {
            string query = @"
        UPDATE KiralamaIslemleri 
        SET BildirimGonderildi = 1 
        WHERE KiralamaID IN (
            SELECT ki.KiralamaID FROM KiralamaIslemleri ki 
            JOIN Kullanicilar k ON ki.KullaniciID = k.KullaniciID
            WHERE k.Email = @Email AND ki.BitisTarihi = @BitisTarihi
        )";

            SqlParameter[] parameters = {
        new SqlParameter("@Email", email),
        new SqlParameter("@BitisTarihi", bitisTarihi)
    };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }
        public List<GelirTakipDTO> GetirKullaniciKiralamalari(int kullaniciID)
        {
            string query = @"
SELECT U.UrunAdi, 'Kiralık' AS IslemTuru, O.OdemeTutari AS Tutar, K.BaslangicTarihi AS Tarih
FROM KiralamaIslemleri K
JOIN Urunler U ON K.UrunID = U.UrunID
JOIN Odemeler O ON K.KiralamaID = O.KiralamaID
WHERE U.SaticiID = @kullaniciID AND K.Aktif = 1 AND O.Aktif = 1";

            SqlParameter[] param = {
        new SqlParameter("@kullaniciID", kullaniciID)
    };

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
