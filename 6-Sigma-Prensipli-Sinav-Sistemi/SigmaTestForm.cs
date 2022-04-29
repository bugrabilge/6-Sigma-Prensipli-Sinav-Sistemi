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
    public partial class SigmaTestForm : Form
    {
        public SigmaTestForm()
        {
            InitializeComponent();
        }
        
        Ogrenci ogrenci = new Ogrenci();
        TestIslemleri testIslemleri = new TestIslemleri();
        
        private void btnBasla_Click(object sender, EventArgs e)
        {
            siradakiSoru();          
            btnBasla.Enabled = false;
        }

        public void siradakiSoru()
        {
            
            ogrenci.IslemYapilacakSoru.siradakiSoruBilgileriniCekVeAta(1);
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            testIslemleri.soruyuFormaRandomSeceneklerleYansıt(ogrenci.IslemYapilacakSoru, lblSoruGovde, seceneklerArray);
        }

        private void SigmaTestForm_Load(object sender, EventArgs e)
        {
            
        }

        private void SigmaTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            testIslemleri.dogruYanlisKontroluYap(ogrenci, lblA);
            siradakiSoru();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            testIslemleri.dogruYanlisKontroluYap(ogrenci, lblB);
            siradakiSoru();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            testIslemleri.dogruYanlisKontroluYap(ogrenci, lblC);
            siradakiSoru();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            testIslemleri.dogruYanlisKontroluYap(ogrenci, lblD);
            siradakiSoru();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            testIslemleri.dogruYanlisKontroluYap(ogrenci, lblE);
            siradakiSoru();
        }
    }
}
