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
    public partial class frmHazirlikTest : Form
    {
        public frmHazirlikTest()
        {
            InitializeComponent();
        }

        Ogrenci ogrenci = new Ogrenci();
        private void btnBasla_Click(object sender, EventArgs e)
        {
            TestinGorunurlugunuDegistir();
            SiradakiSoru();
            btnBasla.Enabled = false;
            picHazirlik.Visible = false;
        }

        private void HazirlikTestForm_Load(object sender, EventArgs e)
        {
            TestinGorunurlugunuDegistir();
            ogrenci.HazirlikTestiIslemleri.BugunSorulacakSorulariVeritabanindanCek();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblA);
            SiradakiSoru();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblB);
            SiradakiSoru();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblC);
            SiradakiSoru();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblD);
            SiradakiSoru();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblE);
            SiradakiSoru();
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            string dogruAnalizi = ogrenci.HazirlikTestiIslemleri.AnalizYap(ogrenci.DogruCozulenKonular, "Doğru");
            string yanlisAnalizi = ogrenci.HazirlikTestiIslemleri.AnalizYap(ogrenci.YanlisCozulenKonular, "Yanlış");

            string tumAnaliz = "Doğru Yapılanlar :\n" + dogruAnalizi + "\n\nYanlış Yapılanlar :\n" + yanlisAnalizi;
            ogrenci.SigmaTestiIslemleri.AnaliziGosterVePrintEt(tumAnaliz);
        }

        private void NormalTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOgrenciEkraninaDon_Click(object sender, EventArgs e)
        {
            ogrenci.DogruCozulenKonular.Clear();
            ogrenci.YanlisCozulenKonular.Clear();
            formGecis.FormlarArasıGecisYap(this, "ogrenciForm");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.FormlarArasıGecisYap(this, "girisForm");
        }

        public void SiradakiSoru()
        {
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            while (ogrenci.HazirlikTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                ogrenci.HazirlikTestiIslemleri.SiradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
                return;
            }
            ogrenci.HazirlikTestiIslemleri.SiradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
            TestinGorunurlugunuDegistir();
            picSoruResmi.Visible = false;
        }

        public void TestinGorunurlugunuDegistir()
        {
            Label[] labellar = { lblA, lblB, lblC, lblD, lblE, lblSoruNo, lblSoruGovde };
            Button[] butonlar = { btnA, btnB, btnC, btnD, btnE, btnAnaliz };
            ogrenci.HazirlikTestiIslemleri.TestOgelerininGorunurlugunuDegistir(labellar, butonlar, picSoruResmi);
            if (ogrenci.HazirlikTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                btnAnaliz.Visible = false;
                return;
            }
        }
    }
}
