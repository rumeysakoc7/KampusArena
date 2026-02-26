using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class UrunRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public UrunRepository()
        {
            _dbHelper = new DatabaseHelper();
        }
        public bool AddUrun(Urun urun)
        {
            string query = @"INSERT INTO Urunler
            (UrunAdi, KategoriID, Aciklama, Fiyat, ResimYolu, Durum, KiralamaDurumu, SaticiID, Aktif)
            VALUES
            (@UrunAdi, @KategoriID, @Aciklama, @Fiyat, @ResimYolu, @Durum, @KiralamaDurumu, @SaticiID, 1)";

            SqlParameter[] parameters = {
                new SqlParameter("@UrunAdi", urun.UrunAdi),
                new SqlParameter("@KategoriID", urun.KategoriID),
                new SqlParameter("@Aciklama", urun.Aciklama),
                new SqlParameter("@Fiyat", urun.Fiyat),
                new SqlParameter("@ResimYolu", urun.ResimYolu),
                new SqlParameter("@Durum", urun.Durum),
                new SqlParameter("@KiralamaDurumu", urun.KiralamaDurumu),
                new SqlParameter("@SaticiID", urun.SaticiID)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateUrun(Urun urun)
        {
            string query = @"UPDATE Urunler SET
                UrunAdi = @UrunAdi,
                KategoriID = @KategoriID,
                Aciklama = @Aciklama,
                Fiyat = @Fiyat,
                ResimYolu = @ResimYolu,
                Durum = @Durum,
                KiralamaDurumu = @KiralamaDurumu,
                Aktif = 1
                WHERE UrunID = @UrunID";

            SqlParameter[] parameters = {
                new SqlParameter("@UrunID", urun.UrunID),
                new SqlParameter("@UrunAdi", urun.UrunAdi),
                new SqlParameter("@KategoriID", urun.KategoriID),
                new SqlParameter("@Aciklama", urun.Aciklama),
                new SqlParameter("@Fiyat", urun.Fiyat),
                new SqlParameter("@ResimYolu", urun.ResimYolu),
                new SqlParameter("@Durum", urun.Durum),
                new SqlParameter("@KiralamaDurumu", urun.KiralamaDurumu)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SoftDeleteUrun(int urunId)
        {
            string query = "UPDATE Urunler SET Aktif = 0 WHERE UrunID = @UrunID";
            SqlParameter[] parameters = { new SqlParameter("@UrunID", urunId) };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable GetUrunlerim(int saticiId)
        {
            string query = @"SELECT * FROM Urunler WHERE Aktif = 1 AND SaticiID = @SaticiID";
            SqlParameter[] parameters = { new SqlParameter("@SaticiID", saticiId) };
            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public List<Urun> GetUrunlerByDurum(string durum)
        {
            string query = @"SELECT * FROM Urunler WHERE Durum = @Durum AND Aktif = 1";
            SqlParameter[] parameters = { new SqlParameter("@Durum", durum) };

            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);
            List<Urun> urunList = new List<Urun>();

            foreach (DataRow row in dt.Rows)
            {
                urunList.Add(new Urun
                {
                    UrunID = Convert.ToInt32(row["UrunID"]),
                    UrunAdi = row["UrunAdi"].ToString(),
                    Fiyat = Convert.ToDecimal(row["Fiyat"]),
                    ResimYolu = row["ResimYolu"].ToString(),
                    Aciklama = row["Aciklama"].ToString(),
                    Durum = row["Durum"].ToString()
                });
            }

            return urunList;
        }
        public List<Urun> GetFiltreliUrunler(string durum, string arama = "", int? kategoriId = null)
        {
            List<Urun> urunler = new List<Urun>();
            StringBuilder query = new StringBuilder(@"SELECT * FROM Urunler WHERE Aktif = 1
        AND UrunID NOT IN (
            SELECT s.UrunID FROM SatisIslemleri s WHERE s.OdemeDurumu = 'Ödendi'
        )"); 

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(durum))
            {
                query.Append(" AND Durum = @Durum");
                parameters.Add(new SqlParameter("@Durum", durum));
            }
            else
            {
                query.Append(" AND (Durum = 'Satılık' OR Durum = 'Kiralık')");
            }

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query.Append(" AND UrunAdi LIKE @Arama");
                parameters.Add(new SqlParameter("@Arama", "%" + arama + "%"));
            }

            if (kategoriId.HasValue)
            {
                query.Append(" AND KategoriID = @KategoriID");
                parameters.Add(new SqlParameter("@KategoriID", kategoriId.Value));
            }

            DataTable dt = _dbHelper.ExecuteQuery(query.ToString(), parameters.ToArray());

            foreach (DataRow row in dt.Rows)
            {
                urunler.Add(new Urun
                {
                    UrunID = Convert.ToInt32(row["UrunID"]),
                    UrunAdi = row["UrunAdi"].ToString(),
                    Fiyat = Convert.ToDecimal(row["Fiyat"]),
                    ResimYolu = row["ResimYolu"].ToString(),
                    Aciklama = row["Aciklama"].ToString(),
                    Durum = row["Durum"].ToString(),
                    KategoriID = Convert.ToInt32(row["KategoriID"]),
                    SaticiID = Convert.ToInt32(row["SaticiID"])
                });
            }

            return urunler;
        }


        public List<string> GetirKullaniciUrunleri(int kullaniciId)
            {
                List<string> urunler = new List<string>();
                string query = "SELECT UrunAdi FROM Urunler WHERE SaticiID = @id AND Aktif = 1";

                SqlParameter[] parameters = {
            new SqlParameter("@id", kullaniciId)
        };

                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    urunler.Add(row["UrunAdi"].ToString());
                }

                return urunler;
            }
        public int GetirUrunSahibiID(int urunID)
        {
            string query = "SELECT SaticiID FROM Urunler WHERE UrunID = @id";
            SqlParameter[] parametreler = { new SqlParameter("@id", urunID) };
            object sonuc = _dbHelper.ExecuteScalar(query, parametreler);
            return sonuc != null ? Convert.ToInt32(sonuc) : -1;
        }

        public bool UrunSatinAlinmisMi(int urunID)
        {
            string query = "SELECT COUNT(*) FROM SatisIslemleri WHERE UrunID = @id AND OdemeDurumu = 'Ödendi'";
            SqlParameter[] parameters = { new SqlParameter("@id", urunID) };
            return (int)_dbHelper.ExecuteScalar(query, parameters) > 0;
        }

        public bool UrunKiradaMi(int urunID)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM KiralamaIslemleri 
        WHERE UrunID = @id 
            AND OdemeDurumu = 'Ödendi'
            AND Aktif = 1
            AND BitisTarihi >= CAST(GETDATE() AS DATE)";

            SqlParameter[] parameters = { new SqlParameter("@id", urunID) };
            return (int)_dbHelper.ExecuteScalar(query, parameters) > 0;
        }

        public bool FiyatGuncelle(int urunID, decimal yeniFiyat)
        {
            try
            {
                string query = "UPDATE Urunler SET Fiyat = @fiyat WHERE UrunID = @id";
                SqlParameter[] parameters = {
            new SqlParameter("@fiyat", yeniFiyat),
            new SqlParameter("@id", urunID)
        };

                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiyat güncellenirken hata: " + ex.Message);
                return false;
            }
        }

        public Urun GetirUrunByID(int urunID)
        {
            string query = "SELECT * FROM Urunler WHERE UrunID = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", urunID) };

            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new Urun
            {
                UrunID = Convert.ToInt32(row["UrunID"]),
                UrunAdi = row["UrunAdi"].ToString(),
                Fiyat = Convert.ToDecimal(row["Fiyat"]),
                ResimYolu = row["ResimYolu"].ToString(),
                Aciklama = row["Aciklama"].ToString(),
                Durum = row["Durum"].ToString(),
                SaticiID = Convert.ToInt32(row["SaticiID"]),
                KategoriID = Convert.ToInt32(row["KategoriID"])
            };
        }
    }
}
