using BrainCode.Api.Models;
using BrainCode.Api.Models.Analyze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Services
{
    public class AnalyzeService
    {
        private string[] _stopwords;
        private OfferDetailsService _offerDetailsService;
        private SearchService _searchService;

        public AnalyzeService() : this(@"Data\stopwords.txt")
        {
        }

        public AnalyzeService(string stepwordsPath)
        {
            _offerDetailsService = new OfferDetailsService();
            _searchService = new SearchService();
            _stopwords = System.IO.File.ReadAllLines(stepwordsPath);
        }

        public async Task<List<Statistic>> Analyze(string searchPhrase)
        {
            List<Offer> offers = await _searchService.SearchOffers(null, searchPhrase, null);

            List<Statistic> statistics = new List<Statistic>();

            offers.ForEach(async x => statistics.Add(await Analyze(x.ID, y => y.Name)));

            return statistics;
        }

        public async Task<Statistic> Analyze(string id, Func<OfferDetails, string> getStringToAnalyze)
        {
            OfferDetails offerDetails = await _offerDetailsService.GetOfferDetails(id);

            string title = getStringToAnalyze(offerDetails);

            List<Token> tokens = Tokenize(title);

            return new Statistic()
            {
                Tokens = tokens,
                Offer = offerDetails
            };
        }

        public List<Token> Tokenize(string text)
        {
            List<string> elements = text
                .ToLower()
                .Replace(Environment.NewLine, " ")
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Replace(@"\", " ")
                .Replace("/", " ")
                .Replace(",", " ")
                .Replace(".", " ")
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> removeList = new List<string>();

            elements.ForEach(element =>
            {
                element = element.Trim();
                if (_stopwords.Any(stopword => IsEqual(element, stopword)))
                {
                    removeList.Add(element);
                }
            });

            elements = elements.Except(removeList).ToList();

            List<Token> tokens = new List<Token>();

            foreach (var element in elements)
            {
                var token = tokens.FirstOrDefault(x => IsEqual(element, x.Text));

                if (token != null)
                {
                    token.Occurences++;
                }
                else
                {
                    tokens.Add(new Token() { Text = element, Occurences = 1 });
                }
            }

            return tokens;
        }

        public bool IsEqual(string text1, string text2)
        {
            int threshold = 1;

            if(text1.Length > 3 || text2.Length > 3)
            {
                return CalcLevenshteinDistance(text1, text2) <= threshold;
            }
            return text1.Equals(text2);
        }

        private static int CalcLevenshteinDistance(string a, string b)
        {
            if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b)) return 0;

            int lengthA = a.Length;
            int lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
                for (int j = 1; j <= lengthB; j++)
                {
                    int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost
                        );
                }
            return distances[lengthA, lengthB];
        }
    }
}
