using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Giris
    {
        private veriTabaniBaglanti veritabani;


        public veriTabaniBaglanti Veritabani
        {
            get { return veritabani; }
            set { veritabani = value; }
        }
        public int girisYapanKullaniciID { get; set; }


        public Giris()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            veritabani = vt;
        }
        
        public void kullaniciAdiKontrolVeGiris(string kullaniciAdi, string sifre, Form kapatilacakFormIsmi)
        {
            if (kullaniciAdi != "" && sifre != "")
            {
                Veritabani.Komut.CommandText = "SELECT UserName FROM dbo.Users where UserName='" + kullaniciAdi + "'";
                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
                if (Veritabani.VeriOkuyucu.Read())
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
            
            Veritabani.Komut.CommandText = "SELECT UserName, Password, UserTypeID, UserID FROM dbo.Users where UserName='" + kullaniciAdi + "' AND Password='" + sifre + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            if (Veritabani.VeriOkuyucu.Read())
            {
                MessageBox.Show("Giriş Başarılı!\nYönlendiriliyorsunuz.");

                switch (Veritabani.VeriOkuyucu["UserTypeID"])
                {
                    case 1: // ogrenci girisi
                        girisYapanKullaniciID = Convert.ToInt32(Veritabani.VeriOkuyucu["UserID"]);
                        Veritabani.baglantiyiKes();
                        formGecis.formlarArasıGecisYap(kapatilacakFormIsmi, "ogrenciForm");
                        break;
                    case 2: // sinav sorumlusu girisi
                        girisYapanKullaniciID = Convert.ToInt32(Veritabani.VeriOkuyucu["UserID"]);
                        Veritabani.baglantiyiKes();
                        formGecis.formlarArasıGecisYap(kapatilacakFormIsmi, "sSorumluForm");
                        break;
                    case 3: // admin girisi
                        girisYapanKullaniciID = Convert.ToInt32(Veritabani.VeriOkuyucu["UserID"]);
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
    }
}
