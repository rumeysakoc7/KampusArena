using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class DuyuruRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public DuyuruRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public bool AddDuyuru(Duyuru duyuru)
        {
            string query = @"INSERT INTO Duyurular (KullaniciID, Baslik, Aciklama, Tarih, SonTarih, Aktif,OtomatikKaldir)
                             VALUES (@KullaniciID, @Baslik, @Aciklama, @Tarih, @SonTarih, 1, @OtomatikKaldir)";
            SqlParameter[] parameters = {
                new SqlParameter("@KullaniciID", duyuru.KullaniciID),
                new SqlParameter("@Baslik", duyuru.Baslik),
                new SqlParameter("@Aciklama", duyuru.Aciklama),
                new SqlParameter("@Tarih", duyuru.Tarih),
                new SqlParameter("@SonTarih", duyuru.SonTarih),
                new SqlParameter("@OtomatikKaldir", duyuru.OtomatikKaldir)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateDuyuru(Duyuru duyuru)
        {
            string query = @"UPDATE Duyurular SET Baslik = @Baslik, Aciklama = @Aciklama,
                             Tarih = @Tarih, SonTarih = @SonTarih, Aktif = 1, OtomatikKaldir = @OtomatikKaldir
                             WHERE DuyuruID = @DuyuruID";
            SqlParameter[] parameters = {
                new SqlParameter("@DuyuruID", duyuru.DuyuruID),
                new SqlParameter("@Baslik", duyuru.Baslik),
                new SqlParameter("@Aciklama", duyuru.Aciklama),
                new SqlParameter("@Tarih", duyuru.Tarih),
                new SqlParameter("@SonTarih", duyuru.SonTarih),new SqlParameter("@OtomatikKaldir", duyuru.OtomatikKaldir)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SoftDeleteDuyuru(int duyuruId)
        {
            string query = "UPDATE Duyurular SET Aktif = 0 WHERE DuyuruID = @DuyuruID";
            SqlParameter[] parameters = { new SqlParameter("@DuyuruID", duyuruId) };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable GetDuyurularWithUserInfo(string siralama = "DESC")
        {
            string query = $@"
    SELECT 
        d.DuyuruID,
        d.Baslik,
        d.Aciklama,
        d.Tarih,          
        d.SonTarih,        
        d.PaylasimTarihi,
        k.Ad + ' ' + k.Soyad AS KullaniciAdi,
        k.KullaniciTipi
    FROM Duyurular d
    INNER JOIN Kullanicilar k ON d.KullaniciID = k.KullaniciID
    WHERE d.Aktif = 1
    ORDER BY d.PaylasimTarihi {siralama}";

            return _dbHelper.ExecuteQuery(query);
        }

        public void OtomatikKaldirGecerliligiKontrolEt()
        {
            string query = @"
        UPDATE Duyurular
        SET Aktif = 0
        WHERE OtomatikKaldir = 1
          AND SonTarih < GETDATE()
          AND Aktif = 1";

            _dbHelper.ExecuteNonQuery(query);
        }
        public DataTable GetDuyurularim(int kullaniciID)
        {
            string query = @"
        SELECT 
            DuyuruID, Baslik, Aciklama, Tarih, SonTarih, PaylasimTarihi, OtomatikKaldir, Aktif,
            CASE 
                WHEN Aktif = 0 AND OtomatikKaldir = 1 AND SonTarih < GETDATE() THEN 'Süresi Dolmuş'
                WHEN Aktif = 1 THEN 'Yayında'
                ELSE 'Pasif' 
            END AS Durum
        FROM Duyurular
        WHERE KullaniciID = @KullaniciID";

            SqlParameter[] param = { new SqlParameter("@KullaniciID", kullaniciID) };
            return _dbHelper.ExecuteQuery(query, param);
        }
    }

}
