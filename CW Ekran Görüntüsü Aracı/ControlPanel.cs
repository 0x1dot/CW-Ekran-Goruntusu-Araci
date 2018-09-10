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
    public partial class ControlPanel : Form
    {
        static int gecikme = 0;
        string ScreenPath;
        private Form m_InstanceRef = null;
        public Form InstanceRef
        {
            get
            {
                return m_InstanceRef;
            }
            set
            {
                m_InstanceRef = value;
            }
        }
        public ControlPanel()
        {
            InitializeComponent();
        }

        public ControlPanel(bool Save)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form_Close);
        }
        public void key_press(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }
        private void keyTest(KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "S")
            {

                screenCapture(true);

            }

        }
        private void Form_Close(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }
        private void bttCaptureArea_Click(object sender, EventArgs e)
        {
           if(gecikme > 0) Thread.Sleep(gecikme*1000);
            this.Hide();
            Form1 form1 = new Form1(gecikme,cbupload.Checked,cmbSite.SelectedIndex);
            form1.InstanceRef = this;
            form1.Show();
            form1.Focus();
        }
        public void screenCapture(bool showCursor)
        {
            try
            {
                Point curPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                Size curSize = new Size();
                curSize.Height = Cursor.Current.Size.Height;
                curSize.Width = Cursor.Current.Size.Width;

                ScreenPath = "";

                if (!ScreenShot.saveToClipboard)
                {
                    saveFileDialog1.DefaultExt = "png";
                    saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveFileDialog1.FileName = Path.GetRandomFileName() + ".png";
                    saveFileDialog1.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|bmp files (*.bmp)|*.bmp";
                    saveFileDialog1.Title = "Save screenshot to...";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        ScreenPath = saveFileDialog1.FileName;
                }
                if (ScreenPath != "" || ScreenShot.saveToClipboard)
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

                    Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                    string fi = "";

                    if (ScreenPath != "")
                    {

                        fi = new FileInfo(ScreenPath).Extension;

                    }

                    ScreenShot.CaptureImage(showCursor, curSize, curPos, Point.Empty, Point.Empty, bounds, ScreenPath, fi,cbupload.Checked,cmbSite.SelectedIndex);

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
        private void bttCaptureScreen_Click(object sender, EventArgs e)
        {
            screenCapture(false);
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
        private void ControlPanel_Load(object sender, EventArgs e)
        {
            cmbSite.SelectedItem = Settings.Default.cmbSite;
            cbupload.Checked = Settings.Default.upload;
            if (cbupload.Checked) cmbSite.Visible = true;
            else cmbSite.Visible = false;
            saveToClipboard.Checked = Settings.Default.clipboard;
            this.KeyUp += new KeyEventHandler(key_press);
            FillItemList();
        }
        void dDControl_ItemClickedEvent(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Gecikme Yok") gecikme = int.Parse(e.ClickedItem.Text.Split(' ')[0]);
        }
        private void saveToClipboard_CheckedChanged(object sender, EventArgs e)
        {
            ScreenShot.saveToClipboard = saveToClipboard.Checked;
        }
        private void saveToClipboard_KeyUp(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        private void bttCaptureArea_KeyUp(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        private void bttCaptureScreen_KeyUp(object sender, KeyEventArgs e)
        {
            keyTest(e);
        }
        public List<string> responselist = new List<string>();
        public void ResponseCek(string response)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            richTextBox1.Text = string.Empty;
            string regex = "<a href=\"(.+?)\"><i class=\"material-icons\">&#xE157;</i></a>";
            MatchCollection mt = Regex.Matches(response, regex);
            foreach (Match item in mt)
            {
                if (item.Groups[1].ToString().Contains("i.hizliresim"))
                {
                    if (richTextBox1.InvokeRequired)
                    {
                        richTextBox1.Invoke(new Action(delegate ()
                        {
                            richTextBox1.Text += item.Groups[1].ToString() + "\n";
                        }));
                    }                   
                }
            }
        }
        JavaScriptSerializer j = new JavaScriptSerializer();
        public void JsonCek(string response)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            richTextBox1.Text = string.Empty;
            dynamic stuff = JObject.Parse(response);
            if (stuff.status_code == "200")
            {
                if (richTextBox1.InvokeRequired)
                {
                    richTextBox1.Invoke(new Action(delegate ()
                    {
                        richTextBox1.Text = stuff.image.image.url+"\n";
                    }));
                }
                MessageBox.Show("Dosya yükleme iþlemi tamamlandý", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ýþllem Baþarýsýz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cbupload_CheckedChanged(object sender, EventArgs e)
        {
            if (cbupload.Checked)
            {
                richTextBox1.Visible = true;
                cmbSite.Visible = true;
                this.Height = 270;
            }
            else
            {
                richTextBox1.Visible = false;
                cmbSite.Visible = false;
                this.Height = 113;
            }
        }
        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            Settings.Default.cmbSite = cmbSite.SelectedItem.ToString();
            Settings.Default.upload = cbupload.Checked;
            Settings.Default.clipboard = saveToClipboard.Checked;
            Settings.Default.Save();
        }
        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        private void çýkýþToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Çýkmak istediðinize emin misiniz?","Bilgi",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
            if (d==DialogResult.Yes) Application.ExitThread();
        }

        private void hakkýndaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program 0x1dot tarafýndan Cyber-Warrior.Org için kodlanmýþtýr. Ýyi günlerde kullanýn.");
        }
    }
}