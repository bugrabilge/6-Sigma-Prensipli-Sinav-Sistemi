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
    public partial class OgrenciForm : Form
    {
        public OgrenciForm()
        {
            InitializeComponent();
        }
        private void btnSigma_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "sigmaTestForm");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "girisForm");
        }

        private void OgrenciForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNormalTest_Click(object sender, EventArgs e)
        {
            formGecis.formlarArasıGecisYap(this, "normalTestForm");
        }
    }
}
