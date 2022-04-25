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

        private void btnBasla_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            int sayac = 1;

            cmd.CommandText = "SELECT * FROM dbo.Questions WHERE QuestionStatus = 0 ORDER BY NEWID()";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblSayi.Text = sayac.ToString() + ". sorunuz:";
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
                sayac++;
                break;

            }

            con.Close();
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

        private void SigmaTestForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
