using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public partial class frmSinavSorumlusu : Form
    {
        public frmSinavSorumlusu()
        {
            InitializeComponent();
        }
        
        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            SinavSorumlusu ss = new SinavSorumlusu();
            ss.ResimYukle(picSoruResmi, btnArttır, btnAzalt);
        }

        private void btnArttır_Click(object sender, EventArgs e)
        {
            if (rdbGenislik.Checked == true)
            {               
                ResimGenislikDegistir("+");
            }
            if (rdbYukseklik.Checked == true)
            {
                ResimYukseklikDegistir("+");
            }
        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            if (rdbGenislik.Checked == true)
            {
                ResimGenislikDegistir("-");
            }
            if (rdbYukseklik.Checked == true)
            {
                ResimYukseklikDegistir("-");
            }
        }

        public void ResimGenislikDegistir(string islem)
        {
            SinavSorumlusu ss = new SinavSorumlusu();
            ss.ResimGenislikDegistir(islem, picSoruResmi);
        }

        public void ResimYukseklikDegistir(string islem)
        {
            SinavSorumlusu ss = new SinavSorumlusu();
            ss.ResimYukseklikDegistir(islem, picSoruResmi);
        }

        public void SSorumluForm_Load(object sender, EventArgs e)
        {
            btnArttır.Visible = btnAzalt.Visible = false;
        }

        private void SSorumluForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtUniteNo_TextChanged(object sender, EventArgs e)
        {
            SinavSorumlusu ss = new SinavSorumlusu();
            ss.UniteVeyaKonuIsmiCek("Unit", txtUniteNo.Text, lblUIsim, lblUIsim);
        }

        private void txtKonuNo_TextChanged(object sender, EventArgs e)
        {
            SinavSorumlusu ss = new SinavSorumlusu();
            ss.UniteVeyaKonuIsmiCek("Section", txtKonuNo.Text, lblKIsim, lblUIsim);
        }

        private void btnSoruyuGonder_Click(object sender, EventArgs e)
        {
            
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    if (ctl.Text == String.Empty)
                    {
                        MessageBox.Show("Lütfen Tüm Alanları Doldurunuz.");
                        break;
                    }
                    else
                    {
                        SinavSorumlusu ss = new SinavSorumlusu();
                        GirilenVerileriNesneyeAta(ss);
                        //soruVerileriniVeritabanınaIsle();
                        ss.SoruVerileriniVeritabanınaIsle();
                        MessageBox.Show("Sorunuz Gönderildi.\nAdmin onayından sonra sistemde gözükecektir.");
                        TextboxlarıTemizle();
                        break;
                    }
                }
            }       
        }

        private void GirilenVerileriNesneyeAta(SinavSorumlusu ss)
        {
            ss.IslemYapilacakSoru.Govde = txtSoruGovde.Text;
            ss.IslemYapilacakSoru.SectionID = Convert.ToInt32(txtKonuNo.Text);
            ss.IslemYapilacakSoru.UnitID = Convert.ToInt32(txtUniteNo.Text);
            ss.IslemYapilacakSoru.ResimYolu = picSoruResmi.ImageLocation;
            ss.IslemYapilacakSoru.ResimGenisligi = picSoruResmi.Size.Width;
            ss.IslemYapilacakSoru.ResimYuksekligi = picSoruResmi.Size.Height;
            ss.IslemYapilacakSoru.DogruCevap = txtDogruCevap.Text;
            ss.IslemYapilacakSoru.YanlisCevap1 = txtYanlisCevap1.Text;
            ss.IslemYapilacakSoru.YanlisCevap2 = txtYanlisCevap2.Text;
            ss.IslemYapilacakSoru.YanlisCevap3 = txtYanlisCevap3.Text;
            ss.IslemYapilacakSoru.YanlisCevap4 = txtYanlisCevap4.Text;
        }

        public void TextboxlarıTemizle()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Text = String.Empty;
                }
            }
            picSoruResmi.Image = null;
            picSoruResmi.ImageLocation = null;
            btnArttır.Visible = false;
            btnAzalt.Visible = false;
            
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            formGecis.FormlarArasıGecisYap(this, "girisForm");
        }
    }
}
