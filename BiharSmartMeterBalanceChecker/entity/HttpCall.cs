using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BiharSmartMeterBalanceChecker.entity
{
    class HttpCall
    {
		private	string newurl = "https://google.com";
		private CookieContainer cookie  = new CookieContainer();

		public string ParseRequest(HttpWebResponse response, string method = "", string key = "")
        {
			if (response != null)
			{
				var encoding = response.CharacterSet == "" ? Encoding.UTF8 : Encoding.GetEncoding(response.CharacterSet);
				string responseString = "";
				switch (method)
				{
					case "STATUS": return response.StatusCode.ToString(); 
					case "URL": return response.ResponseUri.ToString();
					case "HEADER": return response.Headers[key].ToString();
					default:
						return new StreamReader(response.GetResponseStream()).ReadToEnd();
						//using (var stream = response.GetResponseStream())
						//{
						//	//Console.WriteLine("Redirect to " + this.newurl ?? "NULL");
						//	var reader = new StreamReader(stream, encoding);
						//	responseString = reader.ReadToEnd();
						//}
						//return responseString; 
				}
			} else
            {
				return "";
            }
        }

		public HttpWebResponse MakeRequest(string method = "GET", string url="", string postData = "")
		{
			var data = Encoding.ASCII.GetBytes(postData);
			method = method.ToUpper();
			Console.WriteLine(url);
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
			try
			{
				req.Timeout = 3000;
				req.Method = method;
                req.CookieContainer = cookie;
                req.AllowAutoRedirect = true;
				req.MaximumAutomaticRedirections = 5;
                //req.AutomaticDecompression = DecompressionMethods.GZip;
                req.Accept = "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
				req.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36";

				WebProxy myproxy = new WebProxy("http://127.0.0.1", 5555);
				myproxy.BypassProxyOnLocal = false;
				//req.Proxy = myproxy;

				if (method.Equals("POST"))
                {
					req.ContentType = "application/x-www-form-urlencoded";
					req.ContentLength = data.Length;
					using (var stream = req.GetRequestStream())
					{
						stream.Write(data, 0, data.Length);
					}
                }

				HttpWebResponse response = (HttpWebResponse)req.GetResponse();
				// response.Cookies;
				return response;

				//switch (response.StatusCode)
				//{
				//	case HttpStatusCode.OK:
				//		return url;
				//	case HttpStatusCode.Redirect:
				//	case HttpStatusCode.MovedPermanently:
				//	case HttpStatusCode.RedirectKeepVerb:
				//	case HttpStatusCode.RedirectMethod:
				//		url = response.Headers["Location"];
				//		if (url == null)
				//			return url;

				//		if (url.IndexOf("://", System.StringComparison.Ordinal) == -1)
				//		{
				//			// Doesn't have a URL Schema, meaning it's a relative or absolute URL
				//			Uri u = new Uri(new Uri(url), url);
				//			url = u.ToString();
				//		}
				//		break;
				//	default:
				//		return url;
				//}


				//var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
    }
}
