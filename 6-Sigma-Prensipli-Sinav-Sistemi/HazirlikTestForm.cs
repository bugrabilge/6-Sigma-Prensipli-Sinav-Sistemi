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
    public partial class HazirlikTestForm : Form
    {
        public HazirlikTestForm()
        {
            InitializeComponent();
        }

        Ogrenci ogrenci = new Ogrenci();
        private void btnBasla_Click(object sender, EventArgs e)
        {
            testinGorunurlugunuDegistir();
            siradakiSoru();
            btnBasla.Enabled = false;
        }

        private void HazirlikTestForm_Load(object sender, EventArgs e)
        {
            testinGorunurlugunuDegistir();
            ogrenci.HazirlikTestiIslemleri.bugunSorulacakSorulariVeritabanindanCek();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblA);
            siradakiSoru();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblB);
            siradakiSoru();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblC);
            siradakiSoru();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblD);
            siradakiSoru();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            ogrenci.HazirlikTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblE);
            siradakiSoru();
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            string dogruAnalizi = ogrenci.HazirlikTestiIslemleri.AnalizYap(ogrenci.DogruCozulenKonular, "Doğru");
            string yanlisAnalizi = ogrenci.HazirlikTestiIslemleri.AnalizYap(ogrenci.YanlisCozulenKonular, "Yanlış");

            string tumAnaliz = "Doğru Yapılanlar :\n" + dogruAnalizi + "\n\nYanlış Yapılanlar :\n" + yanlisAnalizi;
            ogrenci.SigmaTestiIslemleri.analiziGosterVePrintEt(tumAnaliz);
        }

        private void NormalTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOgrenciEkraninaDon_Click(object sender, EventArgs e)
        {
            ogrenci.DogruCozulenKonular.Clear();
            ogrenci.YanlisCozulenKonular.Clear();
            formGecis.formlarArasıGecisYap(this, "ogrenciForm");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

        public void siradakiSoru()
        {
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            while (ogrenci.HazirlikTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                ogrenci.HazirlikTestiIslemleri.siradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
                return;
            }
            ogrenci.HazirlikTestiIslemleri.siradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
            testinGorunurlugunuDegistir();
            picSoruResmi.Visible = false;
        }

        public void testinGorunurlugunuDegistir()
        {
            Label[] labellar = { lblA, lblB, lblC, lblD, lblE, lblSoruNo, lblSoruGovde };
            Button[] butonlar = { btnA, btnB, btnC, btnD, btnE, btnAnaliz };
            ogrenci.HazirlikTestiIslemleri.testOgelerininGorunurlugunuDegistir(labellar, butonlar, picSoruResmi);
            if (ogrenci.HazirlikTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                btnAnaliz.Visible = false;
                return;
            }
        }
    }
}
