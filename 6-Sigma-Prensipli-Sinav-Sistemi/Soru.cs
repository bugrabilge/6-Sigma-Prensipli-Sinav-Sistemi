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
        
        
        public void siradakiSoruBilgileriniCekVeAta(int questionStatus) 
        {
            /* QuestionStatus = 0 -> Henuz admin tarafindan onaylanmamis sorular
            * QuestionStatus = 1 -> Admin tarafindan onaylanip soru havuzuna eklenmis sorular
            * QuestionStatus = 2 -> 6 kez üst üste bilinip test havuzundan cikarilmis sorular
            */
            Veritabani.baglantiYoksaYeniBaglantiAc();
            siradaSoruVarMi = false;
            Veritabani.Komut.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionStatus = '" + questionStatus + "' ORDER BY NEWID()";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();

            if (Veritabani.VeriOkuyucu.Read())
            {
                secenekleriVeBilgileriAta(Convert.ToInt32(Veritabani.VeriOkuyucu["QuestionID"]));
                siradaSoruVarMi = true;
            }

            Veritabani.baglantiyiKes();

        }

        public void secenekleriVeBilgileriAta(int id)
        {           
            this.ID = id;
            Veritabani.baglantiYoksaYeniBaglantiAc();
            //Veritabani.VeriOkuyucu.Close();
            Veritabani.Komut.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionID = '" + this.ID + "'";
            Veritabani.VeriOkuyucu = Veritabani.Komut.ExecuteReader();

            while (Veritabani.VeriOkuyucu.Read())
            {                
                this.Govde = govdeSatirUzunlugunuLimitle(Veritabani.VeriOkuyucu["QuestionText"].ToString(), 120);
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
            Veritabani.baglantiyiKes();
        }



        private string govdeSatirUzunlugunuLimitle(string govde, int maksimumUzunluk)
        {   // Sorunun govdesi istenen uzunluga gore alt satira gecirilerek return ediliyor
            int index = 0;
            string yeniGovde = null;
            if (index + maksimumUzunluk < govde.Length)
            {
                while (index + maksimumUzunluk < govde.Length)
                {
                    yeniGovde += govde.Substring(index, maksimumUzunluk) + "-\n";
                    index += maksimumUzunluk;
                }
                yeniGovde += govde.Substring(index, govde.Length - index);
                return yeniGovde;
            }

            else
            {
                return govde;
            }
        }
    }
}
