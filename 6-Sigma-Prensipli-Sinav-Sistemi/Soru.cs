using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class Soru
    {
        public int ID { get; set; }
        public string Govde { get; set; }
        public string DogruCevap { get; set; }
        public string YanlisCevap1 { get; set; }
        public string YanlisCevap2 { get; set; }
        public string YanlisCevap3 { get; set; }
        public string YanlisCevap4 { get; set; }

        private veriTabaniBaglanti Veritabani;

        public int SectionID { get; set; }
        public int UnitID { get; set; }

        public int KabulDurumu { get; set; }

        public int DogruYapilmaSayisi { get; set; }

        public Soru()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            this.Veritabani = vt;
        }

        public string ResimYolu { get; set; }
        public int ResimYuksekligi { get; set; }
        public int ResimGenisligi { get; set; }
        public bool siradaSoruVarMi;
        public GroupBox Grup { get; set; }
        
        
        public void SiradakiSoruBilgileriniCekVeAta(int questionStatus) 
        {
            /* QuestionStatus = 0 -> Henuz admin tarafindan onaylanmamis sorular
            * QuestionStatus = 1 -> Admin tarafindan onaylanip soru havuzuna eklenmis sorular
            * QuestionStatus = 2 -> 6 kez üst üste bilinip test havuzundan cikarilmis sorular
            */
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            siradaSoruVarMi = false;
            Veritabani.Komut.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionStatus = '" + questionStatus + "' ORDER BY NEWID()";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();

            if (Veritabani.VeriOkuyucu.Read()) // veritabanından istenen question statuse rastgele bir soru çekiyoruz
            {
                SecenekleriVeBilgileriAta(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                siradaSoruVarMi = true;
            }

            Veritabani.BaglantiyiKes();

        }

        public void SecenekleriVeBilgileriAta(int id)
        {           
            this.ID = id;
            Veritabani.BaglantiyiKes();
            Veritabani.BaglantiYoksaYeniBaglantiAc();
            Veritabani.Komut.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionID = '" + this.ID + "'";
            
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();
            // soru id'si ile mevcut sorunun bilgilerini testlerde kullanılmak üzere soru nesnesinin alanlarına atıyoruz
            while (Veritabani.VeriOkuyucu.Read())
            {                
                this.Govde = Veritabani.VeriOkuyucu["QuestionText"].ToString();
                this.DogruCevap = Veritabani.VeriOkuyucu["RightAnswer"].ToString();
                this.YanlisCevap1 = Veritabani.VeriOkuyucu["WrongAnswer1"].ToString();
                this.YanlisCevap2 = Veritabani.VeriOkuyucu["WrongAnswer2"].ToString();
                this.YanlisCevap3 = Veritabani.VeriOkuyucu["WrongAnswer3"].ToString();
                this.YanlisCevap4 = Veritabani.VeriOkuyucu["WrongAnswer4"].ToString();
                this.SectionID = Convert.ToInt32(Veritabani.VeriOkuyucu["SectionID"]);
                this.UnitID = Convert.ToInt32(Veritabani.VeriOkuyucu["UnitID"]);
                this.KabulDurumu = Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionStatus"]);

                if (Veritabani.VeriOkuyucu["PicturePath"] != DBNull.Value)
                {
                    ResimYolu = Veritabani.VeriOkuyucu["PicturePath"].ToString();
                    ResimYuksekligi = Convert.ToInt32(Veritabani.VeriOkuyucu["PictureHeight"]);
                    ResimGenisligi = Convert.ToInt32(Veritabani.VeriOkuyucu["PictureWidth"]);
                }
                else
                {
                    ResimYolu = null;
                    ResimYuksekligi = 0;
                    ResimGenisligi = 0;
                }
                break;
            }
            Veritabani.BaglantiyiKes();
        }
    }
}
