using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Ogrenci : Kullanici
    {
        public int DogruSayisi { get; set; }
        public int YanlisSayisi { get; set; }
        //public int TestteCozecegiSoruSayisi { get; set; }
        //public List<int> TestteCozecegiSorularinIDleri { get; set; }
        public List<int> DogruCozduguSorularinIDleri { get; set; }
        public List<int> YanlisCozduguSorularinIDleri { get; set; }
        public List<int> SigmaSorulmaSikliklari { get; set; }
        public Sigma SigmaTestiIslemleri { get; set; }
        public Hazirlik HazirlikTestiIslemleri { get; set; }

        public Ogrenci()
        {
            //TestteCozecegiSorularinIDleri = new List<int>();
            DogruCozduguSorularinIDleri = new List<int>();
            YanlisCozduguSorularinIDleri = new List<int>();
            SigmaTestiIslemleri = new Sigma();
            HazirlikTestiIslemleri = new Hazirlik();
        }
        /*
        public void cozulecekSorularinIDleriniCek()
        {
            TestIslemleri.bugunSorulacakSorulariVeritabanindanCek();
            if (TestIslemleri.bugunSorulacakSorularinIDleri.Count>0)
            {
                TestteCozecegiSorularinIDleri.AddRange(TestIslemleri.bugunSorulacakSorularinIDleri);
            }
            TestteCozecegiSoruSayisi = TestteCozecegiSorularinIDleri.Count;
        }
        */
    }
}
