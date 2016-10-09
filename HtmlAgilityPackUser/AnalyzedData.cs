using System;
using System.Collections.Generic;
using System.Threading;

namespace HtmlAgilityPackUser
{
	public class AnalyzedData
	{
		private List<string> xpath;
		private List<string> inner_text;
		private string url;
		private object lockobj = new object();

		public AnalyzedData(string u)
		{
			initialize();
			url = u;
		}

		public void initialize()
		{
			xpath = new List<string>();
			inner_text = new List<string>();
			url = string.Empty;
		}

		public void addXpath(string path)
		{
			lock(lockobj)
			{
				xpath.Add(path);
			}
		}
		public List<string> getXpath()
		{
			lock(lockobj)
				return xpath;
		}
		public void addInnerText(string text)
		{
			lock(lockobj)
				inner_text.Add(text);
		}
		public List<string> getInnerText()
		{
			lock(lockobj)
				return inner_text;
		}
		public int getNum()
		{
			lock(lockobj)
				return xpath.Count;
		}
		public string getUrl()
		{
			return url;
		}
	}
}
