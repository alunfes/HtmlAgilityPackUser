using System;
using System.Collections.Generic;
using System.Threading;

namespace HtmlAgilityPackUser
{
	public static class AnalyzedData
	{
		private static List<string> xpath;
		private static List<string> inner_text;
		private static object lockobj = new object();

		public static void initialize()
		{
			xpath = new List<string>();
			inner_text = new List<string>();
		}

		public static void addXpath(string path)
		{
			lock(lockobj)
			{
				xpath.Add(path);
			}
		}
		public static List<string> getXpath()
		{
			lock(lockobj)
				return xpath;
		}
		public static void addInnerText(string text)
		{
			lock(lockobj)
				inner_text.Add(text);
		}
		public static List<string> getInnerText()
		{
			lock(lockobj)
				return inner_text;
		}
	}
}
