using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace CW_Ekran_Görüntüsü_Aracý
{
    public partial class DikdortgenAlinti : Form
    {

        public bool Sol_Buton_Tik = false;
        public bool Dikdortgen_cizimi = false;
       

        public Point ClickPoint = new Point();
        public Point MvcutTopLeft = new Point();
        public Point MvcutBottomRight = new Point();
        public Point Týk_Baglantisi = new Point();

        public int Dikdortgen_yksk = new int();
        public int Dikdortgen_gnslk = new int();

        Graphics g;
        Pen kalem = new Pen(Color.Red, 2);
        SolidBrush Seffaf_Firca = new SolidBrush(Color.White);
        Pen Silgi = new Pen(Color.Red, 1);
        private AnaForm referans_form = null;
        public AnaForm refForm
        {
            get
            {
                return referans_form;
            }
            set
            {
                referans_form = value;
            }
        }
        public DikdortgenAlinti()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            g = this.CreateGraphics();
        }
        public void Secileni_Kaydet(bool showCursor)
        {
            Point curPos = new Point(Cursor.Position.X - MvcutTopLeft.X, Cursor.Position.Y - MvcutTopLeft.Y);
            Size curSize = new Size();
            curSize.Height = Cursor.Current.Size.Height;
            curSize.Width = Cursor.Current.Size.Width;
            Point StartPoint = new Point(MvcutTopLeft.X, MvcutTopLeft.Y);
            Rectangle bounds = new Rectangle(MvcutTopLeft.X, MvcutTopLeft.Y, MvcutBottomRight.X - MvcutTopLeft.X, MvcutBottomRight.Y - MvcutTopLeft.Y);
            refForm.Goruntuyu_al(showCursor, curSize, curPos, StartPoint, Point.Empty, bounds);
            this.Close();
        }
        private void mouse_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                refForm.Hide();
                Sol_Buton_Tik = true;
                ClickPoint = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
            }
        }
        private void mouse_Up(object sender, MouseEventArgs e)
        {
            Dikdortgen_cizimi = true;
            Sol_Buton_Tik = false;
            if (Dikdortgen_cizimi)
            {
                Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                Týk_Baglantisi.X = Cursor.Position.X - MvcutTopLeft.X;
                Týk_Baglantisi.Y = Cursor.Position.Y - MvcutTopLeft.Y;
                if (Dikdortgen_cizimi && Dikdortgen_gnslk > 0 && Dikdortgen_yksk > 0)
                {
                    this.Refresh();
                    Secileni_Kaydet(false);
                }
                else
                {
                    refForm.Show();
                    this.Close();
                } 
            }
        }
        private void mouse_Move(object sender, MouseEventArgs e)
        {            
            Refresh();
            if (Sol_Buton_Tik && !Dikdortgen_cizimi)
            {
                Secileni_Ciz();
            }
        }
        private void Secileni_Ciz()
        {
            g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, MvcutBottomRight.X - MvcutTopLeft.X, MvcutBottomRight.Y - MvcutTopLeft.Y);
            if (Cursor.Position.X < ClickPoint.X)
            {
                MvcutTopLeft.X = Cursor.Position.X;
                MvcutBottomRight.X = ClickPoint.X;
            }
            else
            {
                MvcutTopLeft.X = ClickPoint.X;
                MvcutBottomRight.X = Cursor.Position.X;
            }
            if (Cursor.Position.Y < ClickPoint.Y)
            {
                MvcutTopLeft.Y = Cursor.Position.Y;
                MvcutBottomRight.Y = ClickPoint.Y;
            }
            else
            {
                MvcutTopLeft.Y = ClickPoint.Y;
                MvcutBottomRight.Y = Cursor.Position.Y;
            }
            g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, MvcutBottomRight.X - MvcutTopLeft.X, MvcutBottomRight.Y - MvcutTopLeft.Y);
        }

        private void DikdortgenAlinti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}