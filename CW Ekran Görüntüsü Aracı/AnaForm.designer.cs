namespace CW_Ekran_Görüntüsü_Aracý
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cbPanoyaKopyala = new System.Windows.Forms.CheckBox();
            this.cbResimUpload = new System.Windows.Forms.CheckBox();
            this.btnTamEkranAlintisi = new System.Windows.Forms.Button();
            this.btnDikdörtgenAlinti = new System.Windows.Forms.Button();
            this.rcResimUrl = new System.Windows.Forms.RichTextBox();
            this.cmbUploadSite = new System.Windows.Forms.ComboBox();
            this.dDControl = new CW_Ekran_Görüntüsü_Aracý.DDControl();
            this.SuspendLayout();
            // 
            // cbPanoyaKopyala
            // 
            this.cbPanoyaKopyala.AutoSize = true;
            this.cbPanoyaKopyala.Location = new System.Drawing.Point(9, 53);
            this.cbPanoyaKopyala.Name = "cbPanoyaKopyala";
            this.cbPanoyaKopyala.Size = new System.Drawing.Size(103, 17);
            this.cbPanoyaKopyala.TabIndex = 6;
            this.cbPanoyaKopyala.TabStop = false;
            this.cbPanoyaKopyala.Text = "Panoya Kopyala";
            this.cbPanoyaKopyala.UseVisualStyleBackColor = true;
            this.cbPanoyaKopyala.CheckedChanged += new System.EventHandler(this.cbPanoyaKopyala_CheckedChanged);
            this.cbPanoyaKopyala.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbPanoyaKopyala_KeyUp);
            // 
            // cbResimUpload
            // 
            this.cbResimUpload.AutoSize = true;
            this.cbResimUpload.Location = new System.Drawing.Point(113, 53);
            this.cbResimUpload.Name = "cbResimUpload";
            this.cbResimUpload.Size = new System.Drawing.Size(73, 17);
            this.cbResimUpload.TabIndex = 6;
            this.cbResimUpload.TabStop = false;
            this.cbResimUpload.Text = "Upload Et";
            this.cbResimUpload.UseVisualStyleBackColor = true;
            this.cbResimUpload.CheckedChanged += new System.EventHandler(this.cbResimUpload_CheckedChanged);
            this.cbResimUpload.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbPanoyaKopyala_KeyUp);
            // 
            // btnTamEkranAlintisi
            // 
            this.btnTamEkranAlintisi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTamEkranAlintisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamEkranAlintisi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTamEkranAlintisi.Image = ((System.Drawing.Image)(resources.GetObject("btnTamEkranAlintisi.Image")));
            this.btnTamEkranAlintisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTamEkranAlintisi.Location = new System.Drawing.Point(9, 12);
            this.btnTamEkranAlintisi.Name = "btnTamEkranAlintisi";
            this.btnTamEkranAlintisi.Size = new System.Drawing.Size(120, 35);
            this.btnTamEkranAlintisi.TabIndex = 0;
            this.btnTamEkranAlintisi.TabStop = false;
            this.btnTamEkranAlintisi.Text = "Tam Ekran Alýntýsý";
            this.btnTamEkranAlintisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTamEkranAlintisi.UseVisualStyleBackColor = false;
            this.btnTamEkranAlintisi.Click += new System.EventHandler(this.btnTamEkranAlintisi_Click);
            this.btnTamEkranAlintisi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnTamEkranAlintisi_KeyUp);
            // 
            // btnDikdörtgenAlinti
            // 
            this.btnDikdörtgenAlinti.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDikdörtgenAlinti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDikdörtgenAlinti.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDikdörtgenAlinti.Image = ((System.Drawing.Image)(resources.GetObject("btnDikdörtgenAlinti.Image")));
            this.btnDikdörtgenAlinti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDikdörtgenAlinti.Location = new System.Drawing.Point(135, 12);
            this.btnDikdörtgenAlinti.Name = "btnDikdörtgenAlinti";
            this.btnDikdörtgenAlinti.Size = new System.Drawing.Size(183, 35);
            this.btnDikdörtgenAlinti.TabIndex = 2;
            this.btnDikdörtgenAlinti.TabStop = false;
            this.btnDikdörtgenAlinti.Text = "Dikdörtgen Biçimli Ekran Alýntýsý";
            this.btnDikdörtgenAlinti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDikdörtgenAlinti.UseVisualStyleBackColor = false;
            this.btnDikdörtgenAlinti.Click += new System.EventHandler(this.btnDikdörtgenAlinti_Click);
            this.btnDikdörtgenAlinti.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnDikdörtgenAlinti_KeyUp);
            // 
            // rcResimUrl
            // 
            this.rcResimUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rcResimUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rcResimUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rcResimUrl.ForeColor = System.Drawing.Color.White;
            this.rcResimUrl.Location = new System.Drawing.Point(9, 76);
            this.rcResimUrl.Name = "rcResimUrl";
            this.rcResimUrl.Size = new System.Drawing.Size(458, 146);
            this.rcResimUrl.TabIndex = 9;
            this.rcResimUrl.Text = "";
            // 
            // cmbUploadSite
            // 
            this.cmbUploadSite.FormattingEnabled = true;
            this.cmbUploadSite.Items.AddRange(new object[] {
            "hizliresim.com",
            "imguploads.net"});
            this.cmbUploadSite.Location = new System.Drawing.Point(197, 51);
            this.cmbUploadSite.Name = "cmbUploadSite";
            this.cmbUploadSite.Size = new System.Drawing.Size(121, 21);
            this.cmbUploadSite.TabIndex = 11;
            // 
            // dDControl
            // 
            this.dDControl.BackColor = System.Drawing.SystemColors.Control;
            this.dDControl.Location = new System.Drawing.Point(324, 12);
            this.dDControl.Name = "dDControl";
            this.dDControl.Size = new System.Drawing.Size(143, 35);
            this.dDControl.TabIndex = 8;
            this.dDControl.ItemClickedEvent += new CW_Ekran_Görüntüsü_Aracý.ItemClickedDelegate(this.dDControl_ItemClickedEvent);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(476, 74);
            this.Controls.Add(this.cmbUploadSite);
            this.Controls.Add(this.rcResimUrl);
            this.Controls.Add(this.dDControl);
            this.Controls.Add(this.cbResimUpload);
            this.Controls.Add(this.cbPanoyaKopyala);
            this.Controls.Add(this.btnTamEkranAlintisi);
            this.Controls.Add(this.btnDikdörtgenAlinti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaForm";
            this.Text = "CW Ekran Alýntýsý Aracý";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTamEkranAlintisi;
        private System.Windows.Forms.Button btnDikdörtgenAlinti;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox cbPanoyaKopyala;
        private DDControl dDControl;
        private System.Windows.Forms.CheckBox cbResimUpload;
        private System.Windows.Forms.RichTextBox rcResimUrl;
        private System.Windows.Forms.ComboBox cmbUploadSite;
    }
}