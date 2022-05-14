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
        public static int GirisYapanKullaniciID { get; set; }
        public static string GirisYapanKullaniciAd { get; set; }
        public static string GirisYapanKullaniciSoyad { get; set; }
        
        public void KullaniciAdiKontrolVeGiris(string kullaniciAdi, string sifre, Form kapatilacakFormIsmi)
        {
            if (kullaniciAdi != "" && sifre != "")
            {
                Veritabani.Komut.CommandText = "SELECT UserName FROM dbo.Users where UserName='" + kullaniciAdi + "'";
                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
                if (Veritabani.VeriOkuyucu.Read()) // Kullanici adinin bulunup bulunmadigina bakiyoruz, bulunuyorsa sifre kontrolu yapıp giris yapıyoruz
                {
                    Veritabani.VeriOkuyucu.Close();
                    GirisYap(kullaniciAdi, sifre, kapatilacakFormIsmi);
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


        public void GirisYap(string kullaniciAdi, string sifre, Form kapatilacakFormIsmi)
        {
            
            Veritabani.Komut.CommandText = "SELECT UserName, Password, UserTypeID, UserID, Name, Surname FROM dbo.Users where UserName='" + kullaniciAdi + "' AND Password='" + sifre + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (Veritabani.VeriOkuyucu.Read()) // Kullanici adi ve sifre veritabani ile eslesiyorsa, kullanici türüne gore sayfasina yonlendiriyoruz
            {
                MessageBox.Show("Giriş Başarılı!\nYönlendiriliyorsunuz.");

                switch (Veritabani.VeriOkuyucu["UserTypeID"])
                {
                    case 1: // ogrenci girisi
                        AdSoyadVeIDBilgileriniAta();
                        Veritabani.BaglantiyiKes();
                        formGecis.FormlarArasıGecisYap(kapatilacakFormIsmi, "ogrenciForm");
                        break;
                    case 2: // sinav sorumlusu girisi
                        AdSoyadVeIDBilgileriniAta();
                        Veritabani.BaglantiyiKes();
                        formGecis.FormlarArasıGecisYap(kapatilacakFormIsmi, "sSorumluForm");
                        break;
                    case 3: // admin girisi
                        AdSoyadVeIDBilgileriniAta();
                        Veritabani.BaglantiyiKes();
                        formGecis.FormlarArasıGecisYap(kapatilacakFormIsmi, "adminForm");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Veritabani.BaglantiyiKes();
                MessageBox.Show("Hatalı şifre girdiniz. Lütfen tekrar deneyiniz.");
            }
        }

        private void AdSoyadVeIDBilgileriniAta()
        {
            GirisYapanKullaniciID = Convert.ToInt32(Veritabani.VeriOkuyucu["UserID"]);
            GirisYapanKullaniciAd = Veritabani.VeriOkuyucu["Name"].ToString();
            GirisYapanKullaniciSoyad = Veritabani.VeriOkuyucu["Surname"].ToString();
        }
    }
}
