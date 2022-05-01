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
        SigmaTest sigma = new SigmaTest();

        private void SigmaTestForm_Load(object sender, EventArgs e)
        {        
            sigma.bugunSorulacakSorulariCek();
            ogrenci.cozulecekSorularinIDleriniCek(sigma.bugunSorulacakSorular);
        }
        private void btnBasla_Click(object sender, EventArgs e)
        {
            siradakiSoru();          
            btnBasla.Enabled = false;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            sigma.dogruYanlisKontroluYap(ogrenci, lblA);
            sigma.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblA);
            siradakiSoru();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            sigma.dogruYanlisKontroluYap(ogrenci, lblB);
            sigma.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblB);
            siradakiSoru();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            sigma.dogruYanlisKontroluYap(ogrenci, lblC);
            sigma.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblC);
            siradakiSoru();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            sigma.dogruYanlisKontroluYap(ogrenci, lblD);
            sigma.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblD);
            siradakiSoru();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            sigma.dogruYanlisKontroluYap(ogrenci, lblE);
            sigma.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblE);
            siradakiSoru();
        }
        private void SigmaTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

        public void siradakiSoru()
        {
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            while (ogrenci.TestteCozecegiSorularinIDleri.Count > 0)
            {
                ogrenci.IslemYapilacakSoru.secenekleriVeBilgileriAta(ogrenci.TestteCozecegiSorularinIDleri[0]);
                ogrenci.TestteCozecegiSorularinIDleri.RemoveAt(0);
                break;
            }
            sigma.soruyuFormaRandomSeceneklerleYansıt(ogrenci.IslemYapilacakSoru, lblSoruGovde, seceneklerArray, picSoruResmi);
        }
    }
}
