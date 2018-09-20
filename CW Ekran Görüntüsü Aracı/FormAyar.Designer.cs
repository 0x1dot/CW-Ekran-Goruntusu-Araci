namespace CW_Ekran_Görüntüsü_Aracı
{
    partial class FormAyar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAyar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUyar = new System.Windows.Forms.CheckBox();
            this.cbImlec = new System.Windows.Forms.CheckBox();
            this.btnTamam = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUyar);
            this.groupBox1.Controls.Add(this.cbImlec);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seçim";
            // 
            // cbUyar
            // 
            this.cbUyar.AutoSize = true;
            this.cbUyar.Location = new System.Drawing.Point(6, 42);
            this.cbUyar.Name = "cbUyar";
            this.cbUyar.Size = new System.Drawing.Size(250, 17);
            this.cbUyar.TabIndex = 1;
            this.cbUyar.Text = "Çıkmadan önce kaydedilmemiş resim varsa uyar";
            this.cbUyar.UseVisualStyleBackColor = true;
            // 
            // cbImlec
            // 
            this.cbImlec.AutoSize = true;
            this.cbImlec.Location = new System.Drawing.Point(6, 19);
            this.cbImlec.Name = "cbImlec";
            this.cbImlec.Size = new System.Drawing.Size(93, 17);
            this.cbImlec.TabIndex = 0;
            this.cbImlec.Text = "İmleci Dahil Et";
            this.cbImlec.UseVisualStyleBackColor = true;
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(197, 91);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 1;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // FormAyar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 125);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAyar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbImlec;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.CheckBox cbUyar;
    }
}