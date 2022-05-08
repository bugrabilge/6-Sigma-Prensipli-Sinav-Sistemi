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
        public KayitForm()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit(); // formda girilen bilgiler veritabanina islenirken kullanilmak uzere kayıt nesnesine ataniyor
            kayit.KayitOlanKullaniciAdi = txtKullaniciAdi.Text;
            kayit.KayitOlanSifre = txtSifre.Text;
            kayit.Ad = txtAd.Text;
            kayit.Soyad = txtSoyad.Text;
            kayit.Mail = txtMail.Text;
            kayit.GuvenlikSorusuCevabi = txtGuvenlikCevap.Text;
            kayit.KullaniciTuru = cmbKullaniciTuru.SelectedIndex + 1;
            
            
            
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
                        kayit.verileriVeritabaninaKayitEt(); // kayıt nesnesi uzerinden bilgiler veritabanina isleniyor
                        formGecis.formlarArasıGecisYap(this, "girisForm");
                        break;
                    }
                }
            }
        }

        private void KayitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }


    }
}
