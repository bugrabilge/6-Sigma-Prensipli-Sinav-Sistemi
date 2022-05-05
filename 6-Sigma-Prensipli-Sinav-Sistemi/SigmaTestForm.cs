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
        private void SigmaTestForm_Load(object sender, EventArgs e)
        {
            testinGorunurlugunuDegistir();
            ogrenci.SigmaTestiIslemleri.bugunSorulacakSorulariVeritabanindanCek();
            dakika=ogrenci.SigmaTestiIslemleri.bugunSorulacakSorularinIDleri.Count;
        }
        private void btnBasla_Click(object sender, EventArgs e)
        {           
            testinGorunurlugunuDegistir();
            siradakiSoru();
            timer.Start();
            btnBasla.Enabled = false;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblA);
            ogrenci.SigmaTestiIslemleri.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblA);
            siradakiSoru();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblB);
            ogrenci.SigmaTestiIslemleri.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblB);
            siradakiSoru();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblC);
            ogrenci.SigmaTestiIslemleri.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblC);
            siradakiSoru();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblD);
            ogrenci.SigmaTestiIslemleri.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblD);
            siradakiSoru();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.dogruYanlisKontroluYap(ogrenci, lblE);
            ogrenci.SigmaTestiIslemleri.sigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblE);
            siradakiSoru();
        }
        private void SigmaTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            ogrenci.DogruCozduguSorularinIDleri.Clear();
            ogrenci.YanlisCozduguSorularinIDleri.Clear();
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }
        
        public void siradakiSoru()
        {
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            while (ogrenci.SigmaTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                ogrenci.SigmaTestiIslemleri.siradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
                return;
            }
            timer.Stop();
            ogrenci.SigmaTestiIslemleri.siradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
            testinGorunurlugunuDegistir();
        }
        
        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "ayarlar");
            ogrenci.SigmaTestiIslemleri.soruCikmaSikliginiDegistir(AyarlarForm.ayarlardanDegistirilenSayilar);

        }

        public void testinGorunurlugunuDegistir()
        {
            Label[] labellar = { lblA, lblB, lblC, lblD, lblE, lblSoruNo, lblSoruGovde };
            Button[] butonlar = { btnA, btnB, btnC, btnD, btnE, btnAnaliz };
            ogrenci.SigmaTestiIslemleri.testOgelerininGorunurlugunuDegistir(labellar, butonlar, picSoruResmi);
            if (ogrenci.SigmaTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                btnAnaliz.Visible = false;
                btnOgrenciEkraninaDon.Enabled = false;
                return;
            }
            btnOgrenciEkraninaDon.Enabled = true;
            picSoruResmi.Visible = false;
        }
        
        int saniye=0;
        int dakika;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (lblGeriSayim.Text != "00:00")
            {
                if (saniye==00)
                {
                    saniye = 60;
                    dakika--;
                }
                saniye--;
            }
            if (saniye==0 && dakika ==0)
            {
                timer.Stop();
                timer.Enabled = false;
                MessageBox.Show("Süreniz Doldu!\nDoğru Sayınız :" + ogrenci.DogruSayisi + "\nYanlış sayınız :"+ ogrenci.YanlisSayisi +
                    "\nAnaliz butonu ile testin analizini görebilirsiniz...");
                testinGorunurlugunuDegistir();
            }
            lblGeriSayim.Text = string.Format("{0}:{1}", dakika, saniye.ToString().PadLeft(2, '0'));
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOgrenciEkraninaDon_Click(object sender, EventArgs e)
        {
            ogrenci.DogruCozduguSorularinIDleri.Clear();
            ogrenci.YanlisCozduguSorularinIDleri.Clear();
            formGecis.formlarArasıGecisYap(this, "ogrenciForm");
        }
    }
}
