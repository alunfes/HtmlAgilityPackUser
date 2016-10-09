using System;
using System.Net;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml;
using HtmlAgilityPack;
using System.Threading;
using System.Diagnostics;

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

			Thread th = new Thread(new ParameterizedThreadStart(mainThread));
			th.Start(url);
		}


		private static void mainThread(object url)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			DownloadHtml dh = new DownloadHtml();
			string html = dh.downloadHtml(url.ToString());
			AnalyzedData ad = AnalyzeHtml.anlyzeHtml(html);
			sw.Stop();
			Console.WriteLine("Total Time:"+sw.Elapsed);
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
	}
}
