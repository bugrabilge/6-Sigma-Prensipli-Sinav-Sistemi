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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        int soruID;
        
        private void AdminForm_Load(object sender, EventArgs e)
        {
            soruYukle();
        }

        private void soruYukle()
        {
            
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            bool soruKontrol = false;
            cmd.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionStatus = 0 ORDER BY NEWID()";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                grpSoru.Visible = true;
                soruKontrol = true;
                soruID = Convert.ToInt32(dr["QuestionID"]);
                lblSoruGovde.Text = uzunluklimitle(dr["QuestionText"].ToString(), 120);
                lblA.Text = dr["RightAnswer"].ToString();
                lblB.Text = dr["WrongAnswer1"].ToString();
                lblC.Text = dr["WrongAnswer2"].ToString();
                lblD.Text = dr["WrongAnswer3"].ToString();
                lblE.Text = dr["WrongAnswer4"].ToString();

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

            if (soruKontrol == false)
            {
                MessageBox.Show("Onay Bekleyen Soru Bulunmamaktadır.");
                grpSoru.Visible = false;

            }
        }
        private string uzunluklimitle(string text, int maxlenght)
        {
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

        private void btnSiradaki_Click(object sender, EventArgs e)
        {
            soruYukle();     
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE dbo.Questions SET QuestionStatus = 1 WHERE QuestionID ='" + soruID + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Soru, soru havuzuna eklenmiştir.");
            con.Close();
            soruYukle();              
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM dbo.Questions WHERE QuestionID ='" + soruID + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Soru silinmiştir.");
            con.Close();
            soruYukle();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }
    }
}
