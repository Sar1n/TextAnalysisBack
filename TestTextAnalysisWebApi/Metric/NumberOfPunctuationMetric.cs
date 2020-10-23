using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfPunctuationMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfPunctuationMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			int res = 0;
			foreach (char c in Text.Text)
				if (Text.Punctuation.Contains(c) || Text.Punctuationend.Contains(c))
					res++;
			return res.ToString();
		}
	}
}