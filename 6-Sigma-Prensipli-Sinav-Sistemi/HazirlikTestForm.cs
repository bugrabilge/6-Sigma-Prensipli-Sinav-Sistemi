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


        private void NormalTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOgrenciEkraninaDon_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "ogrenciForm");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            testinGorunurlugunuDegistir();
            siradakiSoru();
            btnBasla.Enabled = false;
        }

        public void siradakiSoru()
        {
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            ogrenci.HazirlikTestiIslemleri.siradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
        }

        public void testinGorunurlugunuDegistir()
        {
            Label[] labellar = { lblA, lblB, lblC, lblD, lblE, lblSoruNo, lblSoruGovde };
            Button[] butonlar = { btnA, btnB, btnC, btnD, btnE };
            ogrenci.HazirlikTestiIslemleri.testOgelerininGorunurlugunuDegistir(labellar, butonlar, picSoruResmi);           
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
    }
}
