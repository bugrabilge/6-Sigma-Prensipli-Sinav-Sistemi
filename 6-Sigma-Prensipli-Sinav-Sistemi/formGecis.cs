using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    public static class formGecis
    {
        public static void formlarArasıGecisYap(Form kapatılacakFormIsmi, string acilacakFormIsmi)
        {
            switch (acilacakFormIsmi)
            {
                case "adminForm":
                    AdminForm adminForm = new AdminForm();
                    kapatılacakFormIsmi.Hide();
                    adminForm.Show();
                    break;
                case "ogrenciForm":
                    OgrenciForm ogrenciForm = new OgrenciForm();
                    kapatılacakFormIsmi.Hide();
                    ogrenciForm.Show();
                    break;
                case "sSorumluForm":
                    SSorumluForm sSorumluForm = new SSorumluForm();
                    kapatılacakFormIsmi.Hide();
                    sSorumluForm.Show();
                    break;
                case "sifreKurtarmaForm":
                    SifreKurtarmaForm sifreKurtarmaForm = new SifreKurtarmaForm();
                    kapatılacakFormIsmi.Hide();
                    sifreKurtarmaForm.Show();
                    break;
                case "kayitForm":
                    KayitForm kayitForm = new KayitForm();
                    kapatılacakFormIsmi.Hide();
                    kayitForm.Show();
                    break;
                case "girisForm":
                    GirisForm girisForm = new GirisForm();
                    kapatılacakFormIsmi.Hide();
                    girisForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
