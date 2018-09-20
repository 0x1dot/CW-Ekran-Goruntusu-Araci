using CW_Ekran_Görüntüsü_Aracı.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHookLib;

namespace CW_Ekran_Görüntüsü_Aracı
{
    
    public partial class AnaForm : Form
    {
        int secim = 0;
        int gecikme = 0;
        Rectangle rcc;
        bool save;
        static List<byte[]> lst = new List<byte[]>();
        public AnaForm()
        {
            InitializeComponent();
            if (Settings.Default.Location.X <= 0 || Settings.Default.Location.Y <= 0)
                this.Location = new Point(50, 50);
            else
            this.Location = Settings.Default.Location;
            switch (Settings.Default.Mode)
            {
                case 0:
                    secim = 0;
                    teaItem.Checked = true;
                    toolsSecim.Image = Resources.fullresim;
                    break;
                case 1:
                    secim = 1;
                    deaItem.Checked = true;
                    toolsSecim.Image = Resources.seciliekran;
                    break;
                case 2:
                    secim = 2;
                    peaItem.Checked = true;
                    toolsSecim.Image = Resources.winapp;
                    break;
                default:
                    secim = 0;
                    teaItem.Checked = true;
                    toolsSecim.Image = Resources.fullresim;
                    break;
            }
            switch (Settings.Default.Time)
            {
                case 0:
                    gecikme = 0;
                    gecikmeYokToolStripMenuItem.Checked = true;
                    break;
                case 1:
                    gecikme = 1;
                    saniyeToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    gecikme = 2;
                    saniyeToolStripMenuItem1.Checked = true;
                    break;
                case 3:
                    gecikme = 3;
                    saniyeToolStripMenuItem2.Checked = true;
                    break;
                case 4:
                    gecikme = 4;
                    saniyeToolStripMenuItem3.Checked = true;
                    break;
                case 5:
                    gecikme = 5;
                    saniyeToolStripMenuItem4.Checked = true;
                    break;
                default:
                    gecikme = 0;
                    gecikmeYokToolStripMenuItem.Checked = true;
                    break;
            }
        }
        private void ZamanItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in toolsZaman.DropDownItems)
            {
                if (((ToolStripMenuItem)sender).Text == item.Text)
                {
                    item.Checked = true;
                    if (((ToolStripMenuItem)sender).Text == "Gecikme Yok") gecikme = 0;
                    else gecikme = int.Parse(((ToolStripMenuItem)sender).Text.Split(' ')[0]);
                }
                else item.Checked = false;
                Settings.Default.Time = gecikme;
                Settings.Default.Save();
            }
        }
        private void toolsZaman_ButtonClick(object sender, EventArgs e)
        {
            toolsZaman.ShowDropDown();
        }
        private void AnaEkran_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch
            {
            }
            MessageBox.Show("Bu program 0x1dot tarafından Cyber-Warrior.Org ailesi için kodlanmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SecimItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in toolsSecim.DropDownItems)
            {
                if (((ToolStripMenuItem)sender).Text == item.Text)
                {
                    item.Checked = true;
                    switch (((ToolStripMenuItem)sender).Text)
                    {
                        case "Tam Ekran Alıntısı":
                            toolsSecim.Image = Resources.fullresim;
                            secim = 0;
                            Settings.Default.Mode = 0;
                            break;
                        case "Dikdörtgen Biçimli Ekran Alıntısı":
                            toolsSecim.Image = Resources.seciliekran;
                            secim = 1;
                            Settings.Default.Mode = 1;
                            break;
                        case "Pencere Biçimli Ekran Alıntısı":
                            toolsSecim.Image = Resources.winapp;
                            secim = 2;
                            Settings.Default.Mode = 2;
                            break;
                    }
                    Settings.Default.Save();
                }
                else item.Checked = false;
            }
        }
        private void toolsSecim_ButtonClick(object sender, EventArgs e)
        {
            toolsSecim.ShowDropDown();
        }
        private void AnaEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Location = this.Location;
            Settings.Default.Save();
            if (Settings.Default.Uyar && save)
            {
                DialogResult d = MessageBox.Show("Dosya Kaydedilmemiş Kaydetmek istermisiniz?","Bilgi",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    toolsKaydet_Click(sender, e);
                    if(save) e.Cancel = true;
                }
                if (d == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        private void toolsAyarlar_Click(object sender, EventArgs e)
        {
            FormAyar frm = new FormAyar();
            if (frm.ShowDialog() == DialogResult.OK) Settings.Default.Save();
        }
        private void toolsYeni_Click(object sender, EventArgs e)
        {
            save = true;
            switch (secim)
            {
                case 0:
                    this.Hide();
                    if (gecikme > 0)
                    {
                        Thread.Sleep(1000 * gecikme);
                    }
                    else Thread.Sleep(170);
                    GoruntuyuYakala(Settings.Default.imlec,rcc);
                    break;
                case 1:
                    if (gecikme > 0) Thread.Sleep(gecikme * 1000);
                    else Thread.Sleep(170);
                    DikdortgenAlinti dikdortgen_alinti = new DikdortgenAlinti();
                    dikdortgen_alinti.refForm = this;
                    dikdortgen_alinti.Show();
                    dikdortgen_alinti.Focus();
                    break;
                case 2:
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                    if (gecikme > 0) Thread.Sleep(gecikme * 1000);
                    else Thread.Sleep(170);
                    FormAlintisi objForm  = new FormAlintisi();
                    objForm.refForm = this;
                    objForm.Owner = this;
                    objForm.Show();
                    break;
            }
        }
        public void GoruntuyuYakala(bool imlec,Rectangle rc)
        {
            try
            {
                Point imlec_pozisyon = new Point(Cursor.Position.X, Cursor.Position.Y);
                Size imlec_boyut = new Size();
                imlec_boyut.Height = Cursor.Current.Size.Height;
                imlec_boyut.Width = Cursor.Current.Size.Width;
                Rectangle Sinirlar;
                if (rc.Width != 0 && rc.Height != 0 && rc.X != 0 && rc.Y != 0)
                {
                    Bitmap image1 = new Bitmap(rc.Width, rc.Height);
                    Graphics g = Graphics.FromImage(image1);
                    g.CopyFromScreen(new Point(rc.X, rc.Y), Point.Empty, rc.Size);
                    Image image = SCapture.Control(Control.MousePosition, Settings.Default.imlec);
                    imgBox.Image = image1;
                    this.Show();
                    this.WindowState = FormWindowState.Maximized;
                    image.Dispose();
                    Formislemleri();
                }
                else
                {
                     Sinirlar = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                    Goruntuyu_al(imlec, imlec_boyut, imlec_pozisyon, Point.Empty, Point.Empty, Sinirlar);
                    Formislemleri();
                }
                
            }
            catch
            {
            }
        }
        public void Formislemleri()
        {
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 50;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            imgBox.Visible = true;
            toolStripSeparator1.Visible = true;
            toolsYukle.Visible = true;
            toolStripSeparator2.Visible = true;
            toolsKaydet.Visible = true;
            toolsKopyala.Visible = true;
            toolStripSeparator3.Visible = true;
            toolsHakkinda.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Show();
            this.Focus();
        }
        public void Goruntuyu_al(bool showCursor, Size curSize, Point curPos, Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle)
        {
            try
            {
                Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                if (showCursor)
                {
                    Rectangle cursorBounds = new Rectangle(curPos, curSize);
                    Cursors.Default.Draw(g, cursorBounds);
                }
                imgBox.Image = bitmap;
                Formislemleri();
            }
            catch
            {
            }
        }
        private void toolsYukle_ButtonClick(object sender, EventArgs e)
        {
            toolsYukle.ShowDropDown();
        }
        private void toolsKaydet_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = Path.GetRandomFileName() + ".png";
            saveFileDialog1.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|bmp files (*.bmp)|*.bmp";
            saveFileDialog1.Title = "Görüntüyü Kaydet";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fi = new FileInfo(saveFileDialog1.FileName).Extension;
                switch (fi)
                {
                    case ".bmp":
                        imgBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                        break;
                    case ".jpg":
                        imgBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        imgBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Gif);
                        break;
                    case ".tiff":
                        imgBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Tiff);
                        break;
                    case ".png":
                        imgBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        break;
                    default:
                        imgBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        break;
                }
                save = false;
                MessageBox.Show("Dosya başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolsKopyala_Click(object sender, EventArgs e)
        {
            if (!panoyaKopyala(imgBox.Image)) MessageBox.Show("Bilinmeyen bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool panoyaKopyala(Image image)
        {
            try
            {
                Clipboard.SetImage(image);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void toolsHakkinda_Click(object sender, EventArgs e)
        {
            AnaEkran_HelpButtonClicked(sender,null);
        }
        private void hizliResimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lst.Clear();
                lst.Add(Upload.imageToByteArray(imgBox.Image));
                Upload.HizliResimYukle(null, Listele());
            }
            catch
            {
                MessageBox.Show("Hata oluştu, tekrar deneyiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void ımgUploadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            lst.Clear();
            lst.Add(Upload.imageToByteArray(imgBox.Image));
            Upload.imguploadsYukle(null, Listele());
            }
            catch
            {
                MessageBox.Show("Hata oluştu, tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static ListBox Listele()
        {
            ListBox lstbx = new ListBox();
            foreach (byte[] item in lst)
            {
                lstbx.Items.Add(Convert.ToBase64String(item));
            }
            return lstbx;
        }
    }
}
