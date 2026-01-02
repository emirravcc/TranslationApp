using System.Net.Http;
using Newtonsoft.Json.Linq;
namespace TranslationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string kaynakMetin = richTextBox1.Text;
            string kaynakDil = "tr"; // Varsayýlan Türkçe
            string hedefDil = "en";  // Varsayýlan Ýngilizce

            // API üzerinden ücretsiz çeviri iþlemi
            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={kaynakDil}&tl={hedefDil}&dt=t&q={Uri.EscapeDataString(kaynakMetin)}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string sonucJson = client.GetStringAsync(url).Result;
                    var veri = JArray.Parse(sonucJson);
                    string cevrilenMetin = veri[0][0][0].ToString();
                    richTextBox2.Text = cevrilenMetin;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ýnternet baðlantýnýzý kontrol edin veya geçerli bir metin girin.");
                }
            }
        }
    }
}
