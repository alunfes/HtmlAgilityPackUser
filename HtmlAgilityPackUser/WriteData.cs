using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace HtmlAgilityPackUser
{
	public class WriteData
	{
		public WriteData()
		{
		}

		public void writeAnalyzedHtmlSelectedData(AnalyzedData ad, List<int> selected)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(ad.getUrl().Split('¥')[1].Replace("//", string.Empty).Replace("/","-") + ".txt", false, Encoding.Default))
				{
					List<string> inner_text = ad.getInnerText();
					List<string> xpath = ad.getXpath();
					sw.WriteLine(ad.getUrl());
					for (int i = 0; i < inner_text.Count; i++)
					{
						if(selected.Contains(i))
							sw.WriteLine(xpath[i]+";"+inner_text[i]);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error occurred when writing analyzed data!¥r¥n"+e.ToString());
			}
		}
	}
}
