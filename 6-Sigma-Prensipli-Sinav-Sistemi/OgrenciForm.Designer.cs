
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
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnSigma = new System.Windows.Forms.Button();
            this.btnNormalTest = new System.Windows.Forms.Button();
            this.lblHosgeldin = new System.Windows.Forms.Label();
            this.lblOgrenciIsım = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(700, 404);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnSigma
            // 
            this.btnSigma.Location = new System.Drawing.Point(140, 303);
            this.btnSigma.Name = "btnSigma";
            this.btnSigma.Size = new System.Drawing.Size(149, 49);
            this.btnSigma.TabIndex = 4;
            this.btnSigma.Text = "Sigma Testi";
            this.btnSigma.UseVisualStyleBackColor = true;
            this.btnSigma.Click += new System.EventHandler(this.btnSigma_Click);
            // 
            // btnNormalTest
            // 
            this.btnNormalTest.Location = new System.Drawing.Point(406, 303);
            this.btnNormalTest.Name = "btnNormalTest";
            this.btnNormalTest.Size = new System.Drawing.Size(149, 53);
            this.btnNormalTest.TabIndex = 5;
            this.btnNormalTest.Text = "Eksik Giderme Testi";
            this.btnNormalTest.UseVisualStyleBackColor = true;
            this.btnNormalTest.Click += new System.EventHandler(this.btnNormalTest_Click);
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.AutoSize = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(98, 170);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(101, 13);
            this.lblHosgeldin.TabIndex = 6;
            this.lblHosgeldin.Text = "Hoş Geldiniz Sayın :";
            // 
            // lblOgrenciIsım
            // 
            this.lblOgrenciIsım.AutoSize = true;
            this.lblOgrenciIsım.Location = new System.Drawing.Point(123, 204);
            this.lblOgrenciIsım.Name = "lblOgrenciIsım";
            this.lblOgrenciIsım.Size = new System.Drawing.Size(64, 13);
            this.lblOgrenciIsım.TabIndex = 7;
            this.lblOgrenciIsım.Text = "Öğrenci ismi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Uygulamak istediğiniz Test Seçimini Yapınız...";
            // 
            // OgrenciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOgrenciIsım);
            this.Controls.Add(this.lblHosgeldin);
            this.Controls.Add(this.btnNormalTest);
            this.Controls.Add(this.btnSigma);
            this.Controls.Add(this.btnCikis);
            this.Name = "OgrenciForm";
            this.Text = "OgrenciForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OgrenciForm_FormClosing);
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
    }
}