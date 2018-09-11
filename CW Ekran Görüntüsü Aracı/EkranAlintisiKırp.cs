using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace CW_Ekran_Görüntüsü_Aracý
{


    public partial class EkranAlintisiKýrp : Form
    {

        public enum imlec_pzsyn : int
        {

            WithinSelectionArea = 0,
            OutsideSelectionArea,
            TopLine,
            BottomLine,
            LeftLine,
            RightLine,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight

        }

        public enum Eylemler : int
        {

            NoClick = 0,
            Dragging,
            Outside,
            TopSizing,
            BottomSizing,
            LeftSizing,
            TopLeftSizing,
            BottomLeftSizing,
            RightSizing,
            TopRightSizing,
            BottomRightSizing

        }

        public Eylemler MevcutEylem;
        public bool Sol_Buton_Tik = false;
        public bool Dikdortgen_cizimi = false;
        public bool Surukle = false;
        string Ekran_Yol;

        public Point ClickPoint = new Point();
        public Point MvcutTopLeft = new Point();
        public Point MvcutBottomRight = new Point();
        public Point Týk_Baglantisi = new Point();

        public int Dikdortgen_yksk = new int();
        public int Dikdortgen_gnslk = new int();

        Graphics g;
        Pen kalem = new Pen(Color.Black, 1);
        SolidBrush Seffaf_Firca = new SolidBrush(Color.White);
        Pen Silgi = new Pen(Color.FromArgb(255, 255, 192), 1);
        SolidBrush Silgi_Fircasi = new SolidBrush(Color.FromArgb(255, 255, 192));

        protected override void OnMouseClick(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                e = null;

            }

            base.OnMouseClick(e);

        }

        private Form referans_form = null;
        public Form InstanceRef
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

        int gecikme = 0;
        bool upload = false;
        int siteindex = 0;
        public EkranAlintisiKýrp(int gecikme,bool upload,int index)
        {
            this.siteindex = index;
            this.gecikme = gecikme;
            this.upload = upload;
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            this.KeyUp += new KeyEventHandler(key_press);
            g = this.CreateGraphics();
        }




        public void Secileni_Kaydet(bool showCursor)
        {

            Point curPos = new Point(Cursor.Position.X - MvcutTopLeft.X, Cursor.Position.Y - MvcutTopLeft.Y);
            Size curSize = new Size();
            curSize.Height = Cursor.Current.Size.Height;
            curSize.Width = Cursor.Current.Size.Width;

            Ekran_Yol = "";

            if (!EkranGoruntusu.panoya_kopyala)
            {

                saveFileDialog1.DefaultExt = "png";
                saveFileDialog1.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|bmp files (*.bmp)|*.bmp";
                saveFileDialog1.Title = "Save screenshot to...";
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                Ekran_Yol = saveFileDialog1.FileName;
            }


            if (Ekran_Yol != "" || EkranGoruntusu.panoya_kopyala)
            {

                //Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
                if(gecikme > 0) Thread.Sleep(gecikme*1000);
                else Thread.Sleep(250);
                Point StartPoint = new Point(MvcutTopLeft.X, MvcutTopLeft.Y);
                Rectangle bounds = new Rectangle(MvcutTopLeft.X, MvcutTopLeft.Y, MvcutBottomRight.X - MvcutTopLeft.X, MvcutBottomRight.Y - MvcutTopLeft.Y);
                string fi = "";

                if (Ekran_Yol != "")
                {

                    fi = new FileInfo(Ekran_Yol).Extension;

                }

                EkranGoruntusu.Goruntuyu_al(showCursor, curSize, curPos, StartPoint, Point.Empty, bounds, Ekran_Yol, fi,upload,siteindex);
                this.InstanceRef.Show();
                this.Close();
            }

            else
            {
                this.InstanceRef.Show();
                this.Close();
            }
        }

        public void key_press(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "S" && (Dikdortgen_cizimi && (imlec_pozisyon() == imlec_pzsyn.WithinSelectionArea || imlec_pozisyon() == imlec_pzsyn.OutsideSelectionArea)))
            {

                Secileni_Kaydet(true);

            }

        }

        private void mouse_DClick(object sender, MouseEventArgs e)
        {

            if (Dikdortgen_cizimi && (imlec_pozisyon() == imlec_pzsyn.WithinSelectionArea || imlec_pozisyon() == imlec_pzsyn.OutsideSelectionArea))
            {

                Secileni_Kaydet(false);

            }

        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                Eylam_Ayarla();
                Sol_Buton_Tik = true;
                ClickPoint = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);

                if (Dikdortgen_cizimi)
                {

                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    Týk_Baglantisi.X = Cursor.Position.X - MvcutTopLeft.X;
                    Týk_Baglantisi.Y = Cursor.Position.Y - MvcutTopLeft.Y;
                    if (Dikdortgen_cizimi && (imlec_pozisyon() == imlec_pzsyn.WithinSelectionArea || imlec_pozisyon() == imlec_pzsyn.OutsideSelectionArea))
                    {

                        Secileni_Kaydet(false);

                    }
                }
            }
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {

            Dikdortgen_cizimi = true;
            Sol_Buton_Tik = false;
            MevcutEylem = Eylemler.NoClick;
           
        }



        private void mouse_Move(object sender, MouseEventArgs e)
        {
            this.Refresh();
            if (Sol_Buton_Tik && !Dikdortgen_cizimi)
            {

                Secileni_Ciz();

            }

            if (Dikdortgen_cizimi)
            {

                imlec_pozisyon();

                if (MevcutEylem == Eylemler.Dragging)
                {

                    Secimi_Surukle();

                }

                if (MevcutEylem != Eylemler.Dragging && MevcutEylem != Eylemler.Outside)
                {

                    Secileni_Boyutlandir();

                }
            }
        }



        private imlec_pzsyn imlec_pozisyon()
        {
            if (((Cursor.Position.X > MvcutTopLeft.X - 10 && Cursor.Position.X < MvcutTopLeft.X + 10)) && ((Cursor.Position.Y > MvcutTopLeft.Y + 10) && (Cursor.Position.Y < MvcutBottomRight.Y - 10)))
            {

                this.Cursor = Cursors.SizeWE;
                return imlec_pzsyn.LeftLine;

            }
            if (((Cursor.Position.X >= MvcutTopLeft.X - 10 && Cursor.Position.X <= MvcutTopLeft.X + 10)) && ((Cursor.Position.Y >= MvcutTopLeft.Y - 10) && (Cursor.Position.Y <= MvcutTopLeft.Y + 10)))
            {

                this.Cursor = Cursors.SizeNWSE;
                return imlec_pzsyn.TopLeft;

            }
            if (((Cursor.Position.X >= MvcutTopLeft.X - 10 && Cursor.Position.X <= MvcutTopLeft.X + 10)) && ((Cursor.Position.Y >= MvcutBottomRight.Y - 10) && (Cursor.Position.Y <= MvcutBottomRight.Y + 10)))
            {

                this.Cursor = Cursors.SizeNESW;
                return imlec_pzsyn.BottomLeft;

            }
            if (((Cursor.Position.X > MvcutBottomRight.X - 10 && Cursor.Position.X < MvcutBottomRight.X + 10)) && ((Cursor.Position.Y > MvcutTopLeft.Y + 10) && (Cursor.Position.Y < MvcutBottomRight.Y - 10)))
            {

                this.Cursor = Cursors.SizeWE;
                return imlec_pzsyn.RightLine;

            }
            if (((Cursor.Position.X >= MvcutBottomRight.X - 10 && Cursor.Position.X <= MvcutBottomRight.X + 10)) && ((Cursor.Position.Y >= MvcutTopLeft.Y - 10) && (Cursor.Position.Y <= MvcutTopLeft.Y + 10)))
            {

                this.Cursor = Cursors.SizeNESW;
                return imlec_pzsyn.TopRight;

            }
            if (((Cursor.Position.X >= MvcutBottomRight.X - 10 && Cursor.Position.X <= MvcutBottomRight.X + 10)) && ((Cursor.Position.Y >= MvcutBottomRight.Y - 10) && (Cursor.Position.Y <= MvcutBottomRight.Y + 10)))
            {

                this.Cursor = Cursors.SizeNWSE;
                return imlec_pzsyn.BottomRight;

            }
            if (((Cursor.Position.Y > MvcutTopLeft.Y - 10) && (Cursor.Position.Y < MvcutTopLeft.Y + 10)) && ((Cursor.Position.X > MvcutTopLeft.X + 10 && Cursor.Position.X < MvcutBottomRight.X - 10)))
            {

                this.Cursor = Cursors.SizeNS;
                return imlec_pzsyn.TopLine;

            }
            if (((Cursor.Position.Y > MvcutBottomRight.Y - 10) && (Cursor.Position.Y < MvcutBottomRight.Y + 10)) && ((Cursor.Position.X > MvcutTopLeft.X + 10 && Cursor.Position.X < MvcutBottomRight.X - 10)))
            {

                this.Cursor = Cursors.SizeNS;
                return imlec_pzsyn.BottomLine;

            }
            if (
                (Cursor.Position.X >= MvcutTopLeft.X + 10 && Cursor.Position.X <= MvcutBottomRight.X - 10) && (Cursor.Position.Y >= MvcutTopLeft.Y + 10 && Cursor.Position.Y <= MvcutBottomRight.Y - 10))
            {

                this.Cursor = Cursors.Hand;
                return imlec_pzsyn.WithinSelectionArea;

            }

            this.Cursor = Cursors.No;
            return imlec_pzsyn.OutsideSelectionArea;
        }

        private void Eylam_Ayarla()
        {

            switch (imlec_pozisyon())
            {
                case imlec_pzsyn.BottomLine:
                    MevcutEylem = Eylemler.BottomSizing;
                    break;
                case imlec_pzsyn.TopLine:
                    MevcutEylem = Eylemler.TopSizing;
                    break;
                case imlec_pzsyn.LeftLine:
                    MevcutEylem = Eylemler.LeftSizing;
                    break;
                case imlec_pzsyn.TopLeft:
                    MevcutEylem = Eylemler.TopLeftSizing;
                    break;
                case imlec_pzsyn.BottomLeft:
                    MevcutEylem = Eylemler.BottomLeftSizing;
                    break;
                case imlec_pzsyn.RightLine:
                    MevcutEylem = Eylemler.RightSizing;
                    break;
                case imlec_pzsyn.TopRight:
                    MevcutEylem = Eylemler.TopRightSizing;
                    break;
                case imlec_pzsyn.BottomRight:
                    MevcutEylem = Eylemler.BottomRightSizing;
                    break;
                case imlec_pzsyn.WithinSelectionArea:
                    MevcutEylem = Eylemler.Dragging;
                    break;
                case imlec_pzsyn.OutsideSelectionArea:
                    MevcutEylem = Eylemler.Outside;
                    break;
            }

        }

        private void Secileni_Boyutlandir()
        {

            if (MevcutEylem == Eylemler.LeftSizing)
            {

                if (Cursor.Position.X < MvcutBottomRight.X - 10)
                {

        
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutTopLeft.X = Cursor.Position.X;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }

            }
            if (MevcutEylem == Eylemler.TopLeftSizing)
            {

                if (Cursor.Position.X < MvcutBottomRight.X - 10 && Cursor.Position.Y < MvcutBottomRight.Y - 10)
                {

             
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutTopLeft.X = Cursor.Position.X;
                    MvcutTopLeft.Y = Cursor.Position.Y;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }
            }
            if (MevcutEylem == Eylemler.BottomLeftSizing)
            {

                if (Cursor.Position.X < MvcutBottomRight.X - 10 && Cursor.Position.Y > MvcutTopLeft.Y + 10)
                {

                 
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutTopLeft.X = Cursor.Position.X;
                    MvcutBottomRight.Y = Cursor.Position.Y;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }

            }
            if (MevcutEylem == Eylemler.RightSizing)
            {

                if (Cursor.Position.X > MvcutTopLeft.X + 10)
                {

                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutBottomRight.X = Cursor.Position.X;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }
            }
            if (MevcutEylem == Eylemler.TopRightSizing)
            {

                if (Cursor.Position.X > MvcutTopLeft.X + 10 && Cursor.Position.Y < MvcutBottomRight.Y - 10)
                {

                  
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutBottomRight.X = Cursor.Position.X;
                    MvcutTopLeft.Y = Cursor.Position.Y;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }
            }
            if (MevcutEylem == Eylemler.BottomRightSizing)
            {

                if (Cursor.Position.X > MvcutTopLeft.X + 10 && Cursor.Position.Y > MvcutTopLeft.Y + 10)
                {

            
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutBottomRight.X = Cursor.Position.X;
                    MvcutBottomRight.Y = Cursor.Position.Y;
                    Dikdortgen_gnslk = MvcutBottomRight.X - MvcutTopLeft.X;
                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }
            }
            if (MevcutEylem == Eylemler.TopSizing)
            {

                if (Cursor.Position.Y < MvcutBottomRight.Y - 10)
                {

         
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutTopLeft.Y = Cursor.Position.Y;
                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }
            }
            if (MevcutEylem == Eylemler.BottomSizing)
            {

                if (Cursor.Position.Y > MvcutTopLeft.Y + 10)
                {

           
                    g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);
                    MvcutBottomRight.Y = Cursor.Position.Y;
                    Dikdortgen_yksk = MvcutBottomRight.Y - MvcutTopLeft.Y;
                    g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

                }

            }

        }

        private void Secimi_Surukle()
        {

            g.DrawRectangle(Silgi, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

            if (Cursor.Position.X - Týk_Baglantisi.X > 0 && Cursor.Position.X - Týk_Baglantisi.X + Dikdortgen_gnslk < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
            {

                MvcutTopLeft.X = Cursor.Position.X - Týk_Baglantisi.X;
                MvcutBottomRight.X = MvcutTopLeft.X + Dikdortgen_gnslk;

            }
            else
               
                if (Cursor.Position.X - Týk_Baglantisi.X > 0)
                {

                    MvcutTopLeft.X = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Dikdortgen_gnslk;
                    MvcutBottomRight.X = MvcutTopLeft.X + Dikdortgen_gnslk;

                }
             
                else
                {

                    MvcutTopLeft.X = 0;
                    MvcutBottomRight.X = MvcutTopLeft.X + Dikdortgen_gnslk;

                }

            if (Cursor.Position.Y - Týk_Baglantisi.Y > 0 && Cursor.Position.Y - Týk_Baglantisi.Y + Dikdortgen_yksk < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            {

                MvcutTopLeft.Y = Cursor.Position.Y - Týk_Baglantisi.Y;
                MvcutBottomRight.Y = MvcutTopLeft.Y + Dikdortgen_yksk;

            }
            else

                if (Cursor.Position.Y - Týk_Baglantisi.Y > 0)
                {

                    MvcutTopLeft.Y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Dikdortgen_yksk;
                    MvcutBottomRight.Y = MvcutTopLeft.Y + Dikdortgen_yksk;

                }
          
                else
                {

                    MvcutTopLeft.Y = 0;
                    MvcutBottomRight.Y = MvcutTopLeft.Y + Dikdortgen_yksk;

                }


            g.DrawRectangle(kalem, MvcutTopLeft.X, MvcutTopLeft.Y, Dikdortgen_gnslk, Dikdortgen_yksk);

        }

        private void Secileni_Ciz()
        {

            this.Cursor = Cursors.Arrow;

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

    }
}