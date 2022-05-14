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
using System.Drawing.Printing;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public partial class frmSigmaTest : Form
    {
        public frmSigmaTest()
        {
            InitializeComponent();
        }
        Ogrenci ogrenci = new Ogrenci();
        private void SigmaTestForm_Load(object sender, EventArgs e)
        {
            TestinGorunurlugunuDegistir();
            ogrenci.SigmaTestiIslemleri.BugunSorulacakSorulariVeritabanindanCek();
            dakika=ogrenci.SigmaTestiIslemleri.bugunSorulacakSorularinIDleri.Count;
        }
        private void btnBasla_Click(object sender, EventArgs e)
        {           
            TestinGorunurlugunuDegistir();
            SiradakiSoru();
            timer.Start();
            btnBasla.Enabled = false;
            picSigmaIcon.Visible = false;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblA);
            ogrenci.SigmaTestiIslemleri.SigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblA);
            SiradakiSoru();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblB);
            ogrenci.SigmaTestiIslemleri.SigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblB);
            SiradakiSoru();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblC);
            ogrenci.SigmaTestiIslemleri.SigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblC);
            SiradakiSoru();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblD);
            ogrenci.SigmaTestiIslemleri.SigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblD);
            SiradakiSoru();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            ogrenci.SigmaTestiIslemleri.DogruYanlisKontroluYap(ogrenci, lblE);
            ogrenci.SigmaTestiIslemleri.SigmaCevabaGoreVeritabaniIslemleriniYap(ogrenci.IslemYapilacakSoru, lblE);
            SiradakiSoru();
        }
        private void SigmaTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            ogrenci.DogruCozulenKonular.Clear();
            ogrenci.YanlisCozulenKonular.Clear();
            formGecis.FormlarArasıGecisYap(this, "girisForm");
        }
        
        public void SiradakiSoru()
        {
            Label[] seceneklerArray = { lblA, lblB, lblC, lblD, lblE };
            while (ogrenci.SigmaTestiIslemleri.bugunSorulacakSorularinIDleri.Count != 0)
            {
                ogrenci.SigmaTestiIslemleri.SiradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
                return;
            }
            timer.Stop();
            ogrenci.SigmaTestiIslemleri.SiradakiSoru(ogrenci, lblSoruGovde, lblSoruNo, seceneklerArray, picSoruResmi);
            TestinGorunurlugunuDegistir();
        }
        
        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            formGecis.FormlarArasıGecisYap(this, "ayarlar");
            ogrenci.SigmaTestiIslemleri.SoruCikmaSikliginiDegistir(frmAyarlar.ayarlardanDegistirilenSayilar);

        }

        public void TestinGorunurlugunuDegistir()
        {
            Label[] labellar = { lblA, lblB, lblC, lblD, lblE, lblSoruNo, lblSoruGovde };
            Button[] butonlar = { btnA, btnB, btnC, btnD, btnE, btnAnaliz };
            ogrenci.SigmaTestiIslemleri.TestOgelerininGorunurlugunuDegistir(labellar, butonlar, picSoruResmi);
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
                TestinGorunurlugunuDegistir();
            }
            lblGeriSayim.Text = string.Format("{0}:{1}", dakika, saniye.ToString().PadLeft(2, '0'));
        }

        public void btnAnaliz_Click(object sender, EventArgs e)
        {
            string dogruAnalizi = ogrenci.SigmaTestiIslemleri.AnalizYap(ogrenci.DogruCozulenKonular, "Doğru");
            string yanlisAnalizi = ogrenci.SigmaTestiIslemleri.AnalizYap(ogrenci.YanlisCozulenKonular, "Yanlış");

            string tumAnaliz = "Doğru Yapılanlar :\n" + dogruAnalizi + "\n\nYanlış Yapılanlar :\n" + yanlisAnalizi;
            ogrenci.SigmaTestiIslemleri.AnaliziGosterVePrintEt(tumAnaliz);
        }

        private void btnOgrenciEkraninaDon_Click(object sender, EventArgs e)
        {
            ogrenci.DogruCozulenKonular.Clear();
            ogrenci.YanlisCozulenKonular.Clear();
            formGecis.FormlarArasıGecisYap(this, "ogrenciForm");
        }
    }
}
