using System;
using System.Net;
using System.Text;
using System.Linq;
using System.IO;
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
			string url = "0000000000";
			do
			{
				Console.WriteLine("Please input correct url");
				url = Console.ReadLine();
			} while (checkUrl(url) == false);

			//download html
			string html = downloadHtml(url);

			//agilitypack
			if (html.Substring(0, 5) != "error")
			{
				var htmldoc = new HtmlAgilityPack.HtmlDocument();
				htmldoc.LoadHtml(html);

				var selected = htmldoc.DocumentNode.SelectNodes("//*");

				try
				{
					using (StreamWriter sw = new StreamWriter("data.txt", true, Encoding.Default))
					{
						int i = 0;
						foreach (var a in selected)
						{
							if (a.OuterHtml.Contains("script") == false && a.InnerText.Length > 1)
							{
								Console.WriteLine(a.XPath.Count(c => c == '/') + " : " + a.InnerText);
								sw.WriteLine(i.ToString() +"\t"+ a.XPath+"\t"+a.InnerText);
								i++;
							}
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Finished with html download error!");
					Console.WriteLine(e.ToString());
				}
			}
			else
			{
				Console.WriteLine("Finished with html download error!");
				Console.WriteLine(html.Substring(0, 5));
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
				return "error" + e.ToString();
			}
		}
	}
}
