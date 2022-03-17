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

    public partial class GirisForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public GirisForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string user = txtKullaniciAdi.Text;
            string pass = txtSifre.Text;
            int id;
            
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM dbo.Users where UserName='" + user + "' AND Password='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı!\nYönlendiriliyorsunuz.");

                switch (dr["UserTypeID"])
                {
                    case 1:
                        MessageBox.Show("Öğrenci Girişi");
                        break;
                    case 2:
                        MessageBox.Show("Öğretmen Girişi");
                        break;
                    case 3:
                        AdminForm aForm = new AdminForm();
                        this.Hide();
                        aForm.Show();
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.\nLütfen tekrar deneyiniz.");
            }
            con.Close();
            

        }
    }
}
