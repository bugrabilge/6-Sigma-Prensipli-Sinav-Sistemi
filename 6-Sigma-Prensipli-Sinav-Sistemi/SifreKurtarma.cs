using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class SifreKurtarma : LoginHareketleri
    {
        public void cevaplariKontrolEtVeSonucVer(string girilenKullaniciAdi, string girilenCevap, Form kapatilacakForm)
        {
            
            if (girilenKullaniciAdi != "" && girilenCevap != "")
            {
                Veritabani.baglantiYoksaYeniBaglantiAc();
                string sifre;
                Veritabani.Komut.CommandText = "SELECT UserName, Password, SecurityAnswer FROM dbo.Users where UserName='" + girilenKullaniciAdi + "' AND SecurityAnswer='" + girilenCevap + "'";
                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
                if (Veritabani.VeriOkuyucu.Read())
                {
                    sifre = Veritabani.VeriOkuyucu["Password"].ToString();
                    MessageBox.Show("Cevabınız doğru! Şifreniz : " + sifre + "\nGiriş yapabilirsiniz.");
                    formGecis.formlarArasıGecisYap(kapatilacakForm, "girisForm");
                }
                else
                {
                    MessageBox.Show("Girilen Kullanıcı adı veya girilen cevap yanlıştır.\nLütfen tekrar deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            Veritabani.baglantiyiKes();
        }
    }
}
