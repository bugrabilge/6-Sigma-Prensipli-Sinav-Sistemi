using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public class TestIslemleri
    {
        public veriTabaniBaglanti Veritabani { get; set; }
        public TestIslemleri()
        {
            veriTabaniBaglanti vt = new veriTabaniBaglanti();
            this.Veritabani = vt;
        }
        public void soruyuFormaRandomSeceneklerleYansıt(Soru soru, Label lblGovde, Label[] seceneklerArray , PictureBox box)
        {
            var rnd = new Random();
            List<Label> randomSecenekler = new List<Label>();
            Label x;
            // Seceneklerimizi yazdıracagimiz labelları label arrayden random sekilde label listeye ekliyoruz ve form atamalarini gerceklestiriyoruz
            while (randomSecenekler.Count < 5)
            {
                x = (Label)seceneklerArray.GetValue(rnd.Next(0, 5));
                if (!randomSecenekler.Contains(x))
                {
                    randomSecenekler.Add(x);
                }
            }

            lblGovde.Text = soru.Govde;
            randomSecenekler[0].Text = soru.DogruCevap;
            randomSecenekler[1].Text = soru.YanlisCevap1;
            randomSecenekler[2].Text = soru.YanlisCevap2;
            randomSecenekler[3].Text = soru.YanlisCevap3;
            randomSecenekler[4].Text = soru.YanlisCevap4;

            if (soru.ResimYolu != null)
            {
                box.Visible = true;
                box.ImageLocation = soru.ResimYolu;
                box.Height = soru.ResimYuksekligi;
                box.Width = soru.ResimGenisligi;
            }
            else
            {
                box.Visible = false;
            }
        }

        public void dogruYanlisKontroluYap(Ogrenci ogrenci, Label secenek)
        {
            if (secenek.Text == ogrenci.IslemYapilacakSoru.DogruCevap) // secenegin labelinda yazan sorunun dogru cevabiysa
            {
                ogrenci.DogruSayisi++;
                MessageBox.Show("dogru");              
            }
            else // secenegin labelinda yazan sorunun yanlis cevabiysa
            {
                ogrenci.YanlisSayisi++;
                MessageBox.Show("yanlis");               
            }          
        }      
    }
}
