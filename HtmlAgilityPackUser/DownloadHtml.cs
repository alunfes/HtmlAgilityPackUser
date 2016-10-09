using System;
using System.Net;
using System.Text;

namespace HtmlAgilityPackUser
{
	public class DownloadHtml
	{
		public DownloadHtml()
		{
		}

		public string downloadHtml(string url)
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
