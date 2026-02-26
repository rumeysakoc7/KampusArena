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
    public partial class Kategoriler : Form
    {
        private readonly KategoriRepository _kategoriRepository;
        public Kategoriler()
        {
            InitializeComponent();
            _kategoriRepository = new KategoriRepository();
        }

        private void dataGridViewkategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewkategori.Rows[e.RowIndex];
                textBoxkategoriad.Text = row.Cells["KategoriAdi"].Value.ToString();
                textBoxaciklama.Text = row.Cells["Aciklama"].Value.ToString();
            }
        }

        private void YukleKategoriler(bool aktif)
        {
            try
            {
                dataGridViewkategori.DataSource = _kategoriRepository.GetKategoriler(aktif);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void Kategoriler_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonaktif.Checked = true;
                YukleKategoriler(true);
                dataGridViewkategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewkategori.AllowUserToAddRows = false;
                dataGridViewkategori.CurrentCellDirtyStateChanged += (s, ev) =>
                {
                    if (dataGridViewkategori.IsCurrentCellDirty)
                        dataGridViewkategori.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sayfa yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void radioButtonaktif_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonaktif.Checked)
                YukleKategoriler(true);
        }

        private void radioButtonpasif_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonpasif.Checked)
                YukleKategoriler(false);
        }

        private void buttonekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxkategoriad.Text) || string.IsNullOrWhiteSpace(textBoxaciklama.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Kategori kategori = new Kategori
                {
                    KategoriAdi = textBoxkategoriad.Text.Trim(),
                    Aciklama = textBoxaciklama.Text.Trim(),
                    Aktif = true

                };

                if (_kategoriRepository.AddKategori(kategori))
                {
                    MessageBox.Show("Kategori eklendi.");
                    YukleKategoriler(true);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori eklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewkategori.CurrentRow == null) return;

                int kategoriId = Convert.ToInt32(dataGridViewkategori.CurrentRow.Cells["KategoriID"].Value);

                if (_kategoriRepository.DeleteKategoriSoft(kategoriId))
                {
                    MessageBox.Show("Kategori pasifleştirildi.");
                    YukleKategoriler(radioButtonaktif.Checked);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori silinirken hata oluştu:\n" + ex.Message);
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewkategori.CurrentRow == null) return;

                int kategoriId = Convert.ToInt32(dataGridViewkategori.CurrentRow.Cells["KategoriID"].Value);
                string yeniAd = textBoxkategoriad.Text.Trim();
                string yeniAciklama = textBoxaciklama.Text.Trim();
                bool yeniAktif = Convert.ToBoolean(dataGridViewkategori.CurrentRow.Cells["Aktif"].Value);

                DataGridViewRow row = dataGridViewkategori.CurrentRow;
                string mevcutAd = row.Cells["KategoriAdi"].Value.ToString();
                string mevcutAciklama = row.Cells["Aciklama"].Value?.ToString() ?? "";
                bool mevcutAktif = _kategoriRepository.GetKategoriAktifDurumu(kategoriId);


                bool degisiklikVar =
                    mevcutAd != yeniAd ||
                    mevcutAciklama != yeniAciklama ||
                    mevcutAktif != yeniAktif;

                if (!degisiklikVar)
                {
                    MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Kategori kategori = new Kategori
                {
                    KategoriID = kategoriId,
                    KategoriAdi = yeniAd,
                    Aciklama = yeniAciklama,
                    Aktif = yeniAktif
                };

                if (_kategoriRepository.UpdateKategori(kategori))
                {
                    MessageBox.Show("Kategori güncellendi.");
                    YukleKategoriler(radioButtonaktif.Checked);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori güncellenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void Temizle()
        {
            textBoxkategoriad.Clear();
            textBoxaciklama.Clear();
        }
        private void buttontemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void textBoxara_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string aranan = textBoxara.Text.Trim();

                if (string.IsNullOrEmpty(aranan))
                {
                    YukleKategoriler(true);
                }
                else
                {
                    dataGridViewkategori.DataSource = _kategoriRepository.AraKategoriler(aranan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama yapılırken hata oluştu:\n" + ex.Message);
            }
        }
    }
}
