using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TestTextAnalysisWebApi.Models;

namespace TestTextAnalysisWebApi
{
	public class TextAnalise
	{
		private string _text;

		private string engletters = "qwertyuiopasdfghjklzxcvbnm";
		private string engvowels = "aeiouy";
		private string engconsonants = "bcdfghjklmnpqrstvwxz";

		private string cyrletters = "йцукенгшщзхъфывапролджэячсмитьбюїіёє";
		private string cyrvowels = "аоиеёэыуюяєїі";
		private string cyrconsonants = "бвгджзйклмнпрстфхцчшщ";

		private string punctuation = "'`-,:\";(){}[]=|+\\/%*^$#@<>~";
		private string punctuationend = ".?!";

		private string numbers = "1234567890";

		private List<string> WordsList = new List<string>();
		private List<string> SentencesList = new List<string>();

		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}
		public TextAnalise(string text)
		{
			Text = text;
		}
		public List<MetricModel> Analyze()
		{
			//Metrics declaration
			MetricModel NumberOfLetters = new MetricModel { Metric = "Number of letters" };
			MetricModel NumberOfVowels =  new MetricModel { Metric = "Number of vowels" };
			MetricModel NumberOfConsonants = new MetricModel { Metric = "Number of consonants" };
			MetricModel NumberOfWords = new MetricModel { Metric = "Number of words" };
			MetricModel NumberOfSentences = new MetricModel { Metric = "Number of sentences" };
			MetricModel AverageWordLength = new MetricModel { Metric = "Average word length" };
			MetricModel NumberOfInterrogativeSentences = new MetricModel { Metric = "Number of interrogative sentences" };
			MetricModel NumberOfExclamatorySentences = new MetricModel { Metric = "Number of exclamatory sentences" };
			MetricModel NumberOfNumbers = new MetricModel { Metric = "Number of numbers" };
			MetricModel NumberOfPunctuation = new MetricModel { Metric = "Number of punctuation signs" };
			MetricModel LastWord = new MetricModel { Metric = "Last word" };

			int letters = 0, vowels = 0, consonants = 0, numb = 0, words = 0, punct = 0;
			double sum = 0; 
			string word = "";
			string sentence = "";
			foreach (char c in Text)
			{
				sentence += c;
				if (!punctuationend.Contains(c))
				{
					if (!char.IsWhiteSpace(c))
					{
						if (!punctuation.Contains(c))
						{
							word += c; //its a letter or number, adding to current word
							if (!numbers.Contains(c))
							{
								//Metrics by every letter
								letters++;
								if (engvowels.Contains(char.ToLower(c)) || cyrvowels.Contains(char.ToLower(c)))
									//Metrics by every vowel
									vowels++;
								if (engconsonants.Contains(char.ToLower(c)) || cyrconsonants.Contains(char.ToLower(c)))
									//Metrics by every consonant
									consonants++;
							}
							else
								//Metrics by every number
								numb++;
						}
						else
							//Metrics by every punctuation sign that is not .?!
							punct++;
					}
					else
					{
						WordsList.Add(word);
						word = "";
					}
				}
				else
				{
					//Metrics by every .?!
					SentencesList.Add(sentence);
					sentence = "";
				}
			}
			WordsList.Add(word); //Adding last word
			SentencesList.Add(sentence);

			//Setting values to metrics that already done
			NumberOfLetters.Value = letters.ToString();
			NumberOfVowels.Value = vowels.ToString();
			NumberOfConsonants.Value = consonants.ToString();
			NumberOfNumbers.Value = numb.ToString();
			NumberOfPunctuation.Value = punct.ToString();
			LastWord.Value = WordsList.Last();

			//Metrics with words and sentences

			{ //Number of words
				words = WordsList.Count();
				NumberOfWords.Value = words.ToString();
			}

			{ //Number of sentences
				int numberOfSentences = 0;
				foreach (string s in SentencesList)
					if (s.Length > 1)
						numberOfSentences++;
				NumberOfSentences.Value = numberOfSentences.ToString();
			}

			{ //Average number of letters in word
				float averageNumberOfLetters = 0;
				foreach (string w in WordsList)
					averageNumberOfLetters += w.Length;
				averageNumberOfLetters = averageNumberOfLetters / WordsList.Count;
				AverageWordLength.Value = averageNumberOfLetters.ToString();
			}

			{ //Number of interrogative sentences
				int numberOfInterrogativeSentences = 0;
				foreach (string s in SentencesList)
					if (s.EndsWith("?"))
						numberOfInterrogativeSentences++;
				NumberOfInterrogativeSentences.Value = numberOfInterrogativeSentences.ToString();
			}

			{ //Number of exclamatory sentences
				int numberOfExclamatorySentences = 0;
				foreach (string s in SentencesList)
					if (s.EndsWith("!"))
						numberOfExclamatorySentences++;
				NumberOfExclamatorySentences.Value = numberOfExclamatorySentences.ToString();
			}

			List<MetricModel> Metrics = new List<MetricModel>(); //List of metrics to send to front
			//Adding all ready metrics
			Metrics.Add(NumberOfLetters);
			Metrics.Add(NumberOfVowels);
			Metrics.Add(NumberOfConsonants);
			Metrics.Add(NumberOfWords);
			Metrics.Add(NumberOfSentences);
			Metrics.Add(AverageWordLength);
			Metrics.Add(NumberOfInterrogativeSentences);
			Metrics.Add(NumberOfExclamatorySentences);
			Metrics.Add(NumberOfNumbers);
			Metrics.Add(NumberOfPunctuation);
			Metrics.Add(LastWord);

			return Metrics;
		}
	}
}