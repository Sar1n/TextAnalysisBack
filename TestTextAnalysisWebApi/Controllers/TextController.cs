using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Text.Json;
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
			string body = JsonSerializer.Serialize(Analyzer.Analyze());

			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(body);

			return response;
		}
	}
}
