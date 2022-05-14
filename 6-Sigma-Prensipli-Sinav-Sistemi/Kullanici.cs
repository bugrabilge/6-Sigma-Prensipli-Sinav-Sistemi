using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Kullanici
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public veriTabaniBaglanti Veritabani { get; set; }
        public Soru IslemYapilacakSoru { get; set; }
        public Kullanici()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            this.Veritabani = vt;
            Soru soru = new Soru();
            this.IslemYapilacakSoru = soru;
            this.ID = Giris.GirisYapanKullaniciID;
            this.Ad = Giris.GirisYapanKullaniciAd;
            this.Soyad = Giris.GirisYapanKullaniciSoyad;
        }
    }
}
