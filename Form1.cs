﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WebScraping_wf.cs
{
    public partial class Form1 : Form
    {
        public string url = "https://www.weatherforyou.com/reports/index.php?pands=brunswick%2Cmaine";
        public long lineNumberCounter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //<summary>
            //load the html from the web page into a txt file for later refernce
            //also insures that the URL input text box has something in it 
            //<summary>
            loadUpHtml();
            lineNumberCounter = long.Parse(queryConfig("lineCount - "));
            if(queryConfig("ClearOutputFile - ") == "True")
            {
                StreamWriter cleaner = new StreamWriter(queryConfig("OutputFile - "));
                cleaner.Write($"Last cleaned at: {getDateTime()}");
                cleaner.Close();
                cleaner.Dispose();
            }
            else
            {

            }
        }

        private void loadUpHtml()
        {
            string htmlFile = queryConfig("rawHtmlFile - ");
            StreamWriter writer = new StreamWriter(htmlFile);
            writer.Write("");
            writer.Close();
            writer.Dispose();
            WebClient client = new WebClient();
            client.DownloadFile(url, "RawHtml.txt"); // needs try catch [404] error
            if (ShowHtmlRawRB.Checked == true)
            {
                ShowHtmlRawRB.Checked = false;
                //Process notePad = Process.Start(htmlFile);
                client.Dispose();
                scrap();
            }
            else
            {
                client.Dispose();
                scrap();
            }
            //OpenURLInBrowser(UrlTextBox.Text);
        }

        private void OpenURLInBrowser(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            try
            {
                
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
                    //MessageBox.Show(line + "Found at line: " + lineNumberCounter.ToString());
                    StreamWriter writer = new StreamWriter("TextFile1.txt");
                    writer.WriteLine(line);
                    writer.Close();
                    //Process.Start("TextFile1.txt");
                    postProcess(line, lineNumberCounter);
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
        #region dataProcessing
        private void postProcess(string item, long lineNumber)
        {
            //<summary>
            //will take care of cleaning up the above strings 
            //InnerText is the string you want Gabby
            //<summary>
            //MessageBox.Show($"item: {item}");
            //MessageBox.Show($"lineNumber: {lineNumber}");
            string output = string.Empty;
            try
            {
                int altIndex = item.IndexOf(queryConfig("FirstIndex - ")); //find alt=
                string overView = item.Substring(altIndex, 40); //gets the daliy weather overview
                output += overView;


                //find "Day:"

                int dayIndex = item.IndexOf(queryConfig("SecondIndex - ")); // find Day:
                string day = item.Substring(dayIndex, 70);
                output += "\n" + day;
                printOutData(output);

            }
            catch
            {

            }
        }
        #endregion    

        private void printOutData(string data)
        {
            string outPutFile = queryConfig("OutputFile - ");
            string file = string.Empty;
            StreamReader reader = new StreamReader(outPutFile);
            file = reader.ReadToEnd();
            reader.Close();
            StreamWriter writer = new StreamWriter(outPutFile);
            writer.WriteLine(file + "\n \n");
            writer.WriteLine($"________________{getDateTime()}________________________");
            writer.WriteLine("\n \n");
            writer.WriteLine(data);
            writer.WriteLine("\n \n");
            writer.WriteLine("_________________________________________________________________");
            writer.Close();
            if(queryConfig("ShowOutputText - ") == "True")
            {
                Process.Start(outPutFile);
            }
            else
            {

            }
            if(queryConfig("AutoClose - ") == "True")
            {
                this.Close();
            }
            else
            {

            }
            reader.Dispose();
            writer.Dispose();
        }

        private string getDateTime()
        {
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("D");
            string time = dateTime.ToString("HH:mm");
            return date + " " + time;
        }

        #region Config
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
        #endregion

        #region Buttons
        private void LoadHtml_Click(object sender, EventArgs e)
        {
            //<summary>
            //load the html from the web page into a txt file for later refernce
            //also insures that the URL input text box has something in it 
            //<summary>
            if(url == string.Empty)
            {
                MessageBox.Show("URLError", "Please Enter vaild URL");
            }
            else
            {
#pragma warning disable CS1717 // Assignment made to same variable
                url = url;
#pragma warning restore CS1717 // Assignment made to same variable
                loadUpHtml();
            }
        }
        #endregion

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
