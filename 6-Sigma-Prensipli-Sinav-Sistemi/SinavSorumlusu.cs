using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class SinavSorumlusu : Kullanici
    {
        public void ResimYukle(PictureBox box, Button arttir, Button azalt)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png";
            dosya.Title = "Eklemek istediğiniz resmi seçiniz.";
            dosya.ShowDialog();
            string dosyaYolu = dosya.FileName;
            box.ImageLocation = dosyaYolu;
            _ = (box.ImageLocation == null) ? arttir.Visible = azalt.Visible = false : arttir.Visible = azalt.Visible = true;
        }

        public void ResimGenislikDegistir(string islem, PictureBox box)
        {
            Size boyut = box.Size;
            _ = (islem == "+") ? boyut.Width += 5 : boyut.Width -= 5;
            box.Size = boyut;
        }

        public void ResimYukseklikDegistir(string islem, PictureBox box)
        {
            Size boyut = box.Size;
            _ = (islem == "+") ? boyut.Height += 5 : boyut.Height -= 5;
            box.Size = boyut;
        }

        public void SoruVerileriniVeritabanınaIsle() // eklenen soru verileri veritabanına aktarılıyor
        {
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "insert into dbo.Questions (QuestionText, SectionID, UnitID, PicturePath, PictureWidth, PictureHeight, RightAnswer, " +
                "WrongAnswer1, WrongAnswer2, WrongAnswer3, WrongAnswer4,QuestionStatus) " +
                "values (@soruText, @konuID, @uniteID, @resimYolu, @resimGenisligi, @resimYuksekligi, @dogruCevap," +
                "@yanlisCevap1, @yanlisCevap2, @yanlisCevap3, @yanlisCevap4, @soruDurumu )";
            Veritabani.Komut.Parameters.AddWithValue("@soruText", IslemYapilacakSoru.Govde);
            Veritabani.Komut.Parameters.AddWithValue("@konuID", IslemYapilacakSoru.SectionID);
            Veritabani.Komut.Parameters.AddWithValue("@uniteID", IslemYapilacakSoru.UnitID);
            if (IslemYapilacakSoru.ResimYolu != null)
            {
                Veritabani.Komut.Parameters.AddWithValue("@resimYolu", IslemYapilacakSoru.ResimYolu);
                Veritabani.Komut.Parameters.AddWithValue("@resimGenisligi", IslemYapilacakSoru.ResimGenisligi);
                Veritabani.Komut.Parameters.AddWithValue("@resimYuksekligi", IslemYapilacakSoru.ResimYuksekligi);
            }
            else
            {
                Veritabani.Komut.Parameters.AddWithValue("@resimYolu", DBNull.Value);
                Veritabani.Komut.Parameters.AddWithValue("@resimGenisligi", DBNull.Value);
                Veritabani.Komut.Parameters.AddWithValue("@resimYuksekligi", DBNull.Value);
            }
            Veritabani.Komut.Parameters.AddWithValue("@dogruCevap", IslemYapilacakSoru.DogruCevap);
            Veritabani.Komut.Parameters.AddWithValue("@yanlisCevap1", IslemYapilacakSoru.YanlisCevap1);
            Veritabani.Komut.Parameters.AddWithValue("@yanlisCevap2", IslemYapilacakSoru.YanlisCevap2);
            Veritabani.Komut.Parameters.AddWithValue("@yanlisCevap3", IslemYapilacakSoru.YanlisCevap3);
            Veritabani.Komut.Parameters.AddWithValue("@yanlisCevap4", IslemYapilacakSoru.YanlisCevap4);
            Veritabani.Komut.Parameters.AddWithValue("@soruDurumu", 0);
            Veritabani.Komut.ExecuteNonQuery();
            Veritabani.BaglantiyiKes();
        }

        public void UniteVeyaKonuIsmiCek(string islemYapilacakTur, string gelenID, Label isimYazdirilacakLabel, Label uniteLabel)
        {
            if (gelenID != "")
            {
                int aranacakID = Convert.ToInt32(gelenID);
                Veritabani.BaglantiYoksaYeniBaglantiAc();
                
                if (islemYapilacakTur == "Unit") // ünite ismi ya da konu ismi aramamıza göre CommandText atamamızı değiştiriyoruz sadece
                {
                    Veritabani.Komut.CommandText = "SELECT UnitName FROM dbo.UnitsAndSections WHERE UnitID = '" + aranacakID + "'";
                }
                else
                {
                    Veritabani.Komut.CommandText = "SELECT SectionName FROM dbo.UnitsAndSections WHERE UnitName = '"+ uniteLabel.Text +"' AND SectionID = '"+ aranacakID +"'";
                }

                Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
                if (Veritabani.VeriOkuyucu.Read())
                {
                    isimYazdirilacakLabel.Text = Veritabani.VeriOkuyucu["" + islemYapilacakTur + "Name"].ToString();
                    isimYazdirilacakLabel.Visible = true;
                }
                Veritabani.BaglantiyiKes();
            }
            else
            {
                isimYazdirilacakLabel.Visible = false;
            }
        }
    }
}
