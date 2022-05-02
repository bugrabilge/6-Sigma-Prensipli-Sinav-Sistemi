using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public partial class AyarlarForm : Form
    {
        public AyarlarForm()
        {
            InitializeComponent();
        }

        public static List<int> ayarlardanDegistirilenSayilar = new List<int>();
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            ayarlardanDegistirilenSayilar.Add(Convert.ToInt32(txtIlk.Text));
            ayarlardanDegistirilenSayilar.Add(Convert.ToInt32(txtIkinci.Text));
            ayarlardanDegistirilenSayilar.Add(Convert.ToInt32(txtUcuncu.Text));
            ayarlardanDegistirilenSayilar.Add(Convert.ToInt32(txtDorduncu.Text));
            ayarlardanDegistirilenSayilar.Add(Convert.ToInt32(txtBesinci.Text));
            ayarlardanDegistirilenSayilar.Add(Convert.ToInt32(txtAltinci.Text));
            this.Hide();
        }
    }
}
