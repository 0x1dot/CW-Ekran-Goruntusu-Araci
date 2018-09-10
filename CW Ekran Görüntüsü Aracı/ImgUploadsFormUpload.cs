using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CW_Ekran_Görüntüsü_Aracı;

public static class ImgUploadsFormUpload
{
    private static readonly Encoding encoding = Encoding.UTF8;
    public static List<string> _cookie;
    public static string _token;
    private static List<CookieCollection> cookiel;
    public static List<string> GetCookie()
    {
        List<string> Container = new List<string>();
        CookieContainer cookieJar = new CookieContainer();
        cookiel = new List<CookieCollection>();
        HttpWebRequest request = WebRequest.Create("http://imguploads.net/") as HttpWebRequest;
        request.CookieContainer = cookieJar;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
        var response = request.GetResponse();
        StreamReader responseReader = new StreamReader(response.GetResponseStream());
        string fullResponse = responseReader.ReadToEnd();
        string token = "<input type=\"hidden\" name=\"auth_token\" value=\"(.+?)\">";
        
        Match ss = Regex.Match(fullResponse, token);
        if (ss.Value != string.Empty)
        {
            string auth_token = ss.Groups[1].ToString();
            Container.Add(auth_token);
        }
        HttpWebResponse responses = request.GetResponse() as HttpWebResponse;
        string responseFromLogIn6 = responses.GetResponseHeader("Location");

        foreach (Cookie c in cookieJar.GetCookies(request.RequestUri))
        {
            string cookie = "Cookie['" + c.Name + "']: " + c.Value;
            Container.Add(cookie);
        }
        return Container;
    }
    public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters,bool net = false)
    {
        string formDataBoundary = String.Format("----WebkitFormBoundary{0:N}", Guid.NewGuid());
        string contentType = "multipart/form-data; boundary=" + formDataBoundary;

        byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);
            if (net==true)
                DeleteDirectory(folderpath);
        return PostForm(postUrl, userAgent, contentType, formData);
    }
    public static void DeleteDirectory(string target_dir)
    {
        try
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            Directory.Delete(target_dir, false);
        }
        catch
        {
        }
    }
    static HttpWebResponse responseh = null;
    static byte[] formData1;
    private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
    {
        formData1 = formData;
        HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
        if (request == null)
        {
            throw new NullReferenceException("request is not a http request");
        }
        var uri = new Uri(postUrl);
        // Set up the request properties.
        request.ContentType = contentType;
        request.Method = "POST";
        request.UserAgent = userAgent;
        WebHeaderCollection myWebHeaderCollection = request.Headers;
        myWebHeaderCollection.Add("Cache-Control", "max-age=0");
        myWebHeaderCollection.Add("Save-Data", "on");
        myWebHeaderCollection.Add("Upgrade-Insecure-Requests", "1");
        myWebHeaderCollection.Add("Origin", uri.Host);
        myWebHeaderCollection.Add("Fiddler-Encoding", "base64");
        request.CookieContainer = new CookieContainer();
        foreach (var item in _cookie)
        {
            string cookiname = item.Split(':')[0].ToString().Replace("Cookie['", "").Replace("']", "");
            string cookievalue = item.Split(':')[1].ToString().Replace(" ", "").Replace("%3D %3D", "%3D");
            request.CookieContainer.Add(new Cookie(cookiname, cookievalue, "/", uri.Host));
        }
        request.ContentLength = formData.Length;
       // request.ContentType = "application/json; charset=utf-8";
        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
        request.KeepAlive = true;
        request.AllowAutoRedirect = true;
        request.UseDefaultCredentials = true;
        request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        // You could add authentication here as well if needed:
        // request.PreAuthenticate = true;
        // request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        // request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("username" + ":" + "password")));

        // Send the form data to the request.
        //  request.BeginGetRequestStream(new AsyncCallback(ReadCallback), request);
        request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallBack), request);
        return responseh;
    }
  static  AutoResetEvent signal = new AutoResetEvent(false);
    private static void GetRequestStreamCallBack(IAsyncResult asyncResult)
    {
        HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
        try
        {
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(formData1, 0, formData1.Length);
                requestStream.Close();
                request.BeginGetResponse(new AsyncCallback(GetResponseCallBack), request);
                signal.WaitOne();
            }
        }
        catch
        {
        }
    }
    private static void GetResponseCallBack(IAsyncResult asyncResult)
    {
        HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
        try
        {
            using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult))
            {
                Stream responseStream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    string fullResponse = sr.ReadToEnd();
                    responseh = null;
                    responseh = response;
                    ControlPanel hz = (ControlPanel)Application.OpenForms["ControlPanel"];
                    if (hz!=null)
                    {
                        hz.JsonCek(fullResponse);
                        hz.Show();
                        sr.Close();
                        hz.Focus();
                    }
                    else
                    {
                        hz = new ControlPanel();
                        hz.JsonCek(fullResponse);
                        hz.Show();
                        sr.Close();
                        hz.Focus();
                    }
                    signal.Set();
                }
            }
        }
        catch
        {
        }
    }
    private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
    {
        Stream formDataStream = new System.IO.MemoryStream();
        bool needsCLRF = false;

        foreach (var param in postParameters)
        {
            // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
            // Skip it on the first parameter, add it to subsequent parameters.
            if (needsCLRF)
                formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

            needsCLRF = true;

            if (param.Value is FileParameter)
            {
                FileParameter fileToUpload = (FileParameter)param.Value;

                // Add just the first part of this param, since we will write the file data directly to the Stream
                string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                    boundary,
                    param.Key.Split('=')[0],
                    fileToUpload.FileName ?? param.Key,
                    fileToUpload.ContentType ?? "application/octet-stream");

                formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                // Write the file data directly to the Stream, rather than serializing it to a string.
                formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
            }
            else
            {
                string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                    boundary,
                    param.Key,
                    param.Value);
                formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
            }
        }

        // Add the end of the request.  Start with a newline
        string footer = "\r\n--" + boundary + "--\r\n";
        formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

        // Dump the Stream into a byte[]
        formDataStream.Position = 0;
        byte[] formData = new byte[formDataStream.Length];
        formDataStream.Read(formData, 0, formData.Length);
        formDataStream.Close();

        return formData;
    }
    public static string folderpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\cache\";
    internal static void DownloadImage(string item)
    {
        if (!Directory.Exists(folderpath)) Directory.CreateDirectory(folderpath);
        string imagename = Path.GetFileName(item);
        if (!File.Exists(folderpath + imagename)) ImgUploadsFormUpload.DownloadFile(item, folderpath + imagename);
        else
        {
            File.Delete(folderpath + imagename);
            ImgUploadsFormUpload.DownloadFile(item, folderpath + imagename);
        } 
    }
    public static int DownloadFile(String remoteFilename,String localFilename)
    {
        // Function will return the number of bytes processed
        // to the caller. Initialize to 0 here.
        int bytesProcessed = 0;

        // Assign values to these objects here so that they can
        // be referenced in the finally block
        Stream remoteStream = null;
        Stream localStream = null;
        WebResponse response = null;

        // Use a try/catch/finally block as both the WebRequest and Stream
        // classes throw exceptions upon error
        try
        {
            // Create a request for the specified remote file name
            WebRequest request = WebRequest.Create(remoteFilename);
            if (request != null)
            {
                // Send the request to the server and retrieve the
                // WebResponse object 
                response = request.GetResponse();
                if (response != null)
                {
                    // Once the WebResponse object has been retrieved,
                    // get the stream object associated with the response's data
                    remoteStream = response.GetResponseStream();

                    // Create the local file
                    localStream = File.Create(localFilename);

                    // Allocate a 1k buffer
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Simple do/while loop to read from stream until
                    // no bytes are returned
                    do
                    {
                        // Read data (up to 1k) from the stream
                        bytesRead = remoteStream.Read(buffer, 0, buffer.Length);

                        // Write the data to the local file
                        localStream.Write(buffer, 0, bytesRead);

                        // Increment total bytes processed
                        bytesProcessed += bytesRead;
                    } while (bytesRead > 0);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            // Close the response and streams objects here 
            // to make sure they're closed even if an exception
            // is thrown at some point
            if (response != null) response.Close();
            if (remoteStream != null) remoteStream.Close();
            if (localStream != null) localStream.Close();
        }

        // Return total bytes processed to caller.
        return bytesProcessed;
    }
    public class FileParameter
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public FileParameter(byte[] file) : this(file, null) { }
        public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
        public FileParameter(byte[] file, string filename, string contenttype)
        {
            File = file;
            FileName = filename;
            ContentType = contenttype;
        }
    }
}