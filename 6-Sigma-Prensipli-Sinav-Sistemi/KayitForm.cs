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
    public partial class KayitForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public KayitForm()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
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
                        VerileriKayitEt();
                    }
                }
            }
        }

        private void KayitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            GirisForm gForm = new GirisForm();
            gForm.ShowDialog();
        }

        public void VerileriKayitEt()
        {
            con = new SqlConnection("Data Source=DESKTOP-HCML6IK;Initial Catalog=dbSigma;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into dbo.Users(UserName, Name, Surname, Mail, Password, SecurityAnswer, UserTypeID) " +
                                            "values('" + txtKullaniciAdi.Text + "','" +
                                                         txtAd.Text + "','" +
                                                         txtSoyad.Text + "','" +
                                                         txtMail.Text + "','" +
                                                         txtSifre.Text + "','" +
                                                         txtGuvenlikCevap.Text + "','" +
                                                         (cmbKullaniciTuru.SelectedIndex + 1) + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşmiştir!");
            KayitForm.ActiveForm.Hide();
            GirisForm gForm = new GirisForm();
            gForm.ShowDialog();
        }
    }
}
