using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfConsonantsMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfConsonantsMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			int res = 0;
			foreach (char c in Text.Text)
				if (Text.Engconsonants.Contains(c) || Text.Cyrconsonants.Contains(c))
					res++;
			return res.ToString();
		}
	}
}