using Newtonsoft.Json.Linq;
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
                            rcResimUrl.Text += item.Groups[1].ToString() + "\n";
                }
            }
        }
        public void JsonCek(string response)
        {
            dynamic stuff = JObject.Parse(response);
            if (stuff.status_code == "200")
            {
                rcResimUrl.Text += stuff.image.image.url + "\n";
                MessageBox.Show("Dosya yükleme işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İşllem Başarısız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
