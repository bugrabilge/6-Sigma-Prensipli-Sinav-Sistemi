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
    public partial class SifreKurtarmaForm : Form
    {
        public SifreKurtarmaForm()
        {
            InitializeComponent();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            SifreKurtarma sifreKurtarma = new SifreKurtarma();
            sifreKurtarma.cevaplariKontrolEtVeSonucVer(txtKullaniciAdi.Text, txtCevap.Text, this);
        }

        private void SifreKurtarmaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }
    }
}
