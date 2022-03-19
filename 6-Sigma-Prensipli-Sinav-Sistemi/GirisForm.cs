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

        private void btnGiris_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            kullaniciAdiKontrolVeGiris();
            con.Close();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            GirisForm.ActiveForm.Hide();
            KayitForm kForm = new KayitForm();
            kForm.ShowDialog();
        }

        private void GirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void kullaniciAdiKontrolVeGiris()
        {
            if (txtKullaniciAdi.Text != "" && txtSifre.Text != "")
            {
                cmd.CommandText = "SELECT UserName FROM dbo.Users where UserName='" + txtKullaniciAdi.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    giris();
                }
                else
                {
                    MessageBox.Show("Girilen kullanıcı adı bulunamamıştır.\nLütfen tekrar deneyiniz.\nKaydınız bulunmuyor ise Kayıt Ol butonu ile kayıt olabilirsiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            
        }

        public void giris()
        {
            string user = txtKullaniciAdi.Text;
            string pass = txtSifre.Text;
            cmd.CommandText = "SELECT UserName, Password, UserTypeID FROM dbo.Users where UserName='" + user + "' AND Password='" + pass + "'";
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
                        GirisForm.ActiveForm.Hide();
                        aForm.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Hatalı şifre girdiniz. Lütfen tekrar deneyiniz.");
            }
        }
    }
}
