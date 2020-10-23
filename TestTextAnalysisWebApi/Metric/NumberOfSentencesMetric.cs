using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfSentencesMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfSentencesMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			int res = 0;
			foreach (string s in Text.SentencesList)
				if (s.Length > 1)
					res++;
			return res.ToString();
		}
	}
}