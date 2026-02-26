using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KampusArena
{
    public partial class AdminOdemeOnay : Form
    {
        public AdminOdemeOnay()
        {
            InitializeComponent();
        }

        private void AdminOdemeOnay_Load(object sender, EventArgs e)
        {
            try
            {
                OdemeRepository repo = new OdemeRepository();
                DataTable dt = repo.GetirBekleyenOdemeler();
                dataGridViewodeme.DataSource = dt;
                dataGridViewodeme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewodeme.AllowUserToAddRows = false;

                dataGridViewodeme.Columns["DekontYolu"].Visible = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata: " + ex.Message);
            }
        }
        private void dataGridViewodeme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             try
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow satir = dataGridViewodeme.Rows[e.RowIndex];
            string dekontYolu = satir.Cells["DekontYolu"].Value?.ToString();

            if (!string.IsNullOrEmpty(dekontYolu) && File.Exists(dekontYolu))
            {
                pictureBoxdekont.Image = Image.FromFile(dekontYolu);
                pictureBoxdekont.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBoxdekont.Image = null;
                pictureBoxdekont.BackColor = Color.LightGray;
            }

            string odemeDurumu = satir.Cells["OdemeDurumu"]?.Value?.ToString();

            if (odemeDurumu == "Ödendi")
            {
                buttonteslimet.Enabled = true;
                buttononayla.Enabled = false;
                buttonred.Enabled = false;
            }
            else
            {
                buttonteslimet.Enabled = false;
                buttononayla.Enabled = true;
                buttonred.Enabled = true;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Dekont gösterilemedi: " + ex.Message);
    }
        }
        private void OdemeleriYenile()
        {
            OdemeRepository repo = new OdemeRepository();
            dataGridViewodeme.DataSource = repo.GetirBekleyenOdemeler();
            pictureBoxdekont.Image = null;
        }

        private void buttononayla_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewodeme.CurrentRow != null)
                {
                    int odemeID = Convert.ToInt32(dataGridViewodeme.CurrentRow.Cells["OdemeID"].Value);

                    OdemeRepository repo = new OdemeRepository();

                    if (repo.OdemeOnayla(odemeID))
                    {
                        repo.IlgiliOdemeDurumunuGuncelle(odemeID, "Ödendi");
                        MessageBox.Show("Ödeme başarıyla onaylandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OdemeleriYenile(); 
                                           
                        object kiralamaIDObj = dataGridViewodeme.CurrentRow.Cells["KiralamaID"].Value;

                        if (kiralamaIDObj != DBNull.Value && kiralamaIDObj != null)
                        {
                            int kiralamaID = Convert.ToInt32(kiralamaIDObj);
                            KiralamaRepository kiraRepo = new KiralamaRepository();
                            kiraRepo.KiralamaDurumuGuncelle(kiralamaID, "Onaylandı");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ödeme onaylanamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void buttonred_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewodeme.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen reddetmek için bir ödeme seçin.");
                    return;
                }

                int odemeID = Convert.ToInt32(dataGridViewodeme.CurrentRow.Cells["OdemeID"].Value);

                OdemeRepository repo = new OdemeRepository();
                bool basarili = repo.OdemeReddet(odemeID);

                if (basarili)
                {
                    MessageBox.Show("Ödeme reddedildi.");
                    AdminOdemeOnay_Load(null, null); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reddetme sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void buttonteslimet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewodeme.CurrentRow != null)
                {
                    object kiralamaIDObj = dataGridViewodeme.CurrentRow.Cells["KiralamaID"].Value;

                    if (kiralamaIDObj != DBNull.Value && kiralamaIDObj != null)
                    {
                        int kiralamaID = Convert.ToInt32(kiralamaIDObj);
                        KiralamaRepository repo = new KiralamaRepository();

                        bool guncelle = repo.TeslimDurumunuGuncelle(kiralamaID, "Teslim Edildi");

                        if (guncelle)
                        {
                            MessageBox.Show("Teslim durumu güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OdemeleriYenile(); 
                        }
                        else
                        {
                            MessageBox.Show("Teslim durumu güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu işlem satış işlemi, kiralama değil!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teslim sırasında hata oluştu:\n" + ex.Message);
            }
        }
    }
}
