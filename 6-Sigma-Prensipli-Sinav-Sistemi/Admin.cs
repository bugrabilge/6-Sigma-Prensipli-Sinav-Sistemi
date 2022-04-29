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
    public class Admin : Kullanici
    {
        public void soruyuOnayla()
        {
            Veritabani.baglantiYoksaYeniBaglantiAc();
            // Soru admin tarafindan onaylanirsa, QuestionStatus'u 1 yapıyoruz ve testlerde kullanilabilir hale geliyor
            Veritabani.Komut.CommandText = "UPDATE dbo.Questions SET QuestionStatus = 1 WHERE QuestionID ='" + IslemYapilacakSoru.ID + "'";
            Veritabani.Komut.ExecuteNonQuery();
            MessageBox.Show("Soru, soru havuzuna eklenmiştir.");
            Veritabani.baglantiyiKes();
            IslemYapilacakSoru.siradakiSoruBilgileriniCekVeAta(0);
        }

        public void soruyuReddet()
        {
            Veritabani.baglantiYoksaYeniBaglantiAc();
            // Soru admin tarafindan reddedilirse veritabanindan siliniyor.
            Veritabani.Komut.CommandText = "DELETE FROM dbo.Questions WHERE QuestionID ='" + IslemYapilacakSoru.ID + "'";
            Veritabani.Komut.ExecuteNonQuery();
            MessageBox.Show("Soru silinmiştir.");
            Veritabani.baglantiyiKes();
            IslemYapilacakSoru.siradakiSoruBilgileriniCekVeAta(0);
        }
    }
}
