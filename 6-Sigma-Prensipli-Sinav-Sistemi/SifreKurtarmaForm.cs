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
    public partial class SifreKurtarmaForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public SifreKurtarmaForm()
        {
            InitializeComponent();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (txtKullaniciAdi.Text !="" && txtCevap.Text != "")
            {
                cevaplariKontrolEt();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            con.Close();
        }

        public void cevaplariKontrolEt()
        {
            string girilenKullaniciAdi = txtKullaniciAdi.Text;
            string girilenCevap = txtCevap.Text;
            string sifre;
            cmd.CommandText = "SELECT UserName, Password, SecurityAnswer FROM dbo.Users where UserName='" + girilenKullaniciAdi + "' AND SecurityAnswer='" + girilenCevap + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sifre = dr["Password"].ToString();
                MessageBox.Show("Cevabınız doğru! Şifreniz : " + sifre + "\nGiriş yapabilirsiniz.");
                formGecis.formlarArasıGecisYap(this, "girisForm");
            }
            else
            {
                MessageBox.Show("Girilen Kullanıcı adı veya girilen cevap yanlıştır.\nLütfen tekrar deneyiniz.");
            }
        }

        private void SifreKurtarmaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }
    }
}
