using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Kayit
    {
        private string kayitOlanKullaniciAdi;

        private string kayitOlanSifre;
        
        private string ad;
        
        private string soyad;
        
        private string mail;
        
        private string guvenlikSorusuCevabi;
        
        private int kullaniciTuru;
        
        private veriTabaniBaglanti veriTabani;
        
        public string KayitOlanKullaniciAdi
        {
            get { return kayitOlanKullaniciAdi; }
            set { kayitOlanKullaniciAdi = value; }
        }


        public string KayitOlanSifre
        {
            get { return kayitOlanSifre; }
            set { kayitOlanSifre = value; }
        }


        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }


        public string Soyad
        {
            get { return soyad; }
            set { soyad = value; }
        }


        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }


        public string GuvenlikSorusuCevabi
        {
            get { return guvenlikSorusuCevabi; }
            set { guvenlikSorusuCevabi = value; }
        }


        public int KullaniciTuru
        {
            get { return kullaniciTuru; }
            set { kullaniciTuru = value; }
        }


        public veriTabaniBaglanti VeriTabani
        {
            get { return veriTabani; }
            set { veriTabani = value; }
        }


        public Kayit()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            this.VeriTabani = vt;
        }

        public void verileriVeritabaninaKayitEt()
        {
            VeriTabani.Komut.CommandText = "insert into dbo.Users(UserName, Name, Surname, Mail, Password, SecurityAnswer, UserTypeID) " +
                                            "values('" + KayitOlanKullaniciAdi + "','" +
                                                         Ad + "','" +
                                                         Soyad + "','" +
                                                         Mail + "','" +
                                                         KayitOlanSifre + "','" +
                                                         GuvenlikSorusuCevabi + "','" +
                                                         KullaniciTuru + "')";
            VeriTabani.Komut.ExecuteNonQuery();
            VeriTabani.baglantiyiKes();
            MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşmiştir!");
        }

    }
}
