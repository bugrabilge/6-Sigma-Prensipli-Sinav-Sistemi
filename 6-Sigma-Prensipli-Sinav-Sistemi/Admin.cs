using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Admin
    {
        private veriTabaniBaglanti Veritabani { get; set; }

        public Soru KontrolEdilecekSoru { get; set; }

        public bool siradaSoruVarMi;

        public Admin()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            Soru soru = new Soru();
            this.Veritabani = vt;
            this.KontrolEdilecekSoru = soru;
        }

        public void siradakiSoru()
        {
            Veritabani.kontrolEtVeYeniBaglantiAc();
            siradaSoruVarMi = false;
            Veritabani.Komut.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionStatus = 0 ORDER BY NEWID()";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();

            while (Veritabani.VeriOkuyucu.Read())
            {
                KontrolEdilecekSoru.secenekleriVeBilgileriAta(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                siradaSoruVarMi = true;
            }

            Veritabani.baglantiyiKes();

            if (!siradaSoruVarMi)
            {
                MessageBox.Show("Onay Bekleyen Soru Bulunmamaktadır.\nÇıkış Yapabilirsiniz.");
            }
        }

        public void soruyuOnayla()
        {
            Veritabani.kontrolEtVeYeniBaglantiAc();
            Veritabani.Komut.CommandText = "UPDATE dbo.Questions SET QuestionStatus = 1 WHERE QuestionID ='" + KontrolEdilecekSoru.ID + "'";
            Veritabani.Komut.ExecuteNonQuery();
            MessageBox.Show("Soru, soru havuzuna eklenmiştir.");
            Veritabani.baglantiyiKes();
            siradakiSoru();
        }

        public void soruyuReddet()
        {
            Veritabani.kontrolEtVeYeniBaglantiAc();
            Veritabani.Komut.CommandText = "DELETE FROM dbo.Questions WHERE QuestionID ='" + KontrolEdilecekSoru.ID + "'";
            Veritabani.Komut.ExecuteNonQuery();
            MessageBox.Show("Soru silinmiştir.");
            Veritabani.baglantiyiKes();
            siradakiSoru();
        }
    }
}
