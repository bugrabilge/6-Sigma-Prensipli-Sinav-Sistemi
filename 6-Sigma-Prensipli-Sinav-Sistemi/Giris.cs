using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Giris : LoginHareketleri
    {
        public static int girisYapanKullaniciID { get; set; }
        public static string girisYapanKullaniciAd { get; set; }
        public static string girisYapanKullaniciSoyad { get; set; }
        
        public void kullaniciAdiKontrolVeGiris(string kullaniciAdi, string sifre, Form kapatilacakFormIsmi)
        {
            if (kullaniciAdi != "" && sifre != "")
            {
                Veritabani.Komut.CommandText = "SELECT UserName FROM dbo.Users where UserName='" + kullaniciAdi + "'";
                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
                if (Veritabani.VeriOkuyucu.Read()) // Kullanici adinin bulunup bulunmadigina bakiyoruz, bulunuyorsa sifre kontrolu yapıp giris yapıyoruz
                {
                    Veritabani.VeriOkuyucu.Close();
                    girisYap(kullaniciAdi, sifre, kapatilacakFormIsmi);
                }
                else
                {
                    MessageBox.Show("Girilen kullanıcı adı bulunamamıştır.\nLütfen tekrar deneyiniz.\nKaydınız bulunmuyor ise Kayıt Ol butonu ile kayıt olabilirsiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
        }


        public void girisYap(string kullaniciAdi, string sifre, Form kapatilacakFormIsmi)
        {
            
            Veritabani.Komut.CommandText = "SELECT UserName, Password, UserTypeID, UserID, Name, Surname FROM dbo.Users where UserName='" + kullaniciAdi + "' AND Password='" + sifre + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (Veritabani.VeriOkuyucu.Read()) // Kullanici adi ve sifre veritabani ile eslesiyorsa, kullanici türüne gore sayfasina yonlendiriyoruz
            {
                MessageBox.Show("Giriş Başarılı!\nYönlendiriliyorsunuz.");

                switch (Veritabani.VeriOkuyucu["UserTypeID"])
                {
                    case 1: // ogrenci girisi
                        adSoyadVeIDBilgileriniAta();
                        Veritabani.baglantiyiKes();
                        formGecis.formlarArasıGecisYap(kapatilacakFormIsmi, "ogrenciForm");
                        break;
                    case 2: // sinav sorumlusu girisi
                        adSoyadVeIDBilgileriniAta();
                        Veritabani.baglantiyiKes();
                        formGecis.formlarArasıGecisYap(kapatilacakFormIsmi, "sSorumluForm");
                        break;
                    case 3: // admin girisi
                        adSoyadVeIDBilgileriniAta();
                        Veritabani.baglantiyiKes();
                        formGecis.formlarArasıGecisYap(kapatilacakFormIsmi, "adminForm");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Veritabani.baglantiyiKes();
                MessageBox.Show("Hatalı şifre girdiniz. Lütfen tekrar deneyiniz.");
            }
        }

        private void adSoyadVeIDBilgileriniAta()
        {
            girisYapanKullaniciID = Convert.ToInt32(Veritabani.VeriOkuyucu["UserID"]);
            girisYapanKullaniciAd = Veritabani.VeriOkuyucu["Name"].ToString();
            girisYapanKullaniciSoyad = Veritabani.VeriOkuyucu["Surname"].ToString();
        }
    }
}
