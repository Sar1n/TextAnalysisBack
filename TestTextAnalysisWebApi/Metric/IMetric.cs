using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTextAnalysisWebApi.Metric
{
	public interface IMetric
	{
		string Description
		{
			get;
		}
		string Calculate(TextAnalise Text);
	}
}
