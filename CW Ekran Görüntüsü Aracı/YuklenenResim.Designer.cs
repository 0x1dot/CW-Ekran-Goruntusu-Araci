namespace CW_Ekran_Görüntüsü_Aracı
{
    partial class YuklenenResim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YuklenenResim));
            this.rcResimUrl = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rcResimUrl
            // 
            this.rcResimUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rcResimUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rcResimUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcResimUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rcResimUrl.Location = new System.Drawing.Point(0, 0);
            this.rcResimUrl.Name = "rcResimUrl";
            this.rcResimUrl.ReadOnly = true;
            this.rcResimUrl.Size = new System.Drawing.Size(284, 261);
            this.rcResimUrl.TabIndex = 0;
            this.rcResimUrl.Text = "";
            // 
            // YuklenenResim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rcResimUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YuklenenResim";
            this.Text = "Yüklenen Resimler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rcResimUrl;
    }
}