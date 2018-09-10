using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CW_Ekran_Görüntüsü_Aracı.Properties;

namespace CW_Ekran_Görüntüsü_Aracı {

    public delegate void ItemClickedDelegate(object sender, ToolStripItemClickedEventArgs e);

    public partial class DDControl : UserControl {

        public event ItemClickedDelegate ItemClickedEvent;

        #region Members

        public List<string> LstOfValues = new List<string>();

        #endregion

        #region Constructors

        public DDControl() {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void FillControlList(List<string> lst) {
           if(lst.Count > 0) btnDropDown.Text = lst[0];
            LstOfValues = lst;
            SetMyButtonProperties();
        }

        private void ShowDropDown() {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            //get the path of the image
            string imgPath = GetFilePath();
            //adding contextMenuStrip items acconrding to LstOfValues count
            for (int i = 0; i < LstOfValues.Count - 1; i++) {
                //add the item
                contextMenuStrip.Items.Add(LstOfValues[i]);
                //add the image
                if (File.Exists(imgPath + @"icon" + i + ".bmp")) {
                    contextMenuStrip.Items[i].Image = Image.FromFile(imgPath + @"icon" + i + ".bmp");
                }
            }
            //adding ItemClicked event to contextMenuStrip
            contextMenuStrip.ItemClicked += contextMenuStrip_ItemClicked;
            //show menu strip control
            contextMenuStrip.Show(btnDropDown, new Point(0, btnDropDown.Height));
        }

        private void SetMyButtonProperties() {
            // Assign an image to the button.
            btnDropDown.Image = Resources.arrow;
            // Align the image right of the button
            btnDropDown.ImageAlign = ContentAlignment.MiddleRight;
            //Align the text left of the button.
            btnDropDown.TextAlign = ContentAlignment.MiddleLeft;
        }

        private string GetFilePath() {
            //string path = string.Empty;
            //foreach (string value in Application.StartupPath.Split('\\')) {
            //    if (value == "bin") {
            //        break;
            //    }
            //    path += value + "\\";
            //}
            //return path;
            string value = Application.StartupPath.Substring(Application.StartupPath.IndexOf(@"bin", System.StringComparison.Ordinal));
            return Application.StartupPath.Replace(value, string.Empty);

        }


        #endregion

        #region Events

        private void btnDropDown_Click(object sender, EventArgs e) {
            try {
                ShowDropDown();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            try {
                ToolStripItem item = e.ClickedItem;
                //set the text of the button
                btnDropDown.Text = item.Text;
                if (ItemClickedEvent != null) {
                    ItemClickedEvent(sender, e);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
