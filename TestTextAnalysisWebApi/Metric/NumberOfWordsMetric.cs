using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfWordsMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfWordsMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			
			return Text.WordsList.Count().ToString();
		}
	}
}