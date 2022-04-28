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
            admin.siradakiSoru();
            formaYansit();
        }


        private void btnSiradaki_Click(object sender, EventArgs e)
        {
            admin.siradakiSoru();
            formaYansit();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            admin.soruyuOnayla();
            formaYansit();
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            admin.soruyuReddet();
            formaYansit();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }
        public void formaYansit()
        {
            if (admin.siradaSoruVarMi)
            {
                grpSoru.Visible = true;
                lblSoruGovde.Text = admin.KontrolEdilecekSoru.Govde;
                lblA.Text = admin.KontrolEdilecekSoru.DogruCevap;
                lblB.Text = admin.KontrolEdilecekSoru.YanlisCevap1;
                lblC.Text = admin.KontrolEdilecekSoru.YanlisCevap2;
                lblD.Text = admin.KontrolEdilecekSoru.YanlisCevap3;
                lblE.Text = admin.KontrolEdilecekSoru.YanlisCevap4;
                if (admin.KontrolEdilecekSoru.ResimYolu != null)
                {
                    picSoruResmi.Visible = true;
                    picSoruResmi.ImageLocation = admin.KontrolEdilecekSoru.ResimYolu;
                    picSoruResmi.Height = admin.KontrolEdilecekSoru.ResimYuksekligi;
                    picSoruResmi.Width = admin.KontrolEdilecekSoru.ResimGenisligi;
                }
                else
                {
                    picSoruResmi.Visible = false;
                }
            }
            else
            {
                grpSoru.Visible = false;
            }
                       
        }
    }
}
