using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CW_Ekran_Görüntüsü_Aracı
{
    public partial class YuklenenResim : Form
    {
        public YuklenenResim()
        {
            InitializeComponent();
        }
        public void ResponseCek(string response)
        {
            string regex = "<a href=\"(.+?)\"><i class=\"material-icons\">&#xE157;</i></a>";
            MatchCollection mt = Regex.Matches(response, regex);
            foreach (Match item in mt)
            {
                if (item.Groups[1].ToString().Contains("i.hizliresim"))
                {
                    MenuItem lst = new MenuItem();
                            listBox1.Items.Add(item.Groups[1].ToString());
                }
            }
        }
        public void JsonCek(string response)
        {
            dynamic stuff = JObject.Parse(response);
            if (stuff.status_code == "200")
            {
                listBox1.Items.Add(stuff.image.image.url);
                MessageBox.Show("Dosya yükleme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İşllem Başarısız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkiKopyalaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string copy = listBox1.SelectedItem.ToString();
                Clipboard.SetText(copy);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(listBox1.SelectedItem.ToString());


                lxRequest.Method = "GET";
                lxRequest.Accept = "image/png,image/*";
                lxRequest.KeepAlive = false;
                var resp = lxRequest.GetResponse();
                var respStream = resp.GetResponseStream();
                var contentLen = resp.ContentLength;
                using (var tempMemStream = new MemoryStream())
                {
                    byte[] buffer = new byte[512];
                    int read;

                    while ((read = respStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        tempMemStream.Write(buffer, 0, read);
                    }
                    imgBox.Image = Image.FromStream(tempMemStream);
                }
                
                // pictureBox1.Image = new Bitmap(new MemoryStream(outData));



                //String lsResponse = string.Empty;
                //HttpWebResponse lxResponse = (HttpWebResponse)lxRequest.GetResponse();
                //using (StreamReader lxResponseStream = new StreamReader(lxResponse.GetResponseStream()))
                //{
                //    lsResponse = lxResponseStream.ReadToEnd();
                //    lxResponseStream.Close();
                //}
                //MemoryStream ms = new MemoryStream();
                //byte[] lnByte = Encoding.UTF8.GetBytes(lsResponse);
                ////ms.Write(lnByte,0,lnByte.Length);

            }
            catch
            {
                MessageBox.Show("Hata oluştu","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void YuklenenResim_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
