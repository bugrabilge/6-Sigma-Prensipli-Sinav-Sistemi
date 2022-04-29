using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class LoginHareketleri
    {
        public veriTabaniBaglanti Veritabani { get; set; }
        public LoginHareketleri()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            this.Veritabani = vt;
        }
    }
}
