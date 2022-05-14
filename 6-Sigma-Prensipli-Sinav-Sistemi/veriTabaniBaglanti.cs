using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class veriTabaniBaglanti
    {
        public SqlConnection Baglanti { get; set; }
        public SqlCommand Komut { get; set; }
        public SqlDataReader VeriOkuyucu { get; set; }

        public veriTabaniBaglanti()
        {
            this.Baglanti = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            this.Komut = new SqlCommand();
            Baglanti.Open();
            this.Komut.Connection = Baglanti;           
        }

        public void BaglantiyiKes()
        {
            Baglanti.Close();
        }

        public void BaglantiYoksaYeniBaglantiAc()
        {
            if (Baglanti != null && Baglanti.State == ConnectionState.Closed)
            {
                Baglanti.Open();
                this.Komut.Connection = Baglanti;
            }   
        }
    }
}
