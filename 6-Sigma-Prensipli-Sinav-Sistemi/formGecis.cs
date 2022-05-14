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
        public static void FormlarArasıGecisYap(Form kapatılacakFormIsmi, string acilacakFormIsmi)
        {
            // gelen parametrelere göre form yönlendirme işlemleri gerçekleşiyor
            switch (acilacakFormIsmi)
            {
                case "adminForm":
                    frmAdmin adminForm = new frmAdmin();
                    kapatılacakFormIsmi.Hide();
                    adminForm.Show();
                    break;
                case "ogrenciForm":
                    frmOgrenci ogrenciForm = new frmOgrenci();
                    kapatılacakFormIsmi.Hide();
                    ogrenciForm.Show();
                    break;
                case "sSorumluForm":
                    frmSinavSorumlusu sSorumluForm = new frmSinavSorumlusu();
                    kapatılacakFormIsmi.Hide();
                    sSorumluForm.Show();
                    break;
                case "sifreKurtarmaForm":
                    frmSifreKurtarma sifreKurtarmaForm = new frmSifreKurtarma();
                    kapatılacakFormIsmi.Hide();
                    sifreKurtarmaForm.Show();
                    break;
                case "kayitForm":
                    frmKayit kayitForm = new frmKayit();
                    kapatılacakFormIsmi.Hide();
                    kayitForm.Show();
                    break;
                case "girisForm":
                    frmGiris girisForm = new frmGiris();
                    kapatılacakFormIsmi.Hide();
                    girisForm.Show();
                    break;
                case "sigmaTestForm":
                    frmSigmaTest sigmaForm = new frmSigmaTest();
                    kapatılacakFormIsmi.Hide();
                    sigmaForm.Show();
                    break;
                case "ayarlar":
                    frmAyarlar ayarlarForm = new frmAyarlar();
                    ayarlarForm.ShowDialog();
                    break;
                case "normalTestForm":
                    frmHazirlikTest normalForm = new frmHazirlikTest();
                    kapatılacakFormIsmi.Hide();
                    normalForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
