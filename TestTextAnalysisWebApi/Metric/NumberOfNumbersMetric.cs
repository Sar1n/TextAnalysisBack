using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfNumbersMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfNumbersMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			int res = 0;
			foreach (char c in Text.Text)
				if (Text.Numbers.Contains(c))
					res++;
			return res.ToString();
		}
	}
}