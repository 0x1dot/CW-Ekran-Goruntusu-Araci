namespace CW_Ekran_Görüntüsü_Aracý
{
    partial class ControlPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveToClipboard = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çýkýþToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkýndaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbupload = new System.Windows.Forms.CheckBox();
            this.bttCaptureScreen = new System.Windows.Forms.Button();
            this.bttCaptureArea = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.dDControl = new CW_Ekran_Görüntüsü_Aracý.DDControl();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveToClipboard
            // 
            this.saveToClipboard.AutoSize = true;
            this.saveToClipboard.Location = new System.Drawing.Point(9, 53);
            this.saveToClipboard.Name = "saveToClipboard";
            this.saveToClipboard.Size = new System.Drawing.Size(98, 17);
            this.saveToClipboard.TabIndex = 6;
            this.saveToClipboard.TabStop = false;
            this.saveToClipboard.Text = "Panoya Kaydet";
            this.saveToClipboard.UseVisualStyleBackColor = true;
            this.saveToClipboard.CheckedChanged += new System.EventHandler(this.saveToClipboard_CheckedChanged);
            this.saveToClipboard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.saveToClipboard_KeyUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gösterToolStripMenuItem,
            this.çýkýþToolStripMenuItem,
            this.hakkýndaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // gösterToolStripMenuItem
            // 
            this.gösterToolStripMenuItem.Name = "gösterToolStripMenuItem";
            this.gösterToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gösterToolStripMenuItem.Text = "Göster";
            this.gösterToolStripMenuItem.Click += new System.EventHandler(this.gösterToolStripMenuItem_Click);
            // 
            // çýkýþToolStripMenuItem
            // 
            this.çýkýþToolStripMenuItem.Name = "çýkýþToolStripMenuItem";
            this.çýkýþToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.çýkýþToolStripMenuItem.Text = "Çýkýþ";
            this.çýkýþToolStripMenuItem.Click += new System.EventHandler(this.çýkýþToolStripMenuItem_Click);
            // 
            // hakkýndaToolStripMenuItem
            // 
            this.hakkýndaToolStripMenuItem.Name = "hakkýndaToolStripMenuItem";
            this.hakkýndaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hakkýndaToolStripMenuItem.Text = "Hakkýnda";
            this.hakkýndaToolStripMenuItem.Click += new System.EventHandler(this.hakkýndaToolStripMenuItem_Click);
            // 
            // cbupload
            // 
            this.cbupload.AutoSize = true;
            this.cbupload.Location = new System.Drawing.Point(113, 53);
            this.cbupload.Name = "cbupload";
            this.cbupload.Size = new System.Drawing.Size(73, 17);
            this.cbupload.TabIndex = 6;
            this.cbupload.TabStop = false;
            this.cbupload.Text = "Upload Et";
            this.cbupload.UseVisualStyleBackColor = true;
            this.cbupload.CheckedChanged += new System.EventHandler(this.cbupload_CheckedChanged);
            this.cbupload.KeyUp += new System.Windows.Forms.KeyEventHandler(this.saveToClipboard_KeyUp);
            // 
            // bttCaptureScreen
            // 
            this.bttCaptureScreen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bttCaptureScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttCaptureScreen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttCaptureScreen.Image = ((System.Drawing.Image)(resources.GetObject("bttCaptureScreen.Image")));
            this.bttCaptureScreen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttCaptureScreen.Location = new System.Drawing.Point(9, 12);
            this.bttCaptureScreen.Name = "bttCaptureScreen";
            this.bttCaptureScreen.Size = new System.Drawing.Size(120, 35);
            this.bttCaptureScreen.TabIndex = 0;
            this.bttCaptureScreen.TabStop = false;
            this.bttCaptureScreen.Text = "Tam Ekran Alýntýsý";
            this.bttCaptureScreen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttCaptureScreen.UseVisualStyleBackColor = false;
            this.bttCaptureScreen.Click += new System.EventHandler(this.bttCaptureScreen_Click);
            this.bttCaptureScreen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bttCaptureScreen_KeyUp);
            // 
            // bttCaptureArea
            // 
            this.bttCaptureArea.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bttCaptureArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttCaptureArea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttCaptureArea.Image = ((System.Drawing.Image)(resources.GetObject("bttCaptureArea.Image")));
            this.bttCaptureArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttCaptureArea.Location = new System.Drawing.Point(135, 12);
            this.bttCaptureArea.Name = "bttCaptureArea";
            this.bttCaptureArea.Size = new System.Drawing.Size(183, 35);
            this.bttCaptureArea.TabIndex = 2;
            this.bttCaptureArea.TabStop = false;
            this.bttCaptureArea.Text = "Dikdörtgen Biçimli Ekran Alýntýsý";
            this.bttCaptureArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttCaptureArea.UseVisualStyleBackColor = false;
            this.bttCaptureArea.Click += new System.EventHandler(this.bttCaptureArea_Click);
            this.bttCaptureArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bttCaptureArea_KeyUp);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(9, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(458, 146);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CW Ekran Görüntüsü Aracý";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cmbSite
            // 
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Items.AddRange(new object[] {
            "hizliresim.com",
            "imguploads.net"});
            this.cmbSite.Location = new System.Drawing.Point(197, 51);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(121, 21);
            this.cmbSite.TabIndex = 11;
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
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(476, 74);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dDControl);
            this.Controls.Add(this.cbupload);
            this.Controls.Add(this.saveToClipboard);
            this.Controls.Add(this.bttCaptureScreen);
            this.Controls.Add(this.bttCaptureArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlPanel";
            this.Text = "CW Ekran Alýntýsý Aracý";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttCaptureScreen;
        private System.Windows.Forms.Button bttCaptureArea;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox saveToClipboard;
        private DDControl dDControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox cbupload;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem gösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çýkýþToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkýndaToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbSite;
    }
}