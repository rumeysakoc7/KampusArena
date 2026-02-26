using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class KullaniciRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public KullaniciRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public DataTable GetKullanicilar(bool? aktif = null)
        {
            string query = "SELECT KullaniciID, Ad, Soyad, Email, Telefon, Sifre, KayitTarihi, KullaniciTipi, Aktif, IBAN FROM Kullanicilar";

            if (aktif.HasValue)
            {
                query += " WHERE Aktif = @Aktif";
            }

            SqlParameter[] parameters = aktif.HasValue
                ? new SqlParameter[] { new SqlParameter("@Aktif", aktif.Value) }
                : new SqlParameter[] { };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public bool GetAktifDurumu(int kullaniciId)
        {
            string query = "SELECT Aktif FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
            SqlParameter[] parameters = { new SqlParameter("@KullaniciID", kullaniciId) };
            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result != null && Convert.ToBoolean(result);
        }

        public bool AddKullanici(Kullanici kullanici)
        {
            string query = @"INSERT INTO Kullanicilar 
                            (Ad, Soyad, Email, Telefon, Sifre, KullaniciTipi, KayitTarihi, IBAN) 
                            VALUES (@Ad, @Soyad, @Email, @Telefon, @Sifre, @KullaniciTipi, @KayitTarihi, @IBAN)";
            SqlParameter[] parameters = {
                new SqlParameter("@Ad", kullanici.Ad),
                new SqlParameter("@Soyad", kullanici.Soyad),
                new SqlParameter("@Email", kullanici.Email),
                new SqlParameter("@Telefon", kullanici.Telefon ?? (object)DBNull.Value),
                new SqlParameter("@Sifre", kullanici.Sifre),
                new SqlParameter("@KullaniciTipi", kullanici.KullaniciTipi),
                new SqlParameter("@KayitTarihi", DateTime.Now),
                new SqlParameter("@IBAN", string.IsNullOrEmpty(kullanici.IBAN) ? (object)DBNull.Value : kullanici.IBAN)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateKullanici(Kullanici kullanici)
        {
            string query = @"UPDATE Kullanicilar 
                            SET Ad = @Ad, Soyad = @Soyad, Email = @Email, Telefon = @Telefon, 
                                Sifre = @Sifre, KullaniciTipi = @KullaniciTipi, Aktif = @Aktif, IBAN = @IBAN
                            WHERE KullaniciID = @KullaniciID";
            SqlParameter[] parameters = {
                new SqlParameter("@KullaniciID", kullanici.KullaniciID),
                new SqlParameter("@Ad", kullanici.Ad),
                new SqlParameter("@Soyad", kullanici.Soyad),
                new SqlParameter("@Email", kullanici.Email),
                new SqlParameter("@Telefon", kullanici.Telefon ?? (object)DBNull.Value),
                new SqlParameter("@Sifre", kullanici.Sifre),
                new SqlParameter("@KullaniciTipi", kullanici.KullaniciTipi),
                new SqlParameter("@Aktif", kullanici.Aktif),
                new SqlParameter("@IBAN", string.IsNullOrEmpty(kullanici.IBAN) ? (object)DBNull.Value : kullanici.IBAN)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool KullaniciyiAktifEt(string email)
        {
            string query = @"UPDATE Kullanicilar 
                             SET Aktif = 1, KayitTarihi = @Tarih 
                             WHERE Email = @Email AND Aktif = 0";
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email),
                new SqlParameter("@Tarih", DateTime.Now)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteKullaniciPasif(int kullaniciID)
        {
            string query = "UPDATE Kullanicilar SET Aktif = 0 WHERE KullaniciID = @KullaniciID";
            SqlParameter[] parameters = { new SqlParameter("@KullaniciID", kullaniciID) };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateKullaniciByEmail(Kullanici kullanici)
        {
            string query = @"
        UPDATE Kullanicilar
        SET 
            Ad = @Ad,
            Soyad = @Soyad,
            Telefon = @Telefon,
            Sifre = @Sifre,
            KullaniciTipi = @KullaniciTipi,
            Aktif = 1,
            KayitTarihi = @KayitTarihi,
            IBAN = @IBAN
        WHERE Email = @Email AND Aktif = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@Ad", kullanici.Ad),
                new SqlParameter("@Soyad", kullanici.Soyad),
                new SqlParameter("@Telefon", kullanici.Telefon ?? (object)DBNull.Value),
                new SqlParameter("@Sifre", kullanici.Sifre),
                new SqlParameter("@KullaniciTipi", kullanici.KullaniciTipi),
                new SqlParameter("@KayitTarihi", DateTime.Now),
                new SqlParameter("@Email", kullanici.Email),
                new SqlParameter("@IBAN", string.IsNullOrEmpty(kullanici.IBAN) ? (object)DBNull.Value : kullanici.IBAN)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public Kullanici Login(string email, string sifre)
        {
            string query = "SELECT * FROM Kullanicilar WHERE Email = @Email AND Sifre = @Sifre AND Aktif = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Sifre", sifre)
            };

            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Kullanici
                {
                    KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                    Ad = row["Ad"].ToString(),
                    Soyad = row["Soyad"].ToString(),
                    Email = row["Email"].ToString(),
                    Telefon = row["Telefon"]?.ToString(),
                    Sifre = row["Sifre"].ToString(),
                    KayitTarihi = Convert.ToDateTime(row["KayitTarihi"]),
                    KullaniciTipi = row["KullaniciTipi"].ToString(),
                    Aktif = Convert.ToBoolean(row["Aktif"]),
                    IBAN = row["IBAN"]?.ToString()
                };
            }
            return null;
        }

        public bool EmailVarMi(string email)
        {
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = @Email";
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email)
            };

            int count = Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool AktifMi(string email)
        {
            string query = "SELECT Aktif FROM Kullanicilar WHERE Email = @Email";
            SqlParameter[] parameters = {
                new SqlParameter("@Email", email)
            };
            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result != null && Convert.ToBoolean(result);
        }

        public bool SifreGuncelle(string email, string telefon, string yeniSifre)
        {
            string query = "UPDATE Kullanicilar SET Sifre = @Sifre WHERE Email = @Email AND Telefon = @Telefon AND Aktif = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Sifre", yeniSifre),
                new SqlParameter("@Email", email),
                new SqlParameter("@Telefon", telefon)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public string GetCurrentPassword(int kullaniciID)
        {
            string query = "SELECT Sifre FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
            SqlParameter[] parameters = {
                new SqlParameter("@KullaniciID", kullaniciID)
            };
            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result?.ToString() ?? "";
        }

        public DataTable AraKullanicilar(string arama)
        {
            string query = @"SELECT KullaniciID, Ad, Soyad, Email, Telefon, KayitTarihi, KullaniciTipi 
                     FROM Kullanicilar
                     WHERE Aktif = 1 AND 
                           (Ad LIKE @Arama OR Soyad LIKE @Arama OR Email LIKE @Arama)";

            SqlParameter[] parameters = {
                new SqlParameter("@Arama", "%" + arama + "%")
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public string GetirAdSoyad(int kullaniciID)
        {
            string query = "SELECT Ad, Soyad FROM Kullanicilar WHERE KullaniciID = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", kullaniciID) };
            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Ad"] + " " + dt.Rows[0]["Soyad"];
            }
            return "Bilinmiyor";
        }


    }
}
