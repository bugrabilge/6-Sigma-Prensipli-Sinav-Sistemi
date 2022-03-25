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
    public partial class SSorumluForm : Form
    {
        public SSorumluForm()
        {
            InitializeComponent();
        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png";
            dosya.Title = "Eklemek istediğiniz resmi seçiniz.";
            dosya.ShowDialog();
            string dosyaYolu = dosya.FileName;
            picSoruResmi.ImageLocation = dosyaYolu;
            _ = (picSoruResmi.ImageLocation == null) ? btnArttır.Enabled = btnAzalt.Enabled = false : btnArttır.Enabled = btnAzalt.Enabled = true;
        }

        private void btnArttır_Click(object sender, EventArgs e)
        {
            if (rdbGenislik.Checked == true)
            {               
                resimGenislikDegistir("+");
            }
            if (rdbYukseklik.Checked == true)
            {
                resimYukseklikDegistir("+");
            }
        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            if (rdbGenislik.Checked == true)
            {
                resimGenislikDegistir("-");
            }
            if (rdbYukseklik.Checked == true)
            {
                resimYukseklikDegistir("-");
            }
        }

        public void resimGenislikDegistir(string islem)
        {
            Size boyut = picSoruResmi.Size;
            _ = (islem == "+") ? boyut.Width += 5 : boyut.Width -= 5;
            picSoruResmi.Size = boyut;
        }

        public void resimYukseklikDegistir(string islem)
        {
            Size boyut = picSoruResmi.Size;
            _ = (islem == "+") ? boyut.Height += 5 : boyut.Height -= 5;
            picSoruResmi.Size = boyut;
        }

        private void SSorumluForm_Load(object sender, EventArgs e)
        {
            btnArttır.Enabled = btnAzalt.Enabled = false;
        }

        private void SSorumluForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
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
                        soruVerileriniVeritabanınaIsle();
                        MessageBox.Show("Sorunuz Gönderildi.\nAdmin onayından sonra sistemde gözükecektir.");
                        textboxlarıTemizle();
                        break;
                    }
                }
            }       
        }

        public void soruVerileriniVeritabanınaIsle()
        {
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into dbo.Questions (QuestionText, SectionID, UnitID, PicturePath, PictureWidth, PictureHeight, RightAnswer, " +
                "WrongAnswer1, WrongAnswer2, WrongAnswer3, WrongAnswer4,QuestionStatus) " +
                "values (@soruText, @konuID, @uniteID, @resimYolu, @resimGenisligi, @resimYuksekligi, @dogruCevap," +
                "@yanlisCevap1, @yanlisCevap2, @yanlisCevap3, @yanlisCevap4, @soruDurumu )";
            cmd.Parameters.AddWithValue("@soruText", txtSoruGovde.Text);
            cmd.Parameters.AddWithValue("@konuID", txtKonuNo.Text);
            cmd.Parameters.AddWithValue("@uniteID", txtUniteNo.Text);
            if (picSoruResmi.ImageLocation != null)
            {
                cmd.Parameters.AddWithValue("@resimYolu", picSoruResmi.ImageLocation);
                cmd.Parameters.AddWithValue("@resimGenisligi", picSoruResmi.Size.Width);
                cmd.Parameters.AddWithValue("@resimYuksekligi", picSoruResmi.Size.Height);
            }
            else
            {
                cmd.Parameters.AddWithValue("@resimYolu", DBNull.Value);
                cmd.Parameters.AddWithValue("@resimGenisligi", DBNull.Value);
                cmd.Parameters.AddWithValue("@resimYuksekligi", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@dogruCevap", txtDogruCevap.Text);
            cmd.Parameters.AddWithValue("@yanlisCevap1", txtYanlisCevap1.Text);
            cmd.Parameters.AddWithValue("@yanlisCevap2", txtYanlisCevap2.Text);
            cmd.Parameters.AddWithValue("@yanlisCevap3", txtYanlisCevap3.Text);
            cmd.Parameters.AddWithValue("@yanlisCevap4", txtYanlisCevap4.Text);
            cmd.Parameters.AddWithValue("@soruDurumu", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void textboxlarıTemizle()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Text = String.Empty;
                }
            }
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }
    }
}
