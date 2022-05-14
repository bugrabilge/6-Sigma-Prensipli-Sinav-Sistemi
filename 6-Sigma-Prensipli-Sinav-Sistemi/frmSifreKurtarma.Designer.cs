
namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    partial class frmSifreKurtarma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSifreKurtarma));
            this.lblSifreKurtarmaA = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblSoru = new System.Windows.Forms.Label();
            this.txtCevap = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSifreKurtarmaA
            // 
            this.lblSifreKurtarmaA.AutoSize = true;
            this.lblSifreKurtarmaA.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifreKurtarmaA.Location = new System.Drawing.Point(22, 23);
            this.lblSifreKurtarmaA.Name = "lblSifreKurtarmaA";
            this.lblSifreKurtarmaA.Size = new System.Drawing.Size(405, 18);
            this.lblSifreKurtarmaA.TabIndex = 0;
            this.lblSifreKurtarmaA.Text = "Lütfen kullanıcı adınızı ve güvenlik sorusu cevabınızı giriniz.";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(22, 61);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(113, 18);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "Kullanıcı Adınız:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(235, 58);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(133, 26);
            this.txtKullaniciAdi.TabIndex = 2;
            // 
            // lblSoru
            // 
            this.lblSoru.AutoSize = true;
            this.lblSoru.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoru.Location = new System.Drawing.Point(22, 89);
            this.lblSoru.Name = "lblSoru";
            this.lblSoru.Size = new System.Drawing.Size(170, 18);
            this.lblSoru.TabIndex = 3;
            this.lblSoru.Text = "En sevdiğiniz film nedir?";
            // 
            // txtCevap
            // 
            this.txtCevap.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCevap.Location = new System.Drawing.Point(235, 86);
            this.txtCevap.Name = "txtCevap";
            this.txtCevap.Size = new System.Drawing.Size(133, 26);
            this.txtCevap.TabIndex = 4;
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnGonder.FlatAppearance.BorderSize = 0;
            this.btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGonder.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.ForeColor = System.Drawing.Color.White;
            this.btnGonder.Location = new System.Drawing.Point(265, 125);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(133, 31);
            this.btnGonder.TabIndex = 5;
            this.btnGonder.Text = "Şifremi Kurtar";
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // SifreKurtarmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 170);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtCevap);
            this.Controls.Add(this.lblSoru);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.lblSifreKurtarmaA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SifreKurtarmaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifremi Kurtar!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SifreKurtarmaForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSifreKurtarmaA;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label lblSoru;
        private System.Windows.Forms.TextBox txtCevap;
        private System.Windows.Forms.Button btnGonder;
    }
}