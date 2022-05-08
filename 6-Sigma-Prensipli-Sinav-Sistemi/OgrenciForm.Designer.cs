
namespace _6_Sigma_Prensipli_Sinav_Sistemi
{
    partial class OgrenciForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciForm));
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnSigma = new System.Windows.Forms.Button();
            this.btnNormalTest = new System.Windows.Forms.Button();
            this.lblHosgeldin = new System.Windows.Forms.Label();
            this.lblOgrenciIsım = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picOgrenciIcon = new System.Windows.Forms.PictureBox();
            this.picOgrenciHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOgrenciIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOgrenciHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnCikis.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(355, 303);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(89, 35);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnSigma
            // 
            this.btnSigma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnSigma.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSigma.ForeColor = System.Drawing.Color.White;
            this.btnSigma.Location = new System.Drawing.Point(69, 236);
            this.btnSigma.Name = "btnSigma";
            this.btnSigma.Size = new System.Drawing.Size(163, 61);
            this.btnSigma.TabIndex = 4;
            this.btnSigma.Text = "Sigma Testi";
            this.btnSigma.UseVisualStyleBackColor = false;
            this.btnSigma.Click += new System.EventHandler(this.btnSigma_Click);
            // 
            // btnNormalTest
            // 
            this.btnNormalTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnNormalTest.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNormalTest.ForeColor = System.Drawing.Color.White;
            this.btnNormalTest.Location = new System.Drawing.Point(238, 237);
            this.btnNormalTest.Name = "btnNormalTest";
            this.btnNormalTest.Size = new System.Drawing.Size(163, 60);
            this.btnNormalTest.TabIndex = 5;
            this.btnNormalTest.Text = "Eksik Giderme Testi";
            this.btnNormalTest.UseVisualStyleBackColor = false;
            this.btnNormalTest.Click += new System.EventHandler(this.btnNormalTest_Click);
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.AutoSize = true;
            this.lblHosgeldin.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHosgeldin.Location = new System.Drawing.Point(47, 114);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(171, 21);
            this.lblHosgeldin.TabIndex = 6;
            this.lblHosgeldin.Text = "Hoş Geldiniz Sayın :";
            // 
            // lblOgrenciIsım
            // 
            this.lblOgrenciIsım.AutoSize = true;
            this.lblOgrenciIsım.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOgrenciIsım.Location = new System.Drawing.Point(72, 150);
            this.lblOgrenciIsım.Name = "lblOgrenciIsım";
            this.lblOgrenciIsım.Size = new System.Drawing.Size(108, 21);
            this.lblOgrenciIsım.TabIndex = 7;
            this.lblOgrenciIsım.Text = "Öğrenci ismi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Uygulamak istediğiniz Test Seçimini Yapınız...";
            // 
            // picOgrenciIcon
            // 
            this.picOgrenciIcon.Image = global::_6_Sigma_Prensipli_Sinav_Sistemi.Properties.Resources.ogrenci2;
            this.picOgrenciIcon.Location = new System.Drawing.Point(339, 12);
            this.picOgrenciIcon.Name = "picOgrenciIcon";
            this.picOgrenciIcon.Size = new System.Drawing.Size(105, 96);
            this.picOgrenciIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOgrenciIcon.TabIndex = 10;
            this.picOgrenciIcon.TabStop = false;
            // 
            // picOgrenciHeader
            // 
            this.picOgrenciHeader.Image = global::_6_Sigma_Prensipli_Sinav_Sistemi.Properties.Resources.ogrencisecim2;
            this.picOgrenciHeader.Location = new System.Drawing.Point(12, 12);
            this.picOgrenciHeader.Name = "picOgrenciHeader";
            this.picOgrenciHeader.Size = new System.Drawing.Size(321, 77);
            this.picOgrenciHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOgrenciHeader.TabIndex = 9;
            this.picOgrenciHeader.TabStop = false;
            // 
            // OgrenciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 350);
            this.Controls.Add(this.picOgrenciIcon);
            this.Controls.Add(this.picOgrenciHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOgrenciIsım);
            this.Controls.Add(this.lblHosgeldin);
            this.Controls.Add(this.btnNormalTest);
            this.Controls.Add(this.btnSigma);
            this.Controls.Add(this.btnCikis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OgrenciForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Ekranı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OgrenciForm_FormClosing);
            this.Load += new System.EventHandler(this.OgrenciForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOgrenciIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOgrenciHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnSigma;
        private System.Windows.Forms.Button btnNormalTest;
        private System.Windows.Forms.Label lblHosgeldin;
        private System.Windows.Forms.Label lblOgrenciIsım;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOgrenciHeader;
        private System.Windows.Forms.PictureBox picOgrenciIcon;
    }
}