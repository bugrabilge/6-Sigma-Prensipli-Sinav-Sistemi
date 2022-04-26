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
    public partial class SigmaTestForm : Form
    {
        public SigmaTestForm()
        {
            InitializeComponent();
        }

        int dogruSayisi;
        int yanlisSayisi;
        string dogruCevap;
        int soruID;

        private void btnBasla_Click(object sender, EventArgs e)
        {
            siradakiSoru();
            btnBasla.Enabled = false;
        }

        private void randomSeceneklerAtama(SqlDataReader dr)
        {
            var rnd = new Random();
            string[] kelimeler = { "RightAnswer", "WrongAnswer1", "WrongAnswer2", "WrongAnswer3", "WrongAnswer4" };
            List<string> secenekSirasi = new List<string>();
            string x;
            // Sql sorgumuzda kullanacagimiz kelimeleri string arrayden random sekilde string liste ekleyerek seceneklere atıyoruz
            while (secenekSirasi.Count < 5)
            {
                x = kelimeler.GetValue(rnd.Next(0, 5)).ToString();
                if (!secenekSirasi.Contains(x))
                {
                    secenekSirasi.Add(x);
                }
            }

            lblA.Text = dr[secenekSirasi[0]].ToString();
            lblB.Text = dr[secenekSirasi[1]].ToString();
            lblC.Text = dr[secenekSirasi[2]].ToString();
            lblD.Text = dr[secenekSirasi[3]].ToString();
            lblE.Text = dr[secenekSirasi[4]].ToString();

            dogruCevap = dr["RightAnswer"].ToString();
        }

        private void dogruYanlisKontrolu(Button secenek)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            
            

            foreach (Control ctl in this.Controls)
            {
                if (ctl is Label && ctl.Text == dogruCevap)
                {
                    if (ctl.Name[3] == secenek.Name[3])
                    {
                        dogruSayisi++;
                        MessageBox.Show("dogru");
                        cmd.CommandText = "UPDATE dbo.Questions SET TrueCount = (TrueCount + 1) WHERE QuestionID ='" + soruID + "'";
                        
                        
                    }
                    else
                    {
                        yanlisSayisi++;
                        MessageBox.Show("yanlis");
                        cmd.CommandText = "UPDATE dbo.Questions SET TrueCount = 0 WHERE QuestionID ='" + soruID + "'";
                        
                    }

                    siradakiSoru();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    break;

                }
            }
        }

        private void siradakiSoru()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            int sayac = 0;

            cmd.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionStatus = 1 ORDER BY NEWID()";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sayac++;
                soruID = Convert.ToInt32(dr["QuestionID"]);
                lblSayi.Text = sayac.ToString() + ". sorunuz:";
                lblSoruGovde.Text = soruGovdesiUzunlukLimitle(dr["QuestionText"].ToString(), 120);

                randomSeceneklerAtama(dr);

                if (dr["PicturePath"] != DBNull.Value)
                {
                    picSoruResmi.Visible = true;
                    picSoruResmi.ImageLocation = dr["PicturePath"].ToString();
                    picSoruResmi.Height = Convert.ToInt32(dr["PictureHeight"]);
                    picSoruResmi.Width = Convert.ToInt32(dr["PictureWidth"]);
                }
                else
                {
                    picSoruResmi.Visible = false;
                }

                break;

            }

            con.Close();
        }
        private string soruGovdesiUzunlukLimitle(string text, int maxlenght)
        {
            // istenen karakter uzunlugundan sonra metinin alt satıra gecmesini saglıyoruz
            int index = 0;
            string newtext = null;
            if (index + maxlenght < text.Length)
            {
                while (index + maxlenght < text.Length)
                {
                    newtext += text.Substring(index, maxlenght) + "-\n";
                    index += maxlenght;
                }
                newtext += text.Substring(index, text.Length - index);
                return newtext;
            }

            else
            {
                return text;
            }
        }

        private void SigmaTestForm_Load(object sender, EventArgs e)
        {
            
        }

        private void SigmaTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            dogruYanlisKontrolu(btnA);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            dogruYanlisKontrolu(btnB);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            dogruYanlisKontrolu(btnC);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            dogruYanlisKontrolu(btnD);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            dogruYanlisKontrolu(btnE);
        }
    }
}
