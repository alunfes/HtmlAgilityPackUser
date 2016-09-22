using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Xml;
using HtmlAgilityPack;

namespace HtmlAgilityPackUser
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//get and check url
			Console.WriteLine("This is sample program to use some functions of HtmlAgilityPack.");
			string url=  "0000000000";
			do
			{
				Console.WriteLine("Please input correct url");
				url = Console.ReadLine();
			} while(checkUrl(url)==false);

			//download html
			string html = downloadHtml(url);

			//agilitypack
			if (html.Substring(0,5) != "error")
			{
				var htmldoc = new HtmlAgilityPack.HtmlDocument();
				htmldoc.LoadHtml(html);

				var selected = htmldoc.DocumentNode.SelectNodes("//div");
				foreach (var a in selected)
				{
					if (a.OuterHtml.Contains("script")==false)
						Console.WriteLine(a.XPath.Count(c => c == '/') + " : " + a.InnerText);
				}
				/*var articles = htmldoc.DocumentNode.SelectNodes("*").Select(a => new { title = a.InnerText });
				foreach (var a in articles)
					Console.WriteLine(a.title);*/
			}
			else
			{
				Console.WriteLine("Finished with html download error!");
				Console.WriteLine(html.Substring(0,5));
			}

		}

		private static bool checkUrl(string url)
		{
			if (url.Length > 5)
			{
				if (url.Substring(0, 4) == "http" && url.Contains("://"))
					return true;
				else
					return false;
			}
			else
				return false;
		}


		private static string downloadHtml(string url)
		{
			try
			{
				using (WebClient wc = new WebClient())
				{
					wc.Encoding = Encoding.UTF8;
					return wc.DownloadString(url);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Unexpected error occurred!");
				Console.WriteLine(e.ToString());
				return "error"+e.ToString();
			}
		}
	}
}
