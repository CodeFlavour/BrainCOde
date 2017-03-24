using BrainCode.Api.Helpers;
using BrainCode.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrainCode.Api.Services
{
    public class OfferDetailsService
    {
        private string _url = "https://api.natelefon.pl/v1/allegro/offers/";

        public async Task<OfferDetails> GetOfferDetails(int id)
        {
            Header bearerHeader = await BearerHelper.GetBearerHeader();

            List<Header> headers = new List<Header>()
            {
                new Header("User-Agent", "hackaton2017 (Client-Id 656cbe47-b17d-46c2-bae1-3222c8777d5b) Platform"),
                bearerHeader
            };

            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_url),
                Method = HttpMethod.Get,
            };

            foreach (var header in headers)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            var response = await client.SendAsync(request);
            string responseObject = await response.Content.ReadAsStringAsync();

            return new OfferDetails();
        }

    }
}
