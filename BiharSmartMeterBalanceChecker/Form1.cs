using BiharSmartMeterBalanceChecker.entity;
using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace BiharSmartMeterBalanceChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread m_thread = null;
        private string url = "https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx";
        private string postData = "";
        private entity.HttpCall httpCall = new entity.HttpCall();

        private void btn_fetch_Click(object sender, EventArgs e)
        {
            var HttpRes = httpCall.MakeRequest("GET", url);
            url = httpCall.ParseRequest(HttpRes, "URL");
            string htmlDoc = httpCall.ParseRequest(HttpRes);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlDoc);

            webBrowser1.DocumentText = htmlDoc;
            richTextBox1.Text = htmlDoc;
            return;
            //StringBuilder sb = new StringBuilder();
            try
            {
                var VIEWSTATE = doc.DocumentNode.SelectSingleNode("//*[@id=\"__VIEWSTATE\"]");
                var EVENTVALIDATION = doc.DocumentNode.SelectSingleNode("//*[@id=\"__EVENTVALIDATION\"]");
                var VIEWSTATEGENERATOR = doc.DocumentNode.SelectSingleNode("//*[@id=\"__VIEWSTATEGENERATOR\"]");
                postData = "__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VIEWSTATE=" + VIEWSTATE.Attributes["value"].Value + "&__VIEWSTATEGENERATOR=" + VIEWSTATEGENERATOR.Attributes["value"].Value + "&__EVENTVALIDATION=" + EVENTVALIDATION.Attributes["value"].Value + "&ctl00$MainContent$txtConID=" + txt_consumer_id.Text.Trim() + "&ctl00$MainContent$txtConName=&ctl00$MainContent$txtAmountPayable=&ctl00$MainContent$btnCurrentblnce=Get Current Balance&ctl00$MainContent$txtEmailId=&ctl00$MainContent$txtMobileNo=&ctl00$MainContent$txtCurrentblnce=";
            } catch (Exception ex) {}

            HttpRes = httpCall.MakeRequest("POST", url, postData);
            htmlDoc = httpCall.ParseRequest(HttpRes);
            doc.LoadHtml(htmlDoc);
            Thread.Sleep(2000);

            //webBrowser1.DocumentText = htmlDoc;
            //richTextBox1.Text = htmlDoc;

            try
            {
                var Balance = doc.DocumentNode.SelectSingleNode("//*[@id=\"MainContent_txtCurrentblnce\"]");
                if(Balance != null)
                {
                    MessageBox.Show(Balance.InnerText);
                } else
                {
                    Console.WriteLine(Balance);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            //webBrowser1.DocumentText = x.MakeRequest("POST", "", postData);

            //foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//*[@id=\"__VIEWSTATE\"]"))
            //{
            //    sb.AppendLine(node.Text);
            //}
            //richTextBox1.Text = sb.ToString();

            //Application.Exit();

            //if (m_thread == null)
            //{
            //    ThreadStart ts = new ThreadStart();
            //    m_thread = new Thread(ts);
            //    m_thread.Start();
            //}

            //webBrowser1.Navigate("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx");

            //urlCall urlCall = new urlCall();
            //string htmlData = urlCall.Get("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx");
            //string __VIEWSTATE = urlCall.parseHtml(htmlData, "//*[@id=\"__VIEWSTATE\"]");
            //string __VIEWSTATEGENERATOR = urlCall.parseHtml(htmlData, "//*[@id=\"__VIEWSTATEGENERATOR\"]");
            //string __EVENTVALIDATION = urlCall.parseHtml(htmlData, "//*[@id=\"__EVENTVALIDATION\"]");

            //richTextBox1.Text = urlCall.Post("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx", "__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VIEWSTATE=" + __VIEWSTATE + "&__VIEWSTATEGENERATOR=" + __VIEWSTATEGENERATOR + "&__EVENTVALIDATION=" + __EVENTVALIDATION + "&ctl00%24MainContent%24txtConID=" + txt_consumer_id.Text.Trim() + "&ctl00%24MainContent%24txtConName=&ctl00%24MainContent%24txtAmountPayable=&ctl00%24MainContent%24btnCurrentblnce=Get+Current+Balance&ctl00%24MainContent%24txtCurrentblnce=142.28&ctl00%24MainContent%24txtEmailId=&ctl00%24MainContent%24txtMobileNo=", "application/x-www-form-urlencoded");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document.GetElementById("MainContent_lblcb") != null) {
                ttText1.Text = webBrowser1.Document.GetElementById("MainContent_lblcb").InnerText;
            } else if (webBrowser1.Document.GetElementById("MainContent_txtCurrentblnce") != null && webBrowser1.Document.GetElementById("MainContent_txtCurrentblnce").GetAttribute("value") == "")
            {
                ttText1.Text = "Getting Balance...";
                webBrowser1.Document.GetElementById("MainContent_txtConID").InnerText = txt_consumer_id.Text.Trim();
                webBrowser1.Document.GetElementById("MainContent_btnCurrentblnce").InvokeMember("Click");
            }
            else if(webBrowser1.Document.GetElementById("MainContent_txtCurrentblnce") != null)
            {
                ttText1.Text = "Success";
                dataGridView1.Rows.Insert(0, txt_consumer_id.Text.Trim(), DateTime.Now.ToString(), webBrowser1.Document.GetElementById("MainContent_txtCurrentblnce").GetAttribute("value"));                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            webBrowser1.DocumentText =  response.Content;
            richTextBox1.Text = response.Content;
            return;

            //HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://sbpdcl.co.in/(S(h3yv234fo4t0bc5y3ubqog34))/frmAdvBillPaymentAll.aspx");
            //myHttpWebRequest.MaximumAutomaticRedirections = 10;
            //myHttpWebRequest.AllowAutoRedirect = true;
            //HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            //webBrowser1.DocumentText = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();
            //return;

            //var data = Encoding.ASCII.GetBytes("");
            //var method = "GET";
            //url = "https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx";
            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            //req.Timeout = 3000;
            //req.Method = method;
            //req.AllowAutoRedirect = true;
            //req.MaximumAutomaticRedirections = 5;
            ////req.AutomaticDecompression = DecompressionMethods.GZip;
            //req.Accept = "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            //req.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            //req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36";

            //if (method.Equals("POST"))
            //{
            //    req.ContentType = "application/x-www-form-urlencoded";
            //    req.ContentLength = data.Length;
            //    using (var stream = req.GetRequestStream())
            //    {
            //        stream.Write(data, 0, data.Length);
            //    }
            //}

            //HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            //webBrowser1.DocumentText = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
