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
        private SqlConnection baglanti;
        private SqlCommand komut;
        private SqlDataReader veriOkuyucu;
        
        public SqlConnection Baglanti
        {
            get { return baglanti; }
            set { baglanti = value; }
        }


        public SqlCommand Komut
        {
            get { return komut; }
            set { komut = value; }
        }

        public SqlDataReader VeriOkuyucu
        {
            get { return veriOkuyucu; }
            set { veriOkuyucu = value; }
        }  

        public veriTabaniBaglanti()
        {
            this.baglanti = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            this.komut = new SqlCommand();
            baglanti.Open();
            this.komut.Connection = baglanti;
        }

        public void baglantiyiKes()
        {
            baglanti.Close();
        }

        public void kontrolEtVeYeniBaglantiAc()
        {
            if (Baglanti != null && Baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                this.komut.Connection = baglanti;
            }
            
        }
    }
}
