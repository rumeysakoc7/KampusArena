using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{

    public class OdemeRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public OdemeRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public bool OdemeEkle(Odeme odeme)
        {
            string query = @"INSERT INTO Odemeler 
                    (SatisID, KiralamaID, OdemeTutari, OdemeTarihi, OdemeYontemi, KullaniciID, Aktif, DekontYolu)
                    VALUES (@SatisID, @KiralamaID, @OdemeTutari, @OdemeTarihi, @OdemeYontemi, @KullaniciID, @Aktif, @DekontYolu)";

            SqlParameter[] parameters = {
        new SqlParameter("@SatisID", (object?)odeme.SatisID ?? DBNull.Value),
        new SqlParameter("@KiralamaID", (object?)odeme.KiralamaID ?? DBNull.Value),
        new SqlParameter("@OdemeTutari", odeme.OdemeTutari),
        new SqlParameter("@OdemeTarihi", odeme.OdemeTarihi),
        new SqlParameter("@OdemeYontemi", odeme.OdemeYontemi),
        new SqlParameter("@KullaniciID", odeme.KullaniciID),
        new SqlParameter("@Aktif", odeme.Aktif),
        new SqlParameter("@DekontYolu", (object?)odeme.DekontYolu ?? DBNull.Value)
    };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }


        public DataTable GetirBekleyenOdemeler()
        {
            string query = @"
    SELECT o.OdemeID, o.OdemeTutari, o.OdemeTarihi, o.OdemeYontemi,
           k.Ad + ' ' + k.Soyad AS KullaniciAdi,
           u.UrunAdi, o.DekontYolu, o.OdemeDurumu,
           o.KiralamaID  -- Teslim durumu kontrolü için lazım
    FROM Odemeler o
    JOIN Kullanicilar k ON o.KullaniciID = k.KullaniciID
    LEFT JOIN SatisIslemleri s ON o.SatisID = s.SatisID
    LEFT JOIN KiralamaIslemleri ki ON o.KiralamaID = ki.KiralamaID
    LEFT JOIN Urunler u ON u.UrunID = ISNULL(s.UrunID, ki.UrunID)
    WHERE o.Aktif = 1 AND (
        o.OdemeDurumu IS NULL -- ödeme henüz onaylanmadı
        OR 
        (o.KiralamaID IS NOT NULL AND o.OdemeDurumu = 'Ödendi' AND ki.TeslimDurumu = 'Hazırlanıyor') -- kiralama yapıldı ama henüz teslim edilmedi
    )";

            return _dbHelper.ExecuteReader(query);
        }

        public bool OdemeOnayla(int odemeID)
        {
            string query = @"UPDATE Odemeler 
                     SET OdemeDurumu = 'Ödendi'
                     WHERE OdemeID = @id";

            SqlParameter[] parameters = {
        new SqlParameter("@id", odemeID)
    };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool OdemeReddet(int odemeID)
        {
            string query = @"UPDATE Odemeler 
                     SET OdemeDurumu = 'Reddedildi'
                     WHERE OdemeID = @id";

            SqlParameter[] parameters = {
        new SqlParameter("@id", odemeID)
    };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool IlgiliOdemeDurumunuGuncelle(int odemeID, string yeniDurum)
        {
            string query = @"
        UPDATE SatisIslemleri 
        SET OdemeDurumu = @durum
        WHERE SatisID = (
            SELECT SatisID FROM Odemeler WHERE OdemeID = @odemeID AND SatisID IS NOT NULL
        );

        UPDATE KiralamaIslemleri 
        SET OdemeDurumu = @durum
        WHERE KiralamaID = (
            SELECT KiralamaID FROM Odemeler WHERE OdemeID = @odemeID AND KiralamaID IS NOT NULL
        );";

            SqlParameter[] parameters = {
        new SqlParameter("@durum", yeniDurum),
        new SqlParameter("@odemeID", odemeID)
    };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }


    }
}
