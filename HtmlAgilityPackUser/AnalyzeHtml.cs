
using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using HtmlAgilityPack;

namespace HtmlAgilityPackUser
{
	public static class AnalyzeHtml
	{
		/*public AnalyzeHtml()
		{
		}*/

		public static AnalyzedData anlyzeHtml(string html, string url)
		{
			AnalyzedData ad = new AnalyzedData(url); //create data type for analyzed data
			if (checkHtml(html)) //check if html contains error
			{
				var htmldoc = new HtmlAgilityPack.HtmlDocument();
				htmldoc.LoadHtml(html);

				var selected = htmldoc.DocumentNode.SelectNodes("//*");
				List<string> inner = new List<string>();
				int i = 0;
				foreach (var a in selected)
				{
					if (a.OuterHtml.Contains("script") == false && a.InnerText.Length > 1 && inner.Contains(a.InnerText) == false)
					{
						inner.Add(a.InnerText);
						//Console.WriteLine(a.XPath.Count(c => c == '/') + " : " + a.InnerText);
						Console.WriteLine(i.ToString() + " : " + a.InnerText);
						ad.addInnerText(a.InnerText);
						ad.addXpath(a.XPath);
						i++;
					}
				}
			}
			else 
			{
			}
			return ad;
		}
		private static bool checkHtml(string html)
		{
			if (html.Substring(0, 5) != "error")
				return true;
			else
				return false;
		}
	}
}
