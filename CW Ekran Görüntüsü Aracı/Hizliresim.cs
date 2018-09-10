using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CW_Ekran_Görüntüsü_Aracı
{
   public static class Hizliresim
    {
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static void HizliResimeYukle(string localresponse = null, ListBox liste = null)
        {
            foreach (string item in liste.Items)
            {
                if (base64cevir(item))
                {
                    if (!Directory.Exists(HizliResimFormUpload.folderpath)) Directory.CreateDirectory(HizliResimFormUpload.folderpath);
                    byteArrayToImage(Convert.FromBase64String(item)).Save(HizliResimFormUpload.folderpath + Path.GetRandomFileName() + ".png");
                }
                else
                {
                    HizliResimFormUpload.DownloadImage(item);
                }
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("MAX_FILE_SIZE", "0");
            List<string> container = HizliResimFormUpload.GetCookie();
            HizliResimFormUpload._token = container[0];
            HizliResimFormUpload._cookie = container[1];
            d.Add("_token", HizliResimFormUpload._token);
            foreach (string item in Directory.GetFiles(HizliResimFormUpload.folderpath))
            {
                string CT = "local_files[]";
                string extension;
                extension = Path.GetExtension(item).ToLower();
                switch (extension)
                {
                    case ".png":
                        extension = "image/png";
                        break;
                    case ".jpg":
                        extension = "image/jpg";
                        break;
                    case ".jpeg":
                        extension = "image/jpeg";
                        break;
                    case ".gif":
                        extension = "image/gif";
                        break;
                    case ".tiff":
                        extension = "image/tiff";
                        break;
                    case ".bmp":
                        extension = "image/bmp";
                        break;
                    default:
                        MessageBox.Show(item + " Dosya türü geçersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                }
                HizliResimFormUpload.FileParameter f = new HizliResimFormUpload.FileParameter(File.ReadAllBytes(item), Path.GetFileName(item), extension);
                d.Add(CT + "=" + Guid.NewGuid(), f);
            }
            d.Add("remote_file_url", "");
            d.Add("upload_setting_description", "");
            d.Add("upload_setting_is_public", "0");
            d.Add("upload_setting_effect", "0");
            d.Add("upload_setting_size", "");
            string ua = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36"; //"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            HttpWebResponse s = HizliResimFormUpload.MultipartFormDataPost("http://hizliresim.com/p/yukle", ua, d, true);
        }
        public static void imguploadsYukle(string localresponse = null, ListBox liste = null)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string item in liste.Items)
            {
                if (base64cevir(item))
                {
                    if (!Directory.Exists(ImgUploadsFormUpload.folderpath)) Directory.CreateDirectory(ImgUploadsFormUpload.folderpath);
                    byteArrayToImage(Convert.FromBase64String(item)).Save(ImgUploadsFormUpload.folderpath + Path.GetRandomFileName() + ".png");
                }
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<string> container = ImgUploadsFormUpload.GetCookie();
            ImgUploadsFormUpload._token = container[0];
            container.RemoveAt(0);
            ImgUploadsFormUpload._cookie = container;
            d.Add("auth_token", ImgUploadsFormUpload._token);
            foreach (string item in Directory.GetFiles(ImgUploadsFormUpload.folderpath))
            {
                string CT = "source";
                string extension;
                extension = Path.GetExtension(item).ToLower();
                switch (extension)
                {
                    case ".png":
                        extension = "image/png";
                        break;
                    case ".jpg":
                        extension = "image/jpg";
                        break;
                    case ".jpeg":
                        extension = "image/jpeg";
                        break;
                    case ".gif":
                        extension = "image/gif";
                        break;
                    case ".tiff":
                        extension = "image/tiff";
                        break;
                    case ".bmp":
                        extension = "image/bmp";
                        break;
                    default:
                        MessageBox.Show(item + " Dosya türü geçersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                }
                ImgUploadsFormUpload.FileParameter f = new ImgUploadsFormUpload.FileParameter(File.ReadAllBytes(item), Path.GetFileName(item), extension);
                d.Add(CT + "=" + Guid.NewGuid(), f);
            }
            d.Add("type", "file");
            d.Add("action", "upload");
            d.Add("timestamp", "1536363846671");
            d.Add("nsfw", "0");
            string ua = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36"; //"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            HttpWebResponse s = ImgUploadsFormUpload.MultipartFormDataPost("http://imguploads.net/json", ua, d, true);
        }
        private static bool base64cevir(string item)
        {
            try
            {
                Convert.FromBase64String(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
