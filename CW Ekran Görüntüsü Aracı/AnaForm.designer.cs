using CW_Ekran_Görüntüsü_Aracı.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CW_Ekran_Görüntüsü_Aracı
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolsYeni = new System.Windows.Forms.ToolStripButton();
            this.toolsSecim = new System.Windows.Forms.ToolStripSplitButton();
            this.teaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsZaman = new System.Windows.Forms.ToolStripSplitButton();
            this.gecikmeYokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsAyarlar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsYukle = new System.Windows.Forms.ToolStripSplitButton();
            this.hizliResimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ımgUploadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolsKopyala = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsHakkinda = new System.Windows.Forms.ToolStripButton();
            this.imgBox = new Cyotek.Windows.Forms.ImageBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsYeni,
            this.toolsSecim,
            this.toolsZaman,
            this.toolsAyarlar,
            this.toolStripSeparator1,
            this.toolsYukle,
            this.toolStripSeparator2,
            this.toolsKaydet,
            this.toolsKopyala,
            this.toolStripSeparator3,
            this.toolsHakkinda});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(372, 47);
            this.toolStrip1.TabIndex = 4;
            // 
            // toolsYeni
            // 
            this.toolsYeni.Image = ((System.Drawing.Image)(resources.GetObject("toolsYeni.Image")));
            this.toolsYeni.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsYeni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsYeni.Name = "toolsYeni";
            this.toolsYeni.Size = new System.Drawing.Size(73, 44);
            this.toolsYeni.Text = "Yeni";
            this.toolsYeni.Click += new System.EventHandler(this.toolsYeni_Click);
            // 
            // toolsSecim
            // 
            this.toolsSecim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teaItem,
            this.deaItem,
            this.peaItem});
            this.toolsSecim.Image = ((System.Drawing.Image)(resources.GetObject("toolsSecim.Image")));
            this.toolsSecim.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsSecim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsSecim.Name = "toolsSecim";
            this.toolsSecim.Size = new System.Drawing.Size(88, 44);
            this.toolsSecim.Tag = "";
            this.toolsSecim.Text = "Mod";
            this.toolsSecim.ToolTipText = "Ekran Alıntısı Modu";
            this.toolsSecim.Click += new System.EventHandler(this.toolsSecim_ButtonClick);
            // 
            // teaItem
            // 
            this.teaItem.Name = "teaItem";
            this.teaItem.Size = new System.Drawing.Size(243, 22);
            this.teaItem.Text = "Tam Ekran Alıntısı";
            this.teaItem.Click += new System.EventHandler(this.SecimItem_Click);
            // 
            // deaItem
            // 
            this.deaItem.Name = "deaItem";
            this.deaItem.Size = new System.Drawing.Size(243, 22);
            this.deaItem.Text = "Dikdörtgen Biçimli Ekran Alıntısı";
            this.deaItem.Click += new System.EventHandler(this.SecimItem_Click);
            // 
            // peaItem
            // 
            this.peaItem.Name = "peaItem";
            this.peaItem.Size = new System.Drawing.Size(243, 22);
            this.peaItem.Text = "Pencere Biçimli Ekran Alıntısı";
            this.peaItem.Click += new System.EventHandler(this.SecimItem_Click);
            // 
            // toolsZaman
            // 
            this.toolsZaman.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gecikmeYokToolStripMenuItem,
            this.saniyeToolStripMenuItem,
            this.saniyeToolStripMenuItem1,
            this.saniyeToolStripMenuItem2,
            this.saniyeToolStripMenuItem3,
            this.saniyeToolStripMenuItem4});
            this.toolsZaman.Image = ((System.Drawing.Image)(resources.GetObject("toolsZaman.Image")));
            this.toolsZaman.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsZaman.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsZaman.Name = "toolsZaman";
            this.toolsZaman.Size = new System.Drawing.Size(103, 44);
            this.toolsZaman.Text = "Geciktir";
            this.toolsZaman.Click += new System.EventHandler(this.toolsZaman_ButtonClick);
            // 
            // gecikmeYokToolStripMenuItem
            // 
            this.gecikmeYokToolStripMenuItem.Name = "gecikmeYokToolStripMenuItem";
            this.gecikmeYokToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.gecikmeYokToolStripMenuItem.Text = "Gecikme Yok";
            this.gecikmeYokToolStripMenuItem.Click += new System.EventHandler(this.ZamanItem_Click);
            // 
            // saniyeToolStripMenuItem
            // 
            this.saniyeToolStripMenuItem.Name = "saniyeToolStripMenuItem";
            this.saniyeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saniyeToolStripMenuItem.Text = "1 Saniye";
            this.saniyeToolStripMenuItem.Click += new System.EventHandler(this.ZamanItem_Click);
            // 
            // saniyeToolStripMenuItem1
            // 
            this.saniyeToolStripMenuItem1.Name = "saniyeToolStripMenuItem1";
            this.saniyeToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.saniyeToolStripMenuItem1.Text = "2 Saniye";
            this.saniyeToolStripMenuItem1.Click += new System.EventHandler(this.ZamanItem_Click);
            // 
            // saniyeToolStripMenuItem2
            // 
            this.saniyeToolStripMenuItem2.Name = "saniyeToolStripMenuItem2";
            this.saniyeToolStripMenuItem2.Size = new System.Drawing.Size(142, 22);
            this.saniyeToolStripMenuItem2.Text = "3 Saniye";
            this.saniyeToolStripMenuItem2.Click += new System.EventHandler(this.ZamanItem_Click);
            // 
            // saniyeToolStripMenuItem3
            // 
            this.saniyeToolStripMenuItem3.Name = "saniyeToolStripMenuItem3";
            this.saniyeToolStripMenuItem3.Size = new System.Drawing.Size(142, 22);
            this.saniyeToolStripMenuItem3.Text = "4 Saniye";
            this.saniyeToolStripMenuItem3.Click += new System.EventHandler(this.ZamanItem_Click);
            // 
            // saniyeToolStripMenuItem4
            // 
            this.saniyeToolStripMenuItem4.Name = "saniyeToolStripMenuItem4";
            this.saniyeToolStripMenuItem4.Size = new System.Drawing.Size(142, 22);
            this.saniyeToolStripMenuItem4.Text = "5 Saniye";
            this.saniyeToolStripMenuItem4.Click += new System.EventHandler(this.ZamanItem_Click);
            // 
            // toolsAyarlar
            // 
            this.toolsAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("toolsAyarlar.Image")));
            this.toolsAyarlar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsAyarlar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsAyarlar.Name = "toolsAyarlar";
            this.toolsAyarlar.Size = new System.Drawing.Size(107, 44);
            this.toolsAyarlar.Text = "Seçenekler";
            this.toolsAyarlar.Click += new System.EventHandler(this.toolsAyarlar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolsYukle
            // 
            this.toolsYukle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hizliResimToolStripMenuItem,
            this.ımgUploadsToolStripMenuItem});
            this.toolsYukle.Image = global::CW_Ekran_Görüntüsü_Aracı.Properties.Resources.yukle;
            this.toolsYukle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsYukle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsYukle.Name = "toolsYukle";
            this.toolsYukle.Size = new System.Drawing.Size(92, 44);
            this.toolsYukle.Tag = "";
            this.toolsYukle.Text = "Yükle";
            this.toolsYukle.ToolTipText = "İnternet\'e Yükle";
            this.toolsYukle.Visible = false;
            this.toolsYukle.ButtonClick += new System.EventHandler(this.toolsYukle_ButtonClick);
            // 
            // hizliResimToolStripMenuItem
            // 
            this.hizliResimToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hizliResimToolStripMenuItem.Image")));
            this.hizliResimToolStripMenuItem.Name = "hizliResimToolStripMenuItem";
            this.hizliResimToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.hizliResimToolStripMenuItem.Text = "Hizli Resim";
            this.hizliResimToolStripMenuItem.Click += new System.EventHandler(this.hizliResimToolStripMenuItem_Click);
            // 
            // ımgUploadsToolStripMenuItem
            // 
            this.ımgUploadsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ımgUploadsToolStripMenuItem.Image")));
            this.ımgUploadsToolStripMenuItem.Name = "ımgUploadsToolStripMenuItem";
            this.ımgUploadsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ımgUploadsToolStripMenuItem.Text = "Img Uploads";
            this.ımgUploadsToolStripMenuItem.Click += new System.EventHandler(this.ımgUploadsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolsKaydet
            // 
            this.toolsKaydet.Image = global::CW_Ekran_Görüntüsü_Aracı.Properties.Resources.kaydet;
            this.toolsKaydet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsKaydet.Name = "toolsKaydet";
            this.toolsKaydet.Size = new System.Drawing.Size(87, 44);
            this.toolsKaydet.Text = "Kaydet";
            this.toolsKaydet.Visible = false;
            this.toolsKaydet.Click += new System.EventHandler(this.toolsKaydet_Click);
            // 
            // toolsKopyala
            // 
            this.toolsKopyala.Image = global::CW_Ekran_Görüntüsü_Aracı.Properties.Resources.kopyala;
            this.toolsKopyala.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsKopyala.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsKopyala.Name = "toolsKopyala";
            this.toolsKopyala.Size = new System.Drawing.Size(143, 52);
            this.toolsKopyala.Text = "Panoya Kopyala";
            this.toolsKopyala.Visible = false;
            this.toolsKopyala.Click += new System.EventHandler(this.toolsKopyala_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            this.toolStripSeparator3.Visible = false;
            // 
            // toolsHakkinda
            // 
            this.toolsHakkinda.Image = global::CW_Ekran_Görüntüsü_Aracı.Properties.Resources.information;
            this.toolsHakkinda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsHakkinda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsHakkinda.Name = "toolsHakkinda";
            this.toolsHakkinda.Size = new System.Drawing.Size(101, 44);
            this.toolsHakkinda.Text = "Hakkında";
            this.toolsHakkinda.Visible = false;
            this.toolsHakkinda.Click += new System.EventHandler(this.toolsHakkinda_Click);
            // 
            // imgBox
            // 
            this.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.imgBox.Location = new System.Drawing.Point(0, 47);
            this.imgBox.Name = "imgBox";
            this.imgBox.ShowPixelGrid = true;
            this.imgBox.Size = new System.Drawing.Size(372, 0);
            this.imgBox.TabIndex = 5;
            this.imgBox.Visible = false;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(372, 47);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.toolStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ekran Alıntısı Aracı";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.AnaEkran_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaEkran_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        public ToolStrip toolStrip1;
        public ToolStripButton toolsYeni;
        private ToolStripSplitButton toolsSecim;
        private ToolStripMenuItem teaItem;
        private ToolStripMenuItem deaItem;
        private ToolStripSplitButton toolsZaman;
        private ToolStripMenuItem gecikmeYokToolStripMenuItem;
        private ToolStripMenuItem saniyeToolStripMenuItem;
        private ToolStripMenuItem saniyeToolStripMenuItem1;
        private ToolStripMenuItem saniyeToolStripMenuItem2;
        private ToolStripMenuItem saniyeToolStripMenuItem3;
        private ToolStripMenuItem saniyeToolStripMenuItem4;
        private ToolStripButton toolsAyarlar;
        private Cyotek.Windows.Forms.ImageBox imgBox;
        private ToolStripSplitButton toolsYukle;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolsKaydet;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolsHakkinda;
        private ToolStripMenuItem hizliResimToolStripMenuItem;
        private ToolStripMenuItem ımgUploadsToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripButton toolsKopyala;
        public ToolStripMenuItem peaItem;
    }
}