using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public partial class frmOgrenci : Form
    {
        public frmOgrenci()
        {
            InitializeComponent();
        }
        private void btnSigma_Click(object sender, EventArgs e)
        {
            formGecis.FormlarArasıGecisYap(this, "sigmaTestForm");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.FormlarArasıGecisYap(this, "girisForm");
        }

        private void OgrenciForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNormalTest_Click(object sender, EventArgs e)
        {
            formGecis.FormlarArasıGecisYap(this, "normalTestForm");
        }

        private void OgrenciForm_Load(object sender, EventArgs e)
        {
            lblOgrenciIsım.Text = Giris.GirisYapanKullaniciAd + " " + Giris.GirisYapanKullaniciSoyad;
        }
    }
}
