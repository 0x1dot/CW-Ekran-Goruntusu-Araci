using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CW_Ekran_Görüntüsü_Aracý
{

    class EkranGoruntusu
    {

        public static bool panoya_kopyala = false;

        public static void Goruntuyu_al(bool showCursor, Size curSize, Point curPos, Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath, string extension,bool upload,int siteindex)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);

                        if (showCursor)
                        {

                            Rectangle cursorBounds = new Rectangle(curPos, curSize);
                            Cursors.Default.Draw(g, cursorBounds);

                        }

                    }

                    if (panoya_kopyala)
                    {

                        Image img = (Image)bitmap;
                        Clipboard.SetImage(img);

                    }
                    else
                    {
                        switch (extension)
                        {
                            case ".bmp":
                                bitmap.Save(FilePath, ImageFormat.Bmp);
                                break;
                            case ".jpg":
                                bitmap.Save(FilePath, ImageFormat.Jpeg);
                                break;
                            case ".gif":
                                bitmap.Save(FilePath, ImageFormat.Gif);
                                break;
                            case ".tiff":
                                bitmap.Save(FilePath, ImageFormat.Tiff);
                                break;
                            case ".png":
                                bitmap.Save(FilePath, ImageFormat.Png);
                                break;
                            default:
                                bitmap.Save(FilePath, ImageFormat.Jpeg);
                                break;
                        }

                    }
                    if (upload)
                    {
                        switch (siteindex)
                        {
                            case 0:
                                lst.Clear();
                                lst.Add(Hizliresim.imageToByteArray(bitmap));
                                Hizliresim.HizliResimeYukle(null, Listele());
                                break;
                            case 1:
                                lst.Clear();
                                lst.Add(Hizliresim.imageToByteArray(bitmap));
                                Hizliresim.imguploadsYukle(null, Listele());
                                break;
                        }                      
                    }
                }
            }
            catch
            {
            }
        }
        static List<byte[]> lst = new List<byte[]>();
        public static ListBox Listele()
        {
            ListBox lstbx = new ListBox();
            foreach (byte[] item in lst)
            {
                lstbx.Items.Add(Convert.ToBase64String(item));//"data:image/png;base64,"+
            }
            return lstbx;
        }
    }
}