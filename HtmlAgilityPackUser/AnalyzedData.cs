using System;
using System.Collections.Generic;
using System.Threading;

namespace HtmlAgilityPackUser
{
	public class AnalyzedData
	{
		public AnalyzedData
		{
			initialize();
		}


		private List<string> xpath;
		private List<string> inner_text;
		private object lockobj = new object();

		public void initialize()
		{
			xpath = new List<string>();
			inner_text = new List<string>();
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
	}
}
