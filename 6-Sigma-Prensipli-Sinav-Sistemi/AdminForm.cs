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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        Admin admin = new Admin();
        
        private void AdminForm_Load(object sender, EventArgs e)
        {
            admin.IslemYapilacakSoru.siradakiSoruBilgileriniCekVeAta(0);
            soruBilgileriniFormaYansit();
        }


        private void btnSiradaki_Click(object sender, EventArgs e)
        {
            admin.IslemYapilacakSoru.siradakiSoruBilgileriniCekVeAta(0);
            soruBilgileriniFormaYansit();
            if (!admin.IslemYapilacakSoru.siradaSoruVarMi)
            {
                MessageBox.Show("Onay Bekleyen Soru Bulunmamaktadır.\nÇıkış Yapabilirsiniz.");
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            admin.soruyuOnayla();
            soruBilgileriniFormaYansit();
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            admin.soruyuReddet();
            soruBilgileriniFormaYansit();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

         public void soruBilgileriniFormaYansit()
        {
            if (admin.IslemYapilacakSoru.siradaSoruVarMi)
            {
                grpSoru.Visible = true;
                Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
                TestIslemleri testIslemleri = new TestIslemleri();
                testIslemleri.soruyuFormaRandomSeceneklerleYansıt(admin.IslemYapilacakSoru, lblSoruGovde, seceneklerArray, picSoruResmi);
                lblDcevap.Text = admin.IslemYapilacakSoru.DogruCevap;
            }
            else
            {
                grpSoru.Visible = false;
                lblDcevap.Visible = false;
                btnOnayla.Enabled = false;
                btnReddet.Enabled = false;
            }
        }
       
    }
}
