using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace WebScraping_wf.cs
{
    public partial class Form1 : Form
    {
        public string url = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadUpHtml()
        {
            StreamWriter writer = new StreamWriter("RawHtml.txt");
            writer.Write("");
            writer.Close();
            writer.Dispose();
            WebClient client = new WebClient();
            client.DownloadFile(url, "RawHtml.txt");
            if (ShowHtmlRawRB.Checked == true)
            {
                ShowHtmlRawRB.Checked = false;
                Process.Start("RawHtml.txt");
                client.Dispose();
                scrap();
            }
            else
            {
                client.Dispose();
                scrap();
            }
        }

        private async void scrap()
        {
            //<summary>
            //Scraps the webpage for the requested data
            //<summary>
            var httpClient = new HttpClient(); //creates httpClient
            var html = await httpClient.GetStringAsync(url); //not sure what the await is doing
            var htmlDocument = new HtmlAgilityPack.HtmlDocument(); //creates the htmmlDocument
            htmlDocument.LoadHtml(html); //loads htmlDoc

            var ProductList = htmlDocument.DocumentNode.Descendants(queryConfig("Descendants - ").ToString()).Where(node => node.GetAttributeValue(queryConfig("Attribute - ").ToString(), "").Equals(queryConfig("ListViewInner - ").ToString().ToList())); //gets the right data
            foreach (var item in ProductList)
            {
                postProcess(item.InnerHtml, item.InnerLength, item.InnerText, item.InnerStartIndex); //pass over the data it finds to the 
            }
        }

        private void postProcess(string InnerHtml, int InnerLenght, string InnerText, int StartIndex)
        {
            //<summary>
            //will take care of cleaning up the above strings 
            //InnerText is the string you want Gabby
            //<summary>
        }

        public string queryConfig(string idOfItem)
        {
            //<summary>
            //gets data from config file [idOfItem] is a header string to id a config item
            //<summary>
            string item = String.Empty;
            StreamReader reader = new StreamReader("Form1FunctionConfig.txt");
            var lines = reader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i != lines.Length; i++)
            {
                if (lines[i].Contains(idOfItem))
                {
                    item = lines[i].Replace(idOfItem, ""); //replaces idOfItem so it's ownly the item itself
                    return item;
                }
            }
            return $"No item with the give ID [ {idOfItem} ] was found"; //if it can't find the item
        }

        private void LoadHtml_Click(object sender, EventArgs e)
        {
            //<summary>
            //load the html from the web page into a txt file for later refernce
            //also insures that the URL input text box has something in it 
            //<summary>
            if(UrlTextBox.Text == string.Empty)
            {
                MessageBox.Show("URLError", "Please Enter vaild URL");
            }
            else
            {
                url = UrlTextBox.Text;
                loadUpHtml();
            }
        }
    }
}
