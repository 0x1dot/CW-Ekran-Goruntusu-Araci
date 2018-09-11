using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using CW_Ekran_Görüntüsü_Aracý.Properties;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace CW_Ekran_Görüntüsü_Aracý
{
    public partial class AnaForm : Form
    {
        static int gecikme = 0;
        string Yol;
        public AnaForm()
        {
            InitializeComponent();
        }
        public void key_press(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        private void keyTest(KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "S")
            {

                GontuyuYakala(true);

            }

        }
        private void btnDikdörtgenAlinti_Click(object sender, EventArgs e)
        {
           if(gecikme > 0) Thread.Sleep(gecikme*1000);
            this.Hide();
            EkranAlintisiKýrp form1 = new EkranAlintisiKýrp(gecikme,cbResimUpload.Checked,cmbUploadSite.SelectedIndex);
            form1.InstanceRef = this;
            form1.Show();
            form1.Focus();
        }
        public void GontuyuYakala(bool imlec)
        {
            try
            {
                Point imlec_pozisyon = new Point(Cursor.Position.X, Cursor.Position.Y);
                Size imlec_boyut = new Size();
                imlec_boyut.Height = Cursor.Current.Size.Height;
                imlec_boyut.Width = Cursor.Current.Size.Width;

                Yol = "";

                if (!EkranGoruntusu.panoya_kopyala)
                {
                    saveFileDialog1.DefaultExt = "png";
                    saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveFileDialog1.FileName = Path.GetRandomFileName() + ".png";
                    saveFileDialog1.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|bmp files (*.bmp)|*.bmp";
                    saveFileDialog1.Title = "Save screenshot to...";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        Yol = saveFileDialog1.FileName;
                }
                if (Yol != "" || EkranGoruntusu.panoya_kopyala)
                {

                    //Conceal this form while the screen capture takes place
                    this.Hide();
                    this.TopMost = false;

                    //Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
                    if (gecikme > 0)
                    {
                        Thread.Sleep(1000 * gecikme);
                    }
                    else Thread.Sleep(250);

                    Rectangle Sinirlar = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                    string fi = "";

                    if (Yol != "")
                    {

                        fi = new FileInfo(Yol).Extension;

                    }

                    EkranGoruntusu.Goruntuyu_al(imlec, imlec_boyut, imlec_pozisyon, Point.Empty, Point.Empty, Sinirlar, Yol, fi,cbResimUpload.Checked,cmbUploadSite.SelectedIndex);

                    //The screen has been captured and saved to a file so bring this form back into the foreground
                    this.Show();
                    this.TopMost = true;
                }
            }
            catch
            {
                this.Show();
                this.TopMost = true;
            }
           
        }
        private void btnTamEkranAlintisi_Click(object sender, EventArgs e)
        {
            GontuyuYakala(false);
        }
        private void FillItemList()
        {
            List<string> lstSting = new List<string>();
            for (int i = 0; i <= 6; i++)
            {
                if (i==0) lstSting.Add("Gecikme Yok");
                else lstSting.Add(i.ToString()+" Saniye");
            }
            dDControl.FillControlList(lstSting);
        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
            cmbUploadSite.SelectedItem = Settings.Default.cmbSite;
            cbResimUpload.Checked = Settings.Default.upload;
            if (cbResimUpload.Checked) cmbUploadSite.Visible = true;
            else cmbUploadSite.Visible = false;
            cbPanoyaKopyala.Checked = Settings.Default.clipboard;
            this.KeyUp += new KeyEventHandler(key_press);
            FillItemList();
        }
        void dDControl_ItemClickedEvent(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Gecikme Yok") gecikme = int.Parse(e.ClickedItem.Text.Split(' ')[0]);
        }
        private void cbPanoyaKopyala_CheckedChanged(object sender, EventArgs e)
        {
            EkranGoruntusu.panoya_kopyala = cbPanoyaKopyala.Checked;
        }
        private void cbPanoyaKopyala_KeyUp(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        private void btnDikdörtgenAlinti_KeyUp(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        private void btnTamEkranAlintisi_KeyUp(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        public List<string> responselist = new List<string>();
        public void ResponseCek(string response)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            rcResimUrl.Text = string.Empty;
            string regex = "<a href=\"(.+?)\"><i class=\"material-icons\">&#xE157;</i></a>";
            MatchCollection mt = Regex.Matches(response, regex);
            foreach (Match item in mt)
            {
                if (item.Groups[1].ToString().Contains("i.hizliresim"))
                {
                    if (rcResimUrl.InvokeRequired)
                    {
                        rcResimUrl.Invoke(new Action(delegate ()
                        {
                            rcResimUrl.Text += item.Groups[1].ToString() + "\n";
                        }));
                    }                   
                }
            }
        }
        public void JsonCek(string response)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            rcResimUrl.Text = string.Empty;
            dynamic stuff = JObject.Parse(response);
            if (stuff.status_code == "200")
            {
                if (rcResimUrl.InvokeRequired)
                {
                    rcResimUrl.Invoke(new Action(delegate ()
                    {
                        rcResimUrl.Text = stuff.image.image.url+"\n";
                    }));
                }
                MessageBox.Show("Dosya yükleme iþlemi tamamlandý", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ýþllem Baþarýsýz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cbResimUpload_CheckedChanged(object sender, EventArgs e)
        {
            if (cbResimUpload.Checked)
            {
                rcResimUrl.Visible = true;
                cmbUploadSite.Visible = true;
                this.Height = 270;
            }
            else
            {
                rcResimUrl.Visible = false;
                cmbUploadSite.Visible = false;
                this.Height = 113;
            }
        }
        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Çýkmak istediðinize emin misiniz?", "Bilgi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            Settings.Default.cmbSite = cmbUploadSite.SelectedItem.ToString();
            Settings.Default.upload = cbResimUpload.Checked;
            Settings.Default.clipboard = cbPanoyaKopyala.Checked;
            Settings.Default.Save();
            if (d == DialogResult.Yes) Application.ExitThread();
            else e.Cancel = true;
        }
    }
}