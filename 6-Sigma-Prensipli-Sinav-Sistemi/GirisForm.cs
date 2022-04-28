using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{

    public partial class GirisForm : Form
    {

        public GirisForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            Giris giris = new Giris();
            giris.kullaniciAdiKontrolVeGiris(txtKullaniciAdi.Text, txtSifre.Text, this);
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "kayitForm");
        }

        private void GirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        

        private void lblSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "sifreKurtarmaForm");
        }
    }
}
