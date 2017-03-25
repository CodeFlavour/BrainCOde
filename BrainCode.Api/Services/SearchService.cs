using BrainCode.Api.Enums;
using BrainCode.Api.Helpers;
using BrainCode.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrainCode.Api.Services
{
    public class SearchService
    {
        private string _url = "https://allegroapi.io/";

        //private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public async Task<List<Offer>> SearchOffers(string title, string searchPhrase, List<Parameter> parameters, SortTypeEnum? sortType = null, SortDirectionEnum? sortDirection = null, long limit = 100)
        {
            var _headers = new List<Header>();
            var requestURL = _url + "offers";
            List<string> urlParameters = new List<string>();
            urlParameters.Add("country.code=PL");
            List<string> phrases = new List<string>();
            if (sortType.HasValue && sortDirection.HasValue)
            {
                string sort = sortDirection.Value == SortDirectionEnum.Ascending ? "+" : "-";
                switch (sortType.Value)
                { case SortTypeEnum.Name:
                        sort += "name";
                        break;
                    case SortTypeEnum.Price:
                        sort += "price";
                        break;
                    case SortTypeEnum.EndTime:
                        sort += "endTime";
                        break;
                    case SortTypeEnum.WithDeliveryPrice:
                        sort += "withDeliveryPrice";
                        break;
                    case SortTypeEnum.Relevance:
                        sort += "relevance";
                        break;
                    case SortTypeEnum.Popularity:
                    default:
                        sort += "popularity";
                        break;
                }
                urlParameters.Add("sort=" + sort);
            }
            urlParameters.Add("limit=" + limit.ToString());

            if (!string.IsNullOrEmpty(searchPhrase))
            {
                phrases.Add(searchPhrase);
            }
            if (parameters != null)
            {
                //parameters.ForEach(x => phrases.Add(x.ParameterName + " " + x.ParameterValue));
                parameters.ForEach(x => urlParameters.Add(x.ParameterName + "=" + x.ParameterValue));
            }


            if (phrases.Count > 0)
            {
                var phrase = string.Join(" ", phrases);
                urlParameters.Add("phrase=" + phrase);
            }

            HttpClient client = new HttpClient();
            _headers.Add(new Header("User-Agent", "hackaton2017 (Client-Id 656cbe47-b17d-46c2-bae1-3222c8777d5b) Platform"));
            _headers.Add(new Header("Api-Key", "eyJjbGllbnRJZCI6ImE0MWY1YjJhLThlODctNGI4Yi1iNmZlLTc0Y2M3NjM3MjBkNyJ9.ogVV_a9RUOMa1OWFZOTmgTkdk-U37vTliDCBUQ1YySU="));
            _headers.Add(new Header("Accept", "application / vnd.allegro.public.v1+json"));
            Header bearerHeader = await BearerHelper.GetBearerHeader();
            _headers.Add(bearerHeader);


            for (int i = 0; i < urlParameters.Count; i++)
            {
                requestURL += (i == 0 ? "?" : "&") + urlParameters[i];
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestURL),
                Method = HttpMethod.Get,
            };

            foreach (var header in _headers)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            var response = await client.SendAsync(request);
            string responseObject = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ReasonPhrase);
            }
            var responseJsonObject = (JObject)JsonConvert.DeserializeObject(responseObject);
            List<Offer> offers = Map(responseJsonObject["offers"]);
            //var rVal = new PagedResponse<Offer>(responseJsonObject[""], responseJsonObject[""], offers);
            return offers;
        }

        private List<Offer> Map(JToken jToken)
        {
            List<Offer> rVal = new List<Offer>();
            foreach (var item in jToken)
            {
                rVal.Add(new Offer(item));
            }
            return rVal;
        }

        public async Task<List<FilterDescriptor>> GetFiltersDataForCategory(string categoryID)
        {
            var _headers = new List<Header>();
            var requestURL = _url + "offer-filters";
            List<string> urlParameters = new List<string>();
            urlParameters.Add("country.code=PL");
            urlParameters.Add("category.id=" + categoryID);

            HttpClient client = new HttpClient();
            _headers.Add(new Header("User-Agent", "hackaton2017 (Client-Id 656cbe47-b17d-46c2-bae1-3222c8777d5b) Platform"));
            _headers.Add(new Header("Api-Key", "eyJjbGllbnRJZCI6ImE0MWY1YjJhLThlODctNGI4Yi1iNmZlLTc0Y2M3NjM3MjBkNyJ9.ogVV_a9RUOMa1OWFZOTmgTkdk-U37vTliDCBUQ1YySU="));
            _headers.Add(new Header("Accept", "application / vnd.allegro.public.v1+json"));
            Header bearerHeader = await BearerHelper.GetBearerHeader();
            _headers.Add(bearerHeader);


            for (int i = 0; i < urlParameters.Count; i++)
            {
                requestURL += (i == 0 ? "?" : "&") + urlParameters[i];
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestURL),
                Method = HttpMethod.Get,
            };

            foreach (var header in _headers)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            var response = await client.SendAsync(request);
            string responseObject = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ReasonPhrase);
            }
            var responseJsonObject = (JObject)JsonConvert.DeserializeObject(responseObject);
            return responseJsonObject["filters"].ToObject<List<FilterDescriptor>>();
        }
    }
}
