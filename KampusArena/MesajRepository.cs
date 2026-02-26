using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{

    public class MesajRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public MesajRepository()
        {
            _dbHelper = new DatabaseHelper();
        }

        public bool MesajEkle(Mesaj mesaj)
        {
            try
            {
                string query = @"INSERT INTO Mesajlasma
            (GonderenID, AliciID, UrunID, MesajMetni, Tarih, FiyatTeklifi, Durum, Aktif)
            VALUES (@gonderen, @alici, @urunID, @mesaj, @tarih, @teklif, @durum, @aktif)";

                SqlParameter[] parameters = {
            new SqlParameter("@gonderen", mesaj.GonderenID),
            new SqlParameter("@alici", mesaj.AliciID),
            new SqlParameter("@urunID", mesaj.UrunID),
            new SqlParameter("@mesaj", mesaj.MesajMetni),
            new SqlParameter("@tarih", mesaj.Tarih),
            new SqlParameter("@teklif", (object?)mesaj.FiyatTeklifi ?? DBNull.Value),
            new SqlParameter("@durum", mesaj.Durum),
            new SqlParameter("@aktif", mesaj.Aktif)
        };

                int etkilenenSatir = _dbHelper.ExecuteNonQuery(query, parameters);

                if (etkilenenSatir > 0)
                {
                    string bildirimQuery = @"INSERT INTO Bildirimler 
                (KullaniciID, BildirimMetni, Tarih, Durum, Aktif)
                VALUES (@kullaniciID, @metin, @tarih, @durum, @aktif)";

                    string metin = "Yeni bir mesajınız var.";
                    SqlParameter[] bildirimParams = {
                new SqlParameter("@kullaniciID", mesaj.AliciID),  
                new SqlParameter("@metin", metin),
                new SqlParameter("@tarih", DateTime.Now),
                new SqlParameter("@durum", false),
                new SqlParameter("@aktif", true)
            };

                    _dbHelper.ExecuteNonQuery(bildirimQuery, bildirimParams);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj eklenirken hata: " + ex.Message);
                return false;
            }
        }

        public List<Mesaj> GetirMesajlarKullaniciBazli(int kullaniciID)
        {
            List<Mesaj> mesajlar = new List<Mesaj>();

            try
            {
                string query = @"
            SELECT * FROM Mesajlasma
            WHERE Aktif = 1 AND AliciID = @id
            ORDER BY Tarih DESC";

                SqlParameter[] parameters = {
            new SqlParameter("@id", kullaniciID)
        };

                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    mesajlar.Add(new Mesaj
                    {
                        MesajID = Convert.ToInt32(row["MesajID"]),
                        GonderenID = Convert.ToInt32(row["GonderenID"]),
                        AliciID = Convert.ToInt32(row["AliciID"]),
                        UrunID = Convert.ToInt32(row["UrunID"]),
                        MesajMetni = row["MesajMetni"].ToString(),
                        Tarih = Convert.ToDateTime(row["Tarih"]),
                        FiyatTeklifi = row["FiyatTeklifi"] != DBNull.Value ? Convert.ToDecimal(row["FiyatTeklifi"]) : (decimal?)null,
                        Durum = row["Durum"].ToString(),
                        Aktif = Convert.ToBoolean(row["Aktif"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı mesajları alınırken hata: " + ex.Message);
            }

            return mesajlar;
        }

        public List<Mesaj> GetirMesajlar(int gonderenID, int aliciID, int urunID)
        {
            List<Mesaj> mesajlar = new List<Mesaj>();

            try
            {
                string query = @"
                SELECT * FROM Mesajlasma
                WHERE Aktif = 1 AND UrunID = @urunID AND 
                (
                    (GonderenID = @gonderen AND AliciID = @alici) OR
                    (GonderenID = @alici AND AliciID = @gonderen)
                )
                ORDER BY Tarih ASC";

                SqlParameter[] parameters = {
                    new SqlParameter("@gonderen", gonderenID),
                    new SqlParameter("@alici", aliciID),
                    new SqlParameter("@urunID", urunID)
                };

                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    mesajlar.Add(new Mesaj
                    {
                        MesajID = Convert.ToInt32(row["MesajID"]),
                        GonderenID = Convert.ToInt32(row["GonderenID"]),
                        AliciID = Convert.ToInt32(row["AliciID"]),
                        UrunID = Convert.ToInt32(row["UrunID"]),
                        MesajMetni = row["MesajMetni"].ToString(),
                        Tarih = Convert.ToDateTime(row["Tarih"]),
                        FiyatTeklifi = row["FiyatTeklifi"] != DBNull.Value ? Convert.ToDecimal(row["FiyatTeklifi"]) : (decimal?)null,
                        Durum = row["Durum"].ToString(),
                        Aktif = Convert.ToBoolean(row["Aktif"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajlar alınırken hata: " + ex.Message);
            }

            return mesajlar;
        }

        public List<Kullanici> GetirBanaMesajAtanKullanicilar(int urunID, int benimID)
        {
            List<Kullanici> liste = new List<Kullanici>();

            try
            {
                string query = @"
        SELECT DISTINCT k.KullaniciID, k.Ad, k.Soyad
        FROM Mesajlasma m
        INNER JOIN Kullanicilar k ON m.GonderenID = k.KullaniciID
        WHERE m.UrunID = @urunID AND m.AliciID = @benimID AND m.Aktif = 1";

                SqlParameter[] param = {
            new SqlParameter("@urunID", urunID),
            new SqlParameter("@benimID", benimID)
        };

                DataTable dt = _dbHelper.ExecuteQuery(query, param);

                foreach (DataRow row in dt.Rows)
                {
                    liste.Add(new Kullanici
                    {
                        KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                        Ad = row["Ad"].ToString(),
                        Soyad = row["Soyad"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sana mesaj atan kullanıcılar alınırken hata: " + ex.Message);
            }

            return liste;
        }

        
        public bool MesajOkunduYap(int mesajID)
        {
            try
            {
                string query = "UPDATE Mesajlasma SET Durum = 'Okundu' WHERE MesajID = @id";
                SqlParameter[] parameters = {
                    new SqlParameter("@id", mesajID)
                };

                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj durumu güncellenirken hata: " + ex.Message);
                return false;
            }
        }
        public List<Kullanici> GetirMesajGonderenKullanicilar(int urunID)
        {
            List<Kullanici> liste = new List<Kullanici>();

            try
            {
                string query = @"
        SELECT DISTINCT k.KullaniciID, k.Ad, k.Soyad
        FROM Mesajlasma m
        INNER JOIN Kullanicilar k ON m.GonderenID = k.KullaniciID
        WHERE m.UrunID = @urunID AND m.Aktif = 1";

                SqlParameter[] param = {
            new SqlParameter("@urunID", urunID)
        };

                DataTable dt = _dbHelper.ExecuteQuery(query, param);

                foreach (DataRow row in dt.Rows)
                {
                    liste.Add(new Kullanici
                    {
                        KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                        Ad = row["Ad"].ToString(),
                        Soyad = row["Soyad"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj gönderen kullanıcılar alınamadı: " + ex.Message);
            }

            return liste;
        }


        public List<Urun> GetirMesajlasilanUrunler(int aliciID)
        {
            List<Urun> urunler = new List<Urun>();

            try
            {
                string query = @"
            SELECT DISTINCT u.UrunID, u.UrunAdi, u.ResimYolu
            FROM Mesajlasma m
            INNER JOIN Urunler u ON m.UrunID = u.UrunID
            WHERE m.AliciID = @alici AND m.Aktif = 1";

                SqlParameter[] param = {
            new SqlParameter("@alici", aliciID)
        };

                DataTable dt = _dbHelper.ExecuteQuery(query, param);

                foreach (DataRow row in dt.Rows)
                {
                    urunler.Add(new Urun
                    {
                        UrunID = Convert.ToInt32(row["UrunID"]),
                        UrunAdi = row["UrunAdi"].ToString(),
                        ResimYolu = row["ResimYolu"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj ürünleri alınamadı: " + ex.Message);
            }

            return urunler;
        }


        public bool SohbetiPasifYap(int gonderenID, int aliciID, int urunID)
        {
            try
            {
                string query = @"
        UPDATE Mesajlasma
        SET Aktif = 0
        WHERE UrunID = @urunID AND Aktif = 1
        AND (
            (GonderenID = @gonderen AND AliciID = @alici)
        )";

                SqlParameter[] parameters = {
            new SqlParameter("@gonderen", gonderenID),
            new SqlParameter("@alici", aliciID),
            new SqlParameter("@urunID", urunID)
        };

                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sohbet silinirken hata: " + ex.Message);
                return false;
            }
        }


        public bool TeklifDurumuGuncelle(int mesajID, string yeniDurum)
        {
            try
            {
                string query = "UPDATE Mesajlasma SET Durum = @durum WHERE MesajID = @id";
                SqlParameter[] parameters = {
            new SqlParameter("@durum", yeniDurum),
            new SqlParameter("@id", mesajID)
        };

                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teklif durumu güncellenirken hata: " + ex.Message);
                return false;
            }
        }

        public bool TeklifZatenKabulEdildiMi(int urunID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Mesajlasma WHERE UrunID = @urunID AND Durum = 'Teklif - Kabul'";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@urunID", urunID)
                };

                DatabaseHelper db = new DatabaseHelper();
                object result = db.ExecuteScalar(query, parameters);

                int sayi = result != null ? Convert.ToInt32(result) : 0;
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teklif kontrolü sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
        }
        public void DigerTeklifleriReddet(int urunID, int haricMesajID)
        {
            try
            {
                string query = "UPDATE Mesajlasma SET Durum = 'Teklif - Reddedildi' WHERE UrunID = @urunID AND FiyatTeklifi IS NOT NULL AND Durum = 'Teklif - Beklemede' AND MesajID != @mesajID";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@urunID", urunID),
            new SqlParameter("@mesajID", haricMesajID)
                };

                DatabaseHelper db = new DatabaseHelper();
                db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Diğer teklifleri reddederken hata oluştu:\n" + ex.Message);
            }
        }

        public bool TeklifGeriAl(int mesajID)
        {
            try
            {
                string query = "UPDATE Mesajlasma SET Durum = 'Teklif - Geri Alındı' WHERE MesajID = @id";
                SqlParameter[] parameters = {
            new SqlParameter("@id", mesajID)
        };

                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teklif geri alınırken hata: " + ex.Message);
                return false;
            }
        }

    }
}
