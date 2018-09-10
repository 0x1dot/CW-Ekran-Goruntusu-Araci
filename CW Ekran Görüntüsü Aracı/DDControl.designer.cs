namespace CW_Ekran_Görüntüsü_Aracı {
    partial class DDControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnDropDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDropDown
            // 
            this.btnDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropDown.Location = new System.Drawing.Point(0, 0);
            this.btnDropDown.Name = "btnDropDown";
            this.btnDropDown.Size = new System.Drawing.Size(122, 24);
            this.btnDropDown.TabIndex = 0;
            this.btnDropDown.UseVisualStyleBackColor = true;
            this.btnDropDown.Click += new System.EventHandler(this.btnDropDown_Click);
            // 
            // DDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDropDown);
            this.Name = "DDControl";
            this.Size = new System.Drawing.Size(122, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDropDown;
    }
}
