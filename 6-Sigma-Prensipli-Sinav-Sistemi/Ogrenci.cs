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
        public int TestteCozecegiSoruSayisi { get; set; }
        public List<int> TestteCozecegiSorularinIDleri { get; set; }
        public List<int> SigmaSorulmaSikliklari { get; set; }

        public Ogrenci()
        {
            TestteCozecegiSorularinIDleri = new List<int>();
        }

        public void cozulecekSorularinIDleriniCek(List<int> sigmaSorulari)
        {
            if (sigmaSorulari.Count>0)
            {
                TestteCozecegiSorularinIDleri.AddRange(sigmaSorulari);
            }
            TestteCozecegiSoruSayisi = TestteCozecegiSorularinIDleri.Count;
        }

        

        public void sigmaSorularininSorulmaSikliklariniDegistir()
        {

        }
    }
}
