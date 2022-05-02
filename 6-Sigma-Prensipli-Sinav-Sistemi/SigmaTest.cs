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
    public class SigmaTest : TestIslemleri
    {
        public List<int> bugunSorulacakSorular { get; set; }
        public List<int> bilinenSorununSorulmaSikligi { get; set; }

        public SigmaTest()
        {
            //this.soru = ogrencininSorusu;
            bugunSorulacakSorular = new List<int>();
            bilinenSorununSorulmaSikligi = new List<int>();
            sigmaSorularininSorulmaSikliklariniCek();
        }

        public void sigmaCevabaGoreVeritabaniIslemleriniYap(Soru soru, Label secenek)
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

        private void soruyuSigmaTablosunaEkle(int soruID)
        {
            // Sorunun sonraki sorulacagi 6 tarih veritabanina ekleniyor
            Veritabani.Komut.CommandText = "insert into dbo.SigmaDates (QuestionID, FirstTime, SecondTime, ThirdTime, FourthTime, FifthTime, SixthTime) " +
                "values (@soruID, @ilk, @ikinci, @ucuncu, @dorduncu, @besinci, @altinci)";
            Veritabani.Komut.Parameters.AddWithValue("@soruID", soruID);
            /*
            Veritabani.Komut.Parameters.AddWithValue("@ilk", DateTime.Now.AddDays(1));
            Veritabani.Komut.Parameters.AddWithValue("@ikinci", DateTime.Now.AddDays(7));
            Veritabani.Komut.Parameters.AddWithValue("@ucuncu", DateTime.Now.AddMonths(1));
            Veritabani.Komut.Parameters.AddWithValue("@dorduncu", DateTime.Now.AddMonths(3));
            Veritabani.Komut.Parameters.AddWithValue("@besinci", DateTime.Now.AddMonths(6));
            Veritabani.Komut.Parameters.AddWithValue("@altinci", DateTime.Now.AddYears(1));
            */

            Veritabani.Komut.Parameters.AddWithValue("@ilk", DateTime.Now.AddDays(bilinenSorununSorulmaSikligi[0]));
            Veritabani.Komut.Parameters.AddWithValue("@ikinci", DateTime.Now.AddDays(bilinenSorununSorulmaSikligi[1]));
            Veritabani.Komut.Parameters.AddWithValue("@ucuncu", DateTime.Now.AddDays(bilinenSorununSorulmaSikligi[2]));
            Veritabani.Komut.Parameters.AddWithValue("@dorduncu", DateTime.Now.AddDays(bilinenSorununSorulmaSikligi[3]));
            Veritabani.Komut.Parameters.AddWithValue("@besinci", DateTime.Now.AddDays(bilinenSorununSorulmaSikligi[4]));
            Veritabani.Komut.Parameters.AddWithValue("@altinci", DateTime.Now.AddDays(bilinenSorununSorulmaSikligi[5]));
        }

        public void bugunSorulacakSorulariCek()
        {
            bugunSorulacakSigmaSorulariniCek();
            sigmaListesindeOlmayan10SoruCek();
        }
        private void bugunSorulacakSigmaSorulariniCek()
        {
            List<string> sutunIsimleri = new List<string> { "FirstTime", "SecondTime", "ThirdTime", "FourthTime", "FifthTime", "SixthTime" };
            for (int i = 0; i < sutunIsimleri.Count; i++) // dbo.SigmaQuestions tablosundaki tüm tarih sutunları sırayla taranıyor
            {
                Veritabani.baglantiYoksaYeniBaglantiAc();

                Veritabani.Komut.Parameters.Clear();

                Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.SigmaDates WHERE " +
                    "DATENAME(YEAR, " + sutunIsimleri[i] + ") = DATENAME(YEAR, GETDATE()) AND " +
                    "DATENAME(MONTH, " + sutunIsimleri[i] + ") = DATENAME(MONTH, GETDATE()) AND " +
                    "DATENAME(DAY, " + sutunIsimleri[i] + ") = DATENAME(DAY, GETDATE())";

                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader(); // bugun sorulması planlanan bir soru varsa bugunSorulacakSorular listesine ekleniyor
                while (Veritabani.VeriOkuyucu.Read() && !bugunSorulacakSorular.Contains(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"])))
                {
                    bugunSorulacakSorular.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                }
                Veritabani.VeriOkuyucu.Close();
            }
            Veritabani.baglantiyiKes();
        }

        private void sigmaListesindeOlmayan10SoruCek()
        {
            // Soru havuzundan sigma tablosunda olmayan 10 soru rastgele secilip bugunSorulacakSorular listesine ekleniyor
            Veritabani.baglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "SELECT QuestionID FROM dbo.Questions WHERE QuestionStatus = '" + 1 + "' ORDER BY NEWID()";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            int sayac=0;
            while (Veritabani.VeriOkuyucu.Read())
            {
                if (!bugunSorulacakSorular.Contains(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"])) && sayac < 10)
                {
                    bugunSorulacakSorular.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                    sayac++;
                }               
            }
            Veritabani.baglantiyiKes();
        }

        public void sigmaSorularininSorulmaSikliklariniCek()
        {
            bilinenSorununSorulmaSikligi.Clear();
            Veritabani.baglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "SELECT First, Second, Third, Fourth, Fifth, Sixth FROM UsersSigmaFrequency WHERE UserID='" + KullaniciID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (Veritabani.VeriOkuyucu.Read())
            {
                if (bilinenSorununSorulmaSikligi.Count != 0)
                {
                    bilinenSorununSorulmaSikligi.Clear();
                }
                bilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["First"]));
                bilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Second"]));
                bilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Third"]));
                bilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Fourth"]));
                bilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Fifth"]));
                bilinenSorununSorulmaSikligi.Add(Convert.ToInt32(Veritabani.VeriOkuyucu["Sixth"]));
            }
            Veritabani.baglantiyiKes();
        }

        public void soruCikmaSikliginiDegistir(List<int> yeniSorulmaSikligi)
        {
            Veritabani.baglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "UPDATE dbo.UsersSigmaFrequency SET First = '" + yeniSorulmaSikligi[0] + "' ,Second = '" + yeniSorulmaSikligi[1] + "' ,Third = '" + yeniSorulmaSikligi[2] + "' ,Fourth = '"+ yeniSorulmaSikligi[3] + "' ,Fifth = '" + yeniSorulmaSikligi[4] + "', Sixth = '" + yeniSorulmaSikligi[5] + "' WHERE UserID ='" + KullaniciID + "'";
            Veritabani.Komut.ExecuteNonQuery();
            Veritabani.baglantiyiKes();
        }
    }
}
