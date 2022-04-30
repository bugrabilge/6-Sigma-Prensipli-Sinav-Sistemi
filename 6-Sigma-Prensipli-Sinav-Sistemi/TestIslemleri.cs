using System;
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
        public veriTabaniBaglanti Veritabani { get; set; }
        public TestIslemleri()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            this.Veritabani = vt;
        }
        public void soruyuFormaRandomSeceneklerleYansıt(Soru soru, Label lblGovde, Label[] seceneklerArray , PictureBox box)
        {
            var rnd = new Random();
            List<Label> randomSecenekler = new List<Label>();
            Label x;
            // Seceneklerimizi yazdıracagimiz labelları label arrayden random sekilde label listeye ekliyoruz ve atamalari gerceklestiriyoruz
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
                ogrenci.TestteCozduguSoruSayisi++;
                MessageBox.Show("dogru");              
            }
            else // secenegin labelinda yazan sorunun yanlis cevabiysa
            {
                ogrenci.YanlisSayisi++;
                MessageBox.Show("yanlis");               
            }          
        }

        public void sigmaIslemleri(Soru soru, Label secenek)
        {
            Veritabani.baglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.Parameters.Clear();
            if (secenek.Text == soru.DogruCevap) // soruya dogru cevap verilmis ise
            {
                soruyuTarihlerleSigmaTablosunaEkleVeyaCikar(soru.ID);
            }
            else // soruya yanlis cevap verilmis ise
            {           
                Veritabani.Komut.CommandText = "DELETE FROM dbo.SigmaDates WHERE QuestionID ='" + soru.ID + "'";
            }            
            Veritabani.Komut.ExecuteNonQuery();
            Veritabani.baglantiyiKes();
        }

        private void soruyuTarihlerleSigmaTablosunaEkleVeyaCikar(int soruID)
        {
            Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.SigmaDates WHERE QuestionID='" + soruID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (!Veritabani.VeriOkuyucu.Read()) // Eger SigmaDates tablosunda sorunun id'sinde bir soru bulunmuyorsa soruyu tabloya ekler
            {
                Veritabani.VeriOkuyucu.Close();
                soruyuSigmaTablosunaEkle(soruID);
            }
            else // soru halihazırda SigmaDates tablosuna eklenmisse dogru cevaplanma sayısı olan TrueCount degeri 1 arttırılır
            {
                Veritabani.VeriOkuyucu.Close();
                dogruCevaplamaSayisiniKontrolEtVeIslemYap(soruID);
            }
        }

        private void dogruCevaplamaSayisiniKontrolEtVeIslemYap(int soruID)
        {
            Veritabani.Komut.CommandText = "SELECT Q.QuestionID, S.QuestionID, S.TrueCount FROM dbo.Questions Q, dbo.SigmaDates S WHERE Q.QuestionID = S.QuestionID AND S.QuestionID='" + soruID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            Veritabani.VeriOkuyucu.Read();
            int dogruSayisi = Convert.ToInt32(Veritabani.VeriOkuyucu["TrueCount"]);
            if (dogruSayisi>5) // Sorunun ust uste dogru cevaplanma sayisi 5'den büyükse
            {
                Veritabani.VeriOkuyucu.Close();
                // QuestionStatus 2 yapiliyor ve böylece soru soru havuzundan cekilmis oluyor. Tekrar ögrencinin karsisina testlerde cıkmıyor
                Veritabani.Komut.CommandText = "UPDATE dbo.Questions SET QuestionStatus = 2 WHERE QuestionID ='" + soruID + "'";
                Veritabani.Komut.ExecuteNonQuery();
                Veritabani.VeriOkuyucu.Close();
                // ve soru sigma tablosundan siliniyor
                Veritabani.Komut.CommandText = "DELETE FROM dbo.SigmaDates WHERE QuestionID ='" + soruID + "'";
            }
            else // Sorunun ust uste dogru cevaplanma sayisi henuz 6 olmadıysa dogru sayacını 1 arttırıyoruz
            {
                Veritabani.VeriOkuyucu.Close();
                Veritabani.Komut.CommandText = "UPDATE dbo.SigmaDates SET TrueCount = (TrueCount + 1) WHERE QuestionID ='" + soruID + "'";
            }           
        }

        private void soruyuSigmaTablosunaEkle(int soruID)
        {
            Veritabani.Komut.CommandText = "insert into dbo.SigmaDates (QuestionID, FirstTime, SecondTime, ThirdTime, FourthTime, FifthTime, SixthTime) " +
                "values (@soruID, @ilk, @ikinci, @ucuncu, @dorduncu, @besinci, @altinci)";
            Veritabani.Komut.Parameters.AddWithValue("@soruID", soruID);
            Veritabani.Komut.Parameters.AddWithValue("@ilk", DateTime.Now.AddDays(1));
            Veritabani.Komut.Parameters.AddWithValue("@ikinci", DateTime.Now.AddDays(7));
            Veritabani.Komut.Parameters.AddWithValue("@ucuncu", DateTime.Now.AddMonths(1));
            Veritabani.Komut.Parameters.AddWithValue("@dorduncu", DateTime.Now.AddMonths(3));
            Veritabani.Komut.Parameters.AddWithValue("@besinci", DateTime.Now.AddMonths(6));
            Veritabani.Komut.Parameters.AddWithValue("@altinci", DateTime.Now.AddYears(1));
        }
    }
}
