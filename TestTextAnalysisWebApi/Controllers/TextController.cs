using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Text.Json;
using TestTextAnalysisWebApi.Metric;
using TestTextAnalysisWebApi.Models;

namespace TestTextAnalysisWebApi.Controllers
{
	[EnableCors("*", "*", "*")]
	public class TextController : ApiController
    {
		// GET api/Text
		public HttpResponseMessage Get()
		{
			return Request.CreateResponse(HttpStatusCode.OK);
		}
		// POST api/Text
		[HttpPost]
		public HttpResponseMessage Post()
		{
			string text = Request.Content.ReadAsStringAsync().Result;
			TextAnalise Analyzer = new TextAnalise(text);
			Analyzer.TextParse();

			List<IMetric> Metrics = new List<IMetric>();

			//Declaring all metrics that needs to be done
			Metrics.Add(new NumberOfLettersMetric("Number of letters"));
			Metrics.Add(new NumberOfVowelsMetric("Number of vowels"));
			Metrics.Add(new NumberOfConsonantsMetric("Number of consonants"));
			Metrics.Add(new NumberOfWordsMetric("Number of words"));
			Metrics.Add(new NumberOfSentencesMetric("Number of sentences"));
			Metrics.Add(new AverageWordLengthMetric("Average word length"));
			Metrics.Add(new NumberOfInterrogativeSentencesMatric("Number of interrogative sentences"));
			Metrics.Add(new NumberOfExclamatorySentencesMetric("Number of exclamatory sentences"));
			Metrics.Add(new NumberOfNumbersMetric("Number of numbers"));
			Metrics.Add(new NumberOfPunctuationMetric("Number of punctuation signs"));
			Metrics.Add(new LastWordMetric("Last word"));

			string body = JsonSerializer.Serialize(Analyzer.MetricsCalculate(Metrics));

			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(body);

			return response;
		}
	}
}
