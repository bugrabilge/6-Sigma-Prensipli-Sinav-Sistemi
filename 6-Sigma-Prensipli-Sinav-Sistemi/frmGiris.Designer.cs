
namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    partial class frmGiris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiris));
            this.btnGiris = new System.Windows.Forms.Button();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.lblSifremiUnuttum = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picLoginYazi = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picSigmaIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginYazi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSigmaIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnGiris.FlatAppearance.BorderSize = 0;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Location = new System.Drawing.Point(149, 313);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(102, 33);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.White;
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(67, 214);
            this.txtKullaniciAdi.Multiline = true;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(198, 24);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // txtSifre
            // 
            this.txtSifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.txtSifre.Location = new System.Drawing.Point(67, 260);
            this.txtSifre.Multiline = true;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(198, 24);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.TextChanged += new System.EventHandler(this.txtSifre_TextChanged);
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnKayitOl.FlatAppearance.BorderSize = 0;
            this.btnKayitOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayitOl.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitOl.ForeColor = System.Drawing.Color.White;
            this.btnKayitOl.Location = new System.Drawing.Point(41, 313);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(102, 33);
            this.btnKayitOl.TabIndex = 3;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.UseVisualStyleBackColor = false;
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            // 
            // lblSifremiUnuttum
            // 
            this.lblSifremiUnuttum.AutoSize = true;
            this.lblSifremiUnuttum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifremiUnuttum.Location = new System.Drawing.Point(90, 363);
            this.lblSifremiUnuttum.Name = "lblSifremiUnuttum";
            this.lblSifremiUnuttum.Size = new System.Drawing.Size(114, 18);
            this.lblSifremiUnuttum.TabIndex = 4;
            this.lblSifremiUnuttum.TabStop = true;
            this.lblSifremiUnuttum.Text = "Şifremi Unuttum";
            this.lblSifremiUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSifremiUnuttum_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.panel1.Location = new System.Drawing.Point(29, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 1);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.panel2.Location = new System.Drawing.Point(29, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 1);
            this.panel2.TabIndex = 9;
            // 
            // picLoginYazi
            // 
            this.picLoginYazi.Image = global::_6_Sigma_Prensipli_Sinav_Sistemi.Properties.Resources.sigmalogin2;
            this.picLoginYazi.Location = new System.Drawing.Point(41, 145);
            this.picLoginYazi.Name = "picLoginYazi";
            this.picLoginYazi.Size = new System.Drawing.Size(210, 58);
            this.picLoginYazi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoginYazi.TabIndex = 10;
            this.picLoginYazi.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::_6_Sigma_Prensipli_Sinav_Sistemi.Properties.Resources.sifre;
            this.pictureBox3.Location = new System.Drawing.Point(29, 255);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_6_Sigma_Prensipli_Sinav_Sistemi.Properties.Resources.kullaniciAdi;
            this.pictureBox2.Location = new System.Drawing.Point(29, 210);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // picSigmaIcon
            // 
            this.picSigmaIcon.Image = global::_6_Sigma_Prensipli_Sinav_Sistemi.Properties.Resources._6sigma;
            this.picSigmaIcon.Location = new System.Drawing.Point(67, 41);
            this.picSigmaIcon.Name = "picSigmaIcon";
            this.picSigmaIcon.Size = new System.Drawing.Size(164, 98);
            this.picSigmaIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSigmaIcon.TabIndex = 5;
            this.picSigmaIcon.TabStop = false;
            // 
            // frmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 400);
            this.Controls.Add(this.picLoginYazi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picSigmaIcon);
            this.Controls.Add(this.lblSifremiUnuttum);
            this.Controls.Add(this.btnKayitOl);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.btnGiris);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GirisForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picLoginYazi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSigmaIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnKayitOl;
        private System.Windows.Forms.LinkLabel lblSifremiUnuttum;
        private System.Windows.Forms.PictureBox picSigmaIcon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picLoginYazi;
    }
}

