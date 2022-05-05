using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class TestIslemleri
    {
        public int KullaniciID { get; set; }
        public List<int> bugunSorulacakSorularinIDleri { get; set; }
        public veriTabaniBaglanti Veritabani { get; set; }

        public TestIslemleri()
        {
            //veriTabaniBaglanti vt = new veriTabaniBaglanti();
            //this.Veritabani = vt;
            this.Veritabani = new veriTabaniBaglanti();
            this.KullaniciID = Giris.girisYapanKullaniciID;
            bugunSorulacakSorularinIDleri = new List<int>();

        }
        public void soruyuFormaRandomSeceneklerleYansıt(Soru soru, Label lblGovde, Label[] seceneklerArray , PictureBox box)
        {
            var rnd = new Random();
            List<Label> randomSecenekler = new List<Label>();
            Label x;
            // Seceneklerimizi yazdıracagimiz labelları label arrayden random sekilde label listeye ekliyoruz ve form atamalarini gerceklestiriyoruz
            while (randomSecenekler.Count < 5)
            {
                x = (Label)seceneklerArray.GetValue(rnd.Next(0, 5));
                if (!randomSecenekler.Contains(x))
                {
                    randomSecenekler.Add(x);
                }
            }
            
            lblGovde.Text = soru.Govde;
            randomSecenekler[0].Text = soru.DogruCevap;
            randomSecenekler[1].Text = soru.YanlisCevap1;
            randomSecenekler[2].Text = soru.YanlisCevap2;
            randomSecenekler[3].Text = soru.YanlisCevap3;
            randomSecenekler[4].Text = soru.YanlisCevap4;

            if (soru.ResimYolu != null)
            {
                box.Visible = true;
                box.ImageLocation = soru.ResimYolu;
                box.Height = soru.ResimYuksekligi;
                box.Width = soru.ResimGenisligi;
            }
            else
            {
                box.Visible = false;
            }
        }

        public void dogruYanlisKontroluYap(Ogrenci ogrenci, Label secenek)
        {
            if (secenek.Text == ogrenci.IslemYapilacakSoru.DogruCevap) // secenegin labelinda yazan sorunun dogru cevabiysa
            {
                ogrenci.DogruSayisi++;
                ogrenci.DogruCozduguSorularinIDleri.Add(ogrenci.IslemYapilacakSoru.ID);              
            }
            else // secenegin labelinda yazan sorunun yanlis cevabiysa
            {
                ogrenci.YanlisSayisi++;
                ogrenci.YanlisCozduguSorularinIDleri.Add(ogrenci.IslemYapilacakSoru.ID);           
            }          
        }
        
        public void testOgelerininGorunurlugunuDegistir(Label[] labellar, Button[] butonlar, PictureBox box)
        {
            foreach (Label l in labellar) // gelen tüm ögelerin görünürlügünü tersine ceviriyoruz
            {
                l.Visible = !l.Visible;
            }

            foreach (Button b in butonlar)
            {
                b.Visible = !b.Visible;
            }

            box.Visible = !box.Visible;
        }

        public virtual void bugunSorulacakSorulariVeritabanindanCek()
        {
            Veritabani.baglantiYoksaYeniBaglantiAc();
            /* virtual metot olarak veritabanından 20 tane onaylanmış soru çekiyoruz
             * bu metot hazırlık sınıfında direkt kullanılıyor
             * sigma sınıfında ise override ediliyor */
            Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.Questions WHERE NOT (QuestionStatus = '" + 0 + "') ORDER BY NEWID()";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            int sayac = 0;
            while (Veritabani.VeriOkuyucu.Read())
            {
                if (!bugunSorulacakSorularinIDleri.Contains(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"])) && sayac < 20)
                {
                    bugunSorulacakSorularinIDleri.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                    sayac++;
                }
            }
            Veritabani.baglantiyiKes();
        }

        public void siradakiSoru(Ogrenci ogrenci, Label govde, Label no, Label[] secenekler, PictureBox box)
        {
            /* veritabanından çektiğimiz soruların id'lerini tuttuğumuz listenin countu 0 olana kadar
             * soruları her bu fonksiyon çağrıldığında birer birer soru nesnemize atıyoruz ve
             * bu nesneyi form ögelerine yansıtıyoruz
             */
            while (bugunSorulacakSorularinIDleri.Count != 0)
            {
                ogrenci.IslemYapilacakSoru.secenekleriVeBilgileriAta(bugunSorulacakSorularinIDleri[0]);
                soruyuFormaRandomSeceneklerleYansıt(ogrenci.IslemYapilacakSoru, govde, secenekler, box);
                bugunSorulacakSorularinIDleri.RemoveAt(0);
                no.Text = (ogrenci.DogruSayisi + ogrenci.YanlisSayisi + 1).ToString() + ")";
                return;
            }
            if (bugunSorulacakSorularinIDleri.Count == 0)
            {
                MessageBox.Show("Tebrikler testi tamamladınız!\nDoğru sayiniz :" + ogrenci.DogruSayisi + "\nYanlış sayınız :" + ogrenci.YanlisSayisi +
                    "\nAnaliz butonu ile testin analizini görebilirsiniz...");
                //testOgelerininGorunurlugunuDegistir();
                box.Visible = false;
            }
        }
    }
}
