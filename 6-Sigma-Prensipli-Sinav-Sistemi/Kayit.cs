﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Kayit : LoginHareketleri
    {
        public string KayitOlanKullaniciAdi { get; set; }
        public string KayitOlanSifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string GuvenlikSorusuCevabi { get; set; }
        public int KullaniciTuru { get; set; }

        public void verileriVeritabaninaKayitEt() // Kayit ekraninda girilen veriler veritabanina ekleniyor
        {
            Veritabani.Komut.CommandText = "insert into dbo.Users(UserName, Name, Surname, Mail, Password, SecurityAnswer, UserTypeID) " +
                                            "values('" + KayitOlanKullaniciAdi + "','" +
                                                         Ad + "','" +
                                                         Soyad + "','" +
                                                         Mail + "','" +
                                                         KayitOlanSifre + "','" +
                                                         GuvenlikSorusuCevabi + "','" +
                                                         KullaniciTuru + "')";
            Veritabani.Komut.ExecuteNonQuery();
            Veritabani.baglantiyiKes();
            MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşmiştir!");
        }

    }
}
