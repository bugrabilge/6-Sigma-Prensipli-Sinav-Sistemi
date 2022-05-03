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
            testinGorunurlugunuDegistir();
            sigma.bugunSorulacakSorulariCek();
            ogrenci.cozulecekSorularinIDleriniCek(sigma.bugunSorulacakSorular);
            //d=ogrenci.TestteCozecegiSoruSayisi;
            d = 1;
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
            while (ogrenci.TestteCozecegiSorularinIDleri.Count != 0)
            {
                ogrenci.IslemYapilacakSoru.secenekleriVeBilgileriAta(ogrenci.TestteCozecegiSorularinIDleri[0]);
                sigma.soruyuFormaRandomSeceneklerleYansıt(ogrenci.IslemYapilacakSoru, lblSoruGovde, seceneklerArray, picSoruResmi);
                ogrenci.TestteCozecegiSorularinIDleri.RemoveAt(0);
                return;
            }
            if (ogrenci.TestteCozecegiSorularinIDleri.Count == 0)
            {
                MessageBox.Show("Tebrikler testi tamamladınız!\nDoğru sayiniz :" + ogrenci.DogruSayisi + "\nYanlış sayınız :" + ogrenci.YanlisSayisi +
                    "\nAnaliz butonu ile testin analizini görebilirsiniz...");
                testinGorunurlugunuDegistir();
                picSoruResmi.Visible = false;
            }
        }
        
        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "ayarlar");
            sigma.soruCikmaSikliginiDegistir(AyarlarForm.ayarlardanDegistirilenSayilar);

        }

        public void testinGorunurlugunuDegistir()
        {
            Label[] labellar = { lblA, lblB, lblC, lblD, lblE, lblSayi, lblSoruGovde };
            Button[] butonlar = { btnA, btnB, btnC, btnD, btnE };
            sigma.testEkraniniGizle(labellar, butonlar, picSoruResmi);
        }
        
        int s;
        int d;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (lblGeriSayim.Text != "00:01")
            {
                if (s==00)
                {
                    s = 60;
                    d--;
                }
                s--;
            }
            if (s==0 && d ==0)
            {
                timer.Enabled = false;
                timer.Stop();
                MessageBox.Show("Süreniz Doldu!\nDoğru Sayınız :" + ogrenci.DogruSayisi + "\nYanlış sayınız :"+ ogrenci.YanlisSayisi);
                testinGorunurlugunuDegistir();
            }
            lblGeriSayim.Text = string.Format("{0}:{1}", d, s.ToString().PadLeft(2, '0'));
        }
    }
}
