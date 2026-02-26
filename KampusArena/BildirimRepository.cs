using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class BildirimRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public BildirimRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public bool BildirimEkle(Bildirim bildirim)
        {
            try
            {
                string query = @"INSERT INTO Bildirimler 
    (KullaniciID, BildirimMetni, Tarih, Durum, Aktif, UrunID, GonderenID)
    VALUES (@kulID, @metin, @tarih, @durum, @aktif, @urunID, @gonderenID)";


                SqlParameter[] parameters = {
    new SqlParameter("@kulID", bildirim.KullaniciID),
    new SqlParameter("@metin", bildirim.BildirimMetni),
    new SqlParameter("@tarih", bildirim.Tarih),
    new SqlParameter("@durum", bildirim.Durum),
    new SqlParameter("@aktif", bildirim.Aktif),
    new SqlParameter("@urunID", bildirim.UrunID),
    new SqlParameter("@gonderenID", bildirim.GonderenID)
};


                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bildirim eklenirken hata: " + ex.Message);
                return false;
            }
        }

        public List<Bildirim> GetirKullaniciBildirimleri(int kullaniciID, string siralama)
        {
            List<Bildirim> bildirimler = new List<Bildirim>();

            string query = $@"SELECT * FROM Bildirimler 
    WHERE KullaniciID = @kulID AND Aktif = 1 
    AND GonderenID IS NOT NULL AND UrunID IS NOT NULL
    ORDER BY Tarih {siralama}";

            SqlParameter[] parameters = { new SqlParameter("@kulID", kullaniciID) };

            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                bildirimler.Add(new Bildirim
                {
                    BildirimID = Convert.ToInt32(row["BildirimID"]),
                    KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                    BildirimMetni = row["BildirimMetni"].ToString(),
                    Tarih = Convert.ToDateTime(row["Tarih"]),
                    Durum = Convert.ToBoolean(row["Durum"]),
                    Aktif = Convert.ToBoolean(row["Aktif"]),
                    UrunID = row["UrunID"] == DBNull.Value ? 0 : Convert.ToInt32(row["UrunID"]),
                    GonderenID = row["GonderenID"] == DBNull.Value ? 0 : Convert.ToInt32(row["GonderenID"])

                });
            }

            return bildirimler;
        }

        public void OkunduYap(int bildirimID)
        {
            string query = "UPDATE Bildirimler SET Durum = 1 WHERE BildirimID = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", bildirimID) };
            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int GetirOkunmamisBildirimSayisi(int kullaniciID)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM Bildirimler 
                         WHERE KullaniciID = @id 
                         AND Durum = 0 
                         AND Aktif = 1 
                         AND UrunID IS NOT NULL 
                         AND GonderenID IS NOT NULL";

                SqlParameter[] param = { new SqlParameter("@id", kullaniciID) };
                return (int)_dbHelper.ExecuteScalar(query, param);
            }
            catch
            {
                return 0;
            }
        }


        public void TumBildirimleriOkunduYap(int kullaniciID)
        {
            string query = "UPDATE Bildirimler SET Durum = 1 WHERE KullaniciID = @id";
            SqlParameter[] param = { new SqlParameter("@id", kullaniciID) };
            _dbHelper.ExecuteNonQuery(query, param);
        }

        public bool BildirimVarMi(int kullaniciID, int urunID, int gonderenID)
        {
           

            string query = @"
        SELECT COUNT(*) FROM Bildirimler 
        WHERE KullaniciID = @kulID 
            AND UrunID = @urunID 
            AND GonderenID = @gonderenID 
            AND Aktif = 1 
            AND Durum = 0 
            AND BildirimMetni = 'Yeni bir mesajınız var.'"; 

            SqlParameter[] parameters = {
        new SqlParameter("@kulID", kullaniciID),
        new SqlParameter("@urunID", urunID),
        new SqlParameter("@gonderenID", gonderenID)
    };

            int count = (int)_dbHelper.ExecuteScalar(query, parameters);
            return count > 0;
        }

        public bool TumBildirimleriPasifYap(int kullaniciID)
        {
            try
            {
                string query = "UPDATE Bildirimler SET Aktif = 0 WHERE KullaniciID = @id";
                SqlParameter[] param = { new SqlParameter("@id", kullaniciID) };
                return _dbHelper.ExecuteNonQuery(query, param) > 0;
            }
            catch
            {
                return false;
            }
        }

    }

}
