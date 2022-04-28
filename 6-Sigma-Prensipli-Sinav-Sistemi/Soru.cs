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
        
        private string govde;

        private string dogruCevap;
        private string yanlisCevap1;
        private string yanlisCevap2;
        private string yanlisCevap3;
        private string yanlisCevap4;

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
        public string Govde
        {
            get { return govde; }
            set { govde = value; }
        }
        public string DogruCevap
        {
            get { return dogruCevap; }
            set { dogruCevap = value; }
        }


        public string YanlisCevap1
        {
            get { return yanlisCevap1; }
            set { yanlisCevap1 = value; }
        }


        public string YanlisCevap2
        {
            get { return yanlisCevap2; }
            set { yanlisCevap2 = value; }
        }


        public string YanlisCevap3
        {
            get { return yanlisCevap3; }
            set { yanlisCevap3 = value; }
        }


        public string YanlisCevap4
        {
            get { return yanlisCevap4; }
            set { yanlisCevap4 = value; }
        }


        public string ResimYolu { get; set; }
        public int ResimYuksekligi { get; set; }
        public int ResimGenisligi { get; set; }

        public GroupBox Grup { get; set; }

        public void secenekleriVeBilgileriAta(int id)
        {
            this.ID = id;
            Veritabani.kontrolEtVeYeniBaglantiAc();
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
                this.DogruYapilmaSayisi = Convert.ToInt32(Veritabani.VeriOkuyucu["TrueCount"]);

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
        {
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
