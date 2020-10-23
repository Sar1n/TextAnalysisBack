using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class LastWordMetric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public LastWordMetric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			return Text.WordsList.Last();
		}
	}
}