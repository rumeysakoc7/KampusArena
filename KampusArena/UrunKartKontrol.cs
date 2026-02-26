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
    public partial class UrunKartKontrol : UserControl
    {
        private Urun _urun;
        public UrunKartKontrol()
        {
            InitializeComponent();
        }

        public void UrunBilgisiAyarla(Urun urun)
        {
            _urun = urun;

            labelurunad.AutoSize = true;
            labelurunad.MaximumSize = new Size(260, 0); 

            labelurunad.Font = new Font("Segoe UI",10,FontStyle.Bold);

            labelurunad.Text = "Ürün Adı: " + urun.UrunAdi;
            labelfiyat.Text = "Fiyat: " + urun.Fiyat.ToString("C2");
            labeldurum.Text = "Kiralık/Satılık: " + urun.Durum;

            try
            {
                if (!string.IsNullOrEmpty(urun.ResimYolu) && File.Exists(urun.ResimYolu))
                {
                    pictureBoxurunresim.Image = Image.FromFile(urun.ResimYolu);
                    pictureBoxurunresim.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBoxurunresim.Image = null;
                    pictureBoxurunresim.BackColor = Color.LightGray;
                }
            }
            catch
            {
                pictureBoxurunresim.Image = null;
                pictureBoxurunresim.BackColor = Color.LightGray;
            }
        }

        private void buttonDetay_Click(object sender, EventArgs e)
        {
            if (_urun != null)
            {
                MessageBox.Show($"Ürün: {_urun.UrunAdi}\n\nFiyat: {_urun.Fiyat:C2}\n\nAçıklama:\n{_urun.Aciklama}",
                                "Ürün Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UrunKartKontrol_Load(object sender, EventArgs e)
        {
            this.Size = new Size(350, 400);
        }

        private void buttondetaylar_Click(object sender, EventArgs e)
        {
            FormUrunDetay detayForm = new FormUrunDetay(_urun);
            detayForm.ShowDialog();
        }
    }
}
