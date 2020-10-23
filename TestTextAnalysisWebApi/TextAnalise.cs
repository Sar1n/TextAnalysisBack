using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TestTextAnalysisWebApi.Metric;
using TestTextAnalysisWebApi.Models;

namespace TestTextAnalysisWebApi
{
	public class TextAnalise
	{
		private string _text;

		private string _engletters = "qwertyuiopasdfghjklzxcvbnm";
		private string _engvowels = "aeiouy";
		private string _engconsonants = "bcdfghjklmnpqrstvwxz";

		private string _cyrletters = "йцукенгшщзхъфывапролджэячсмитьбюїіёє";
		private string _cyrvowels = "аоиеёэыуюяєїі";
		private string _cyrconsonants = "бвгджзйклмнпрстфхцчшщ";

		private string _punctuation = "'`-,:\";(){}[]=|+\\/%*^$#@<>~";
		private string _punctuationend = ".?!";

		private string _numbers = "1234567890";

		public List<string> WordsList = new List<string>();
		public List<string> SentencesList = new List<string>();

		public string Engletters
		{
			get { return _engletters; }
		}
		public string Engvowels
		{
			get { return _engvowels; }
		}
		public string Engconsonants
		{
			get { return _engconsonants; }
		}
		public string Cyrletters
		{
			get { return _cyrletters; }
		}
		public string Cyrvowels
		{
			get { return _cyrvowels; }
		}
		public string Cyrconsonants
		{
			get { return _cyrconsonants; }
		}
		public string Punctuation
		{
			get { return _punctuation; }
		}
		public string Punctuationend
		{
			get { return _punctuationend; }
		}
		public string Numbers
		{
			get { return _numbers; }
		}

		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}
		public TextAnalise(string text)
		{
			Text = text;
		}
		public void TextParse()
		{
			string word = "";
			string sentence = "";
			foreach (char c in Text)
			{
				sentence += c;
				if (!Punctuationend.Contains(c))
				{
					if (char.IsWhiteSpace(c))
					{
						WordsList.Add(word);
						word = "";
					}
					else
						word += c;
				}
				else
				{
					SentencesList.Add(sentence);
					sentence = "";
				}
			}
			WordsList.Add(word);
			SentencesList.Add(sentence);
		}

		public List<MetricModel> MetricsCalculate(List<IMetric> Metrics)
		{
			List<MetricModel> CalculatedMetrics = new List<MetricModel>();

			foreach (IMetric m in Metrics)
				CalculatedMetrics.Add(new MetricModel { Metric = m.Description, Value = m.Calculate(this) } );

			return CalculatedMetrics; 

		}
	}
}