using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WebScraping_wf.cs
{
    public partial class Form1 : Form
    {
        public string url = string.Empty;
        public long lineNumberCounter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lineNumberCounter = long.Parse(queryConfig("lineCount - "));
            //https://www.weatherforyou.com/reports/index.php?pands=brunswick%2Cmaine
            //https://www.ebay.com/sch/i.html?_nkw=Chemical+Suits&_in_kw=1&_ex_kw=&_sacat=0&_udlo=&_udhi=&_ftrt=901&_ftrv=1&_sabdlo=&_sabdhi=&_samilow=&_samihi=&_sadis=15&_stpos=&_sargn=-1%26saslc%3D1&_salic=1&_sop=12&_dmd=1&_ipg=50&_fosrp=1
        }

        private void loadUpHtml()
        {
            string htmlFile = queryConfig("rawHtmlFile - ");
            StreamWriter writer = new StreamWriter(htmlFile);
            writer.Write("");
            writer.Close();
            writer.Dispose();
            WebClient client = new WebClient();
            client.DownloadFile(url, htmlFile);
            if (ShowHtmlRawRB.Checked == true)
            {
                ShowHtmlRawRB.Checked = false;
                Process notePad = Process.Start(htmlFile);
                client.Dispose();
                scrap();
            }
            else
            {
                client.Dispose();
                scrap();
            }
            OpenURLInBrowser(UrlTextBox.Text);
        }

        private void OpenURLInBrowser(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            try
            {
                webBrowser1.Navigate(new Uri(url));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void scrap()
        {
            //<summary>
            //Scraps the webpage for the requested data
            //<summary>
            string rawHtml = queryConfig("rawHtmlFile - ");
            StreamReader reader = new StreamReader(rawHtml);
            foreach(string line in File.ReadAllLines(rawHtml))
            {
                lineNumberCounter++;
                //MessageBox.Show(line);
                //string 
                //MessageBox.Show(queryConfig("First - "));
                //MessageBox.Show(queryConfig("Second - "));
                if(line.Contains(queryConfig("First - ")) == true && line.Contains(queryConfig("Second - ")) == true)
                {
                    //MessageBox.Show("Item found", $"Item found at line number: {lineNumberCounter}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(line + "Found at line: " + lineNumberCounter.ToString());
                    postProcess(line, lineNumberCounter);
                    StreamWriter writer = new StreamWriter("PostProcessOutput.txt");
                    writer.WriteLine(line);
                    writer.WriteLine($"Found at line number: {lineNumberCounter}");
                    writer.Close();
                    writer.Dispose();
                    Process.Start("PostProcessOutput.txt");
                }
                else
                {

                }
            }
            reader.Dispose();
        }
        /*
         *                 int indexOfFirstQuotes = subOfContent.IndexOf(
                string subOfContentQuotes = subOfContent.
         */

        private void postProcess(string item, long lineNumber)
        {
            //<summary>
            //will take care of cleaning up the above strings 
            //InnerText is the string you want Gabby
            //<summary>
            //MessageBox.Show($"item: {item}");
            //MessageBox.Show($"lineNumber: {lineNumber}");
            try
            {
                int altIndex = item.IndexOf("alt="); //find alt
                string overView = item.Substring(altIndex, 45); //gets the daliy weather overview
                MessageBox.Show(overView);
            }
            catch
            {

            }
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
            reader.Dispose();
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

        private void showConfigbtn_Click(object sender, EventArgs e)
        {
            //<summary>
            //shows config file
            //and changes buttons look
            //<summary>
            Thread thread = new Thread(new ThreadStart(thread1));
            thread.Start();
        }

        void thread1()
        {
            Process.Start("Form1FunctionConfig.txt");
            showConfigbtn.BackColor = Color.Green;
        }
    }
}
