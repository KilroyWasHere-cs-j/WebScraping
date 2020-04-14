using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace WebScraping_wf.cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("C:/TxtFiles/Doc_One.txt");
            writer.Write("");
            writer.Close();
            writer.Dispose();
            WebClient client = new WebClient();
            client.DownloadFile("https://stackoverflow.com/questions/26233/fastest-c-sharp-code-to-download-a-web-page", "C:/TxtFiles/Doc_One.txt");
            client.Dispose();
            scrap();
        }

        private async void scrap()
        {
            var url = "https://www.ebay.com/sch/i.html?_nkw=Chemical+Suits&_in_kw=1&_ex_kw=&_sacat=0&_udlo=&_udhi=&_ftrt=901&_ftrv=1&_sabdlo=&_sabdhi=&_samilow=&_samihi=&_sadis=15&_stpos=&_sargn=-1%26saslc%3D1&_salic=1&_sop=12&_dmd=1&_ipg=50&_fosrp=1";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            var ProductList = htmlDocument.DocumentNode.Descendants("ul").Where(node => node.GetAttributeValue("id", "").Equals("ListViewInner")).ToList();
            foreach(var item in ProductList)
            {
                listBox1.Items.Add(item.InnerHtml);  
            }
        }
    }
}
