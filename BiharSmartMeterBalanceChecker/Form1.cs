using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace BiharSmartMeterBalanceChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_fetch_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx");
            //urlCall urlCall = new urlCall();
            //string htmlData = urlCall.Get("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx");
            //string __VIEWSTATE = urlCall.parseHtml(htmlData, "//*[@id=\"__VIEWSTATE\"]");
            //string __VIEWSTATEGENERATOR = urlCall.parseHtml(htmlData, "//*[@id=\"__VIEWSTATEGENERATOR\"]");
            //string __EVENTVALIDATION = urlCall.parseHtml(htmlData, "//*[@id=\"__EVENTVALIDATION\"]");

            //richTextBox1.Text = urlCall.Post("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx", "__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VIEWSTATE=" + __VIEWSTATE + "&__VIEWSTATEGENERATOR=" + __VIEWSTATEGENERATOR + "&__EVENTVALIDATION=" + __EVENTVALIDATION + "&ctl00%24MainContent%24txtConID=" + txt_consumer_id.Text.Trim() + "&ctl00%24MainContent%24txtConName=&ctl00%24MainContent%24txtAmountPayable=&ctl00%24MainContent%24btnCurrentblnce=Get+Current+Balance&ctl00%24MainContent%24txtCurrentblnce=142.28&ctl00%24MainContent%24txtEmailId=&ctl00%24MainContent%24txtMobileNo=", "application/x-www-form-urlencoded");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document.GetElementById("MainContent_txtCurrentblnce").GetAttribute("value") == "")
            {
                webBrowser1.Document.GetElementById("MainContent_txtConID").InnerText = txt_consumer_id.Text.Trim();
                webBrowser1.Document.GetElementById("MainContent_btnCurrentblnce").InvokeMember("Click");
            }
            else
            {
                dataGridView1.Rows.Add(DateTime.Now.ToString(), webBrowser1.Document.GetElementById("MainContent_txtCurrentblnce").GetAttribute("value"));
            }
        }
    }
}
