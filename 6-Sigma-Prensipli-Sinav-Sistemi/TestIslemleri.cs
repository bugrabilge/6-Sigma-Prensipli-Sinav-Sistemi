using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class TestIslemleri
    {
        public int KullaniciID { get; set; }
        public List<int> bugunSorulacakSorularinIDleri { get; set; }
        public veriTabaniBaglanti Veritabani { get; set; }

        public TestIslemleri()
        {
            this.Veritabani = new veriTabaniBaglanti();
            this.KullaniciID = Giris.GirisYapanKullaniciID;
            bugunSorulacakSorularinIDleri = new List<int>();
        }
        public void SoruyuFormaRandomSeceneklerleYansıt(Soru soru, Label lblGovde, Label[] seceneklerArray , PictureBox box)
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

        public void DogruYanlisKontroluYap(Ogrenci ogrenci, Label secenek)
        {
            if (secenek.Text == ogrenci.IslemYapilacakSoru.DogruCevap) // secenegin labelinda yazan sorunun dogru cevabiysa
            {
                ogrenci.DogruSayisi++;
                SoruIDlerineGoreUniteIsımleriCek(ogrenci.IslemYapilacakSoru.ID, ogrenci.DogruCozulenKonular);
            }
            else // secenegin labelinda yazan sorunun yanlis cevabiysa
            {
                ogrenci.YanlisSayisi++;
                SoruIDlerineGoreUniteIsımleriCek(ogrenci.IslemYapilacakSoru.ID, ogrenci.YanlisCozulenKonular);
            }          
        }
        
        public void TestOgelerininGorunurlugunuDegistir(Label[] labellar, Button[] butonlar, PictureBox box)
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

        public virtual void BugunSorulacakSorulariVeritabanindanCek()
        {
            Veritabani.BaglantiYoksaYeniBaglantiAc();
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
            Veritabani.BaglantiyiKes();
        }

        public void SiradakiSoru(Ogrenci ogrenci, Label govde, Label no, Label[] secenekler, PictureBox box)
        {
            /* veritabanından çektiğimiz soruların id'lerini tuttuğumuz listenin countu 0 olana kadar
             * soruları her bu fonksiyon çağrıldığında birer birer soru nesnemize atıyoruz ve
             * bu nesneyi form ögelerine yansıtıyoruz
             */
            while (bugunSorulacakSorularinIDleri.Count != 0)
            {
                ogrenci.IslemYapilacakSoru.SecenekleriVeBilgileriAta(bugunSorulacakSorularinIDleri[0]);
                SoruyuFormaRandomSeceneklerleYansıt(ogrenci.IslemYapilacakSoru, govde, secenekler, box);
                bugunSorulacakSorularinIDleri.RemoveAt(0);
                no.Text = (ogrenci.DogruSayisi + ogrenci.YanlisSayisi + 1).ToString() + ")";
                return;
            }
            if (bugunSorulacakSorularinIDleri.Count == 0)
            {
                MessageBox.Show("Tebrikler testi tamamladınız!\nDoğru sayiniz :" + ogrenci.DogruSayisi + "\nYanlış sayınız :" + ogrenci.YanlisSayisi +
                    "\nAnaliz butonu ile testin analizini görebilirsiniz...");
                box.Visible = false;
            }
        }

        private void SoruIDlerineGoreUniteIsımleriCek(int ID, List<string> konularinIslenecegiList)
        {
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "SELECT U.UnitName FROM dbo.UnitsAndSections U, dbo.Questions Q WHERE U.UnitID = Q.UnitID AND Q.QuestionID = '" + ID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (Veritabani.VeriOkuyucu.Read())
            {
                string konu = Veritabani.VeriOkuyucu["Unitname"].ToString();
                konularinIslenecegiList.Add(konu);
            }
            Veritabani.BaglantiyiKes();
        }

        public string AnalizYap(List<string> analizEdilecekListe, string tur)
        {
            var q = from x in analizEdilecekListe
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            List<string> konular = new List<string>();
            foreach (var x in q)
            {
                konular.Add("Ünite: " + x.Value + " "+tur+" Sayisi: " + x.Count);
            }
            var mesaj = string.Join(Environment.NewLine, konular);
            return mesaj;
        }

        public void AnaliziGosterVePrintEt(string yazdırılacakMetin)
        {
            DialogResult result1 = MessageBox.Show(yazdırılacakMetin + "\n\nAnalizi yazdırmak için evete, devam etmek için hayıra basınız...",
                                                   "Analiz", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                PrintDocument p = new PrintDocument();
                p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                {
                    e1.Graphics.DrawString(yazdırılacakMetin, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                };
                try
                {
                    p.Print();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured While Printing", ex);
                }
            }
            else
            {
                return;
            }
        }
    }
}
