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
    public class Sigma : TestIslemleri
    {
        
        public List<int> BilinenSorununSorulmaSikligi { get; set; }

        public Sigma()
        {
            BilinenSorununSorulmaSikligi = new List<int>();
            SigmaSorularininSorulmaSikliklariniCek();
        }

        public void SigmaCevabaGoreVeritabaniIslemleriniYap(Soru soru, Label secenek)
        {
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.Parameters.Clear();
            if (secenek.Text == soru.DogruCevap) // soruya dogru cevap verilmis ise
            {
                SoruyuTarihlerleSigmaTablosunaEkleVeyaCikar(soru.ID);
            }
            else // soruya yanlis cevap verilmis ise
            {
                Veritabani.Komut.CommandText = "DELETE FROM dbo.SigmaDates WHERE QuestionID ='" + soru.ID + "'";
            }
            Veritabani.Komut.ExecuteNonQuery();
            Veritabani.BaglantiyiKes();
        }

        private void SoruyuTarihlerleSigmaTablosunaEkleVeyaCikar(int soruID)
        {
            Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.SigmaDates WHERE QuestionID='" + soruID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (!Veritabani.VeriOkuyucu.Read()) // Eger SigmaDates tablosunda sorunun id'sinde bir soru bulunmuyorsa soruyu tabloya ekler
            {
                Veritabani.VeriOkuyucu.Close();
                SoruyuSigmaTablosunaEkle(soruID);
            }
            else // soru halihazırda SigmaDates tablosuna eklenmisse dogru cevaplanma sayısı olan TrueCount degeri 1 arttırılır
            {
                Veritabani.VeriOkuyucu.Close();
                DogruCevaplamaSayisiniKontrolEtVeIslemYap(soruID);
            }
        }

        private void DogruCevaplamaSayisiniKontrolEtVeIslemYap(int soruID)
        {
            Veritabani.Komut.CommandText = "SELECT Q.QuestionID, S.QuestionID, S.TrueCount FROM dbo.Questions Q, dbo.SigmaDates S WHERE Q.QuestionID = S.QuestionID AND S.QuestionID='" + soruID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            Veritabani.VeriOkuyucu.Read();
            int dogruSayisi = Convert.ToInt32(Veritabani.VeriOkuyucu["TrueCount"]);
            if (dogruSayisi > 5) // Sorunun ust uste dogru cevaplanma sayisi 5'den büyükse
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

        private void SoruyuSigmaTablosunaEkle(int soruID)
        {
            // Sorunun sonraki sorulacagi 6 tarih veritabanina ekleniyor
            Veritabani.Komut.CommandText = "insert into dbo.SigmaDates (QuestionID, FirstTime, SecondTime, ThirdTime, FourthTime, FifthTime, SixthTime) " +
                "values (@soruID, @ilk, @ikinci, @ucuncu, @dorduncu, @besinci, @altinci)";
            Veritabani.Komut.Parameters.AddWithValue("@soruID", soruID);

            Veritabani.Komut.Parameters.AddWithValue("@ilk", DateTime.Now.AddDays(BilinenSorununSorulmaSikligi[0]));
            Veritabani.Komut.Parameters.AddWithValue("@ikinci", DateTime.Now.AddDays(BilinenSorununSorulmaSikligi[1]));
            Veritabani.Komut.Parameters.AddWithValue("@ucuncu", DateTime.Now.AddDays(BilinenSorununSorulmaSikligi[2]));
            Veritabani.Komut.Parameters.AddWithValue("@dorduncu", DateTime.Now.AddDays(BilinenSorununSorulmaSikligi[3]));
            Veritabani.Komut.Parameters.AddWithValue("@besinci", DateTime.Now.AddDays(BilinenSorununSorulmaSikligi[4]));
            Veritabani.Komut.Parameters.AddWithValue("@altinci", DateTime.Now.AddDays(BilinenSorununSorulmaSikligi[5]));
        }

        public override void BugunSorulacakSorulariVeritabanindanCek()
        {
            BugunSorulacakSigmaSorulariniCek();
            SigmaListesindeOlmayan10SoruCek();
        }
        private void BugunSorulacakSigmaSorulariniCek()
        {
            List<string> sutunIsimleri = new List<string> { "FirstTime", "SecondTime", "ThirdTime", "FourthTime", "FifthTime", "SixthTime" };
            for (int i = 0; i < sutunIsimleri.Count; i++) // dbo.SigmaQuestions tablosundaki tüm tarih sutunları sırayla taranıyor
            {
                Veritabani.BaglantiYoksaYeniBaglantiAc();

                Veritabani.Komut.Parameters.Clear();

                Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.SigmaDates WHERE " +
                    "DATENAME(YEAR, " + sutunIsimleri[i] + ") = DATENAME(YEAR, GETDATE()) AND " +
                    "DATENAME(MONTH, " + sutunIsimleri[i] + ") = DATENAME(MONTH, GETDATE()) AND " +
                    "DATENAME(DAY, " + sutunIsimleri[i] + ") = DATENAME(DAY, GETDATE())";

                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader(); // bugun sorulması planlanan bir soru varsa bugunSorulacakSorular listesine ekleniyor
                while (Veritabani.VeriOkuyucu.Read() && !bugunSorulacakSorularinIDleri.Contains(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"])))
                {
                    bugunSorulacakSorularinIDleri.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                }
                Veritabani.VeriOkuyucu.Close();
            }
            Veritabani.BaglantiyiKes();
        }

        private void SigmaListesindeOlmayan10SoruCek()
        {
            // Soru havuzundan sigma tablosunda olmayan 10 soru rastgele secilip bugunSorulacakSorular listesine ekleniyor
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.Questions WHERE QuestionStatus = '" + 1 + "' ORDER BY NEWID()";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            int sayac=0;
            while (Veritabani.VeriOkuyucu.Read())
            {
                if (!bugunSorulacakSorularinIDleri.Contains(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"])) && sayac < 10)
                {
                    bugunSorulacakSorularinIDleri.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                    sayac++;
                }               
            }
            Veritabani.BaglantiyiKes();
        }

        public void SigmaSorularininSorulmaSikliklariniCek()
        {
            BilinenSorununSorulmaSikligi.Clear();
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "SELECT First, Second, Third, Fourth, Fifth, Sixth FROM UsersSigmaFrequency WHERE UserID='" + KullaniciID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (Veritabani.VeriOkuyucu.Read()) // Ogrencinin ID'si ile veritabanından sigma algoritması için mevcut soru çıkma sıklığını öğreniyoruz.
            {
                if (BilinenSorununSorulmaSikligi.Count != 0)
                {
                    BilinenSorununSorulmaSikligi.Clear();
                }
                BilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["First"]));
                BilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Second"]));
                BilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Third"]));
                BilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Fourth"]));
                BilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Fifth"]));
                BilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Sixth"]));
            }
            Veritabani.BaglantiyiKes();
        }

        public void SoruCikmaSikliginiDegistir(List<int> yeniSorulmaSikligi)
        {
            // Ayarlar ekranından soru çıkma sıklığı değiştirilmişse KullanıcıID ile yeni sıklığı veritabanında güncelliyoruz.
            if (yeniSorulmaSikligi.Count != 0)
            {
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "UPDATE dbo.UsersSigmaFrequency SET First = '" + yeniSorulmaSikligi[0] +
                    "' ,Second = '" + yeniSorulmaSikligi[1] + "' ,Third = '" + yeniSorulmaSikligi[2] + "' ,Fourth = '"+ yeniSorulmaSikligi[3] +
                    "' ,Fifth = '" + yeniSorulmaSikligi[4] + "', Sixth = '" + yeniSorulmaSikligi[5] + "' WHERE UserID ='" + KullaniciID + "'";
            Veritabani.Komut.ExecuteNonQuery();
            Veritabani.BaglantiyiKes();
            }
        }
    }
}
