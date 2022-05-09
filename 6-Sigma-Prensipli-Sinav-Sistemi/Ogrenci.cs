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
        public List<string> DogruCozulenKonular { get; set; }
        public List<string> YanlisCozulenKonular { get; set; }
        public List<int> SigmaSorulmaSikliklari { get; set; }
        public Sigma SigmaTestiIslemleri { get; set; }
        public Hazirlik HazirlikTestiIslemleri { get; set; }

        public Ogrenci()
        {
            DogruCozulenKonular = new List<string>();
            YanlisCozulenKonular = new List<string>();
            SigmaTestiIslemleri = new Sigma();
            HazirlikTestiIslemleri = new Hazirlik();
        }
    }
}
