using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class AverageWordLengthMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public AverageWordLengthMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			float res = 0;
			foreach (string w in Text.WordsList)
				res += w.Length;
			res = res / Text.WordsList.Count;
			return res.ToString();
		}
	}
}