using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
    public class KategoriRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public KategoriRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public DataTable GetKategoriler(bool? aktif = null)
        {
            string query = "SELECT KategoriID, KategoriAdi, Aciklama, Aktif FROM Kategoriler";
            if (aktif.HasValue)
                query += " WHERE Aktif = @Aktif";

            SqlParameter[] parameters = aktif.HasValue
                ? new SqlParameter[] { new SqlParameter("@Aktif", aktif.Value) }
                : null;

            return _dbHelper.ExecuteQuery(query, parameters);
        }

      

        public bool AddKategori(Kategori kategori)
        {
            string query = @"INSERT INTO Kategoriler (KategoriAdi, Aciklama, Aktif)
                             VALUES (@KategoriAdi, @Aciklama, 1)";
            SqlParameter[] parameters = {
                new SqlParameter("@KategoriAdi", kategori.KategoriAdi),
                new SqlParameter("@Aciklama", kategori.Aciklama ?? (object)DBNull.Value)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateKategori(Kategori kategori)
        {
            string query = @"UPDATE Kategoriler 
                             SET KategoriAdi = @KategoriAdi, Aciklama = @Aciklama, Aktif = 1
                             WHERE KategoriID = @KategoriID";
            SqlParameter[] parameters = {
                new SqlParameter("@KategoriID", kategori.KategoriID),
                new SqlParameter("@KategoriAdi", kategori.KategoriAdi),
                new SqlParameter("@Aciklama", kategori.Aciklama ?? (object)DBNull.Value)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteKategoriSoft(int kategoriId)
        {
            string query = "UPDATE Kategoriler SET Aktif = 0 WHERE KategoriID = @KategoriID";
            SqlParameter[] parameters = {
                new SqlParameter("@KategoriID", kategoriId)
            };
            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
        public DataTable GetKategoriler()
        {
            string query = "SELECT KategoriID, KategoriAdi FROM Kategoriler WHERE Aktif = 1";
            return _dbHelper.ExecuteQuery(query);
        }

        public bool GetKategoriAktifDurumu(int kategoriId)
        {
            string query = "SELECT Aktif FROM Kategoriler WHERE KategoriID = @KategoriID";
            SqlParameter[] parameters = { new SqlParameter("@KategoriID", kategoriId) };
            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result != null && Convert.ToBoolean(result);
        }


        public DataTable AraKategoriler(string arama)
        {
            string query = @"SELECT KategoriID, KategoriAdi, Aciklama, Aktif 
                     FROM Kategoriler 
                     WHERE Aktif = 1 AND KategoriAdi LIKE @Arama";

            SqlParameter[] parameters = {
        new SqlParameter("@Arama", "%" + arama + "%")
    };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

    }
}
