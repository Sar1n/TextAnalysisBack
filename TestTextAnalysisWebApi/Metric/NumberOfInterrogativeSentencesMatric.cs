﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTextAnalysisWebApi.Metric
{
	public class NumberOfInterrogativeSentencesMatric : IMetric
	{
		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
		}
		public NumberOfInterrogativeSentencesMatric(string name)
		{
			_description = name;
		}
		public string Calculate(TextAnalise Text)
		{
			int res = 0;
			foreach (string s in Text.SentencesList)
				if (s.EndsWith("?"))
					res++;
			return res.ToString();
		}
	}
}