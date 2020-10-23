using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfLettersMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfLettersMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			int res = 0;
			foreach(char c in Text.Text)
				if (Text.Engletters.Contains(c) || Text.Cyrletters.Contains(c))
					res++;
			return res.ToString();
		}
	}
}