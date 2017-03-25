using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace BrainCode.Api.Models
{
    public class PagedResponse<T>
    {
        private JToken jToken;
        private JObject responseJsonObject;
        private List<Offer> offers;

        public PagedResponse(JToken jToken, JObject responseJsonObject, List<T> offers)
        {
            this.jToken = jToken;
            this.responseJsonObject = responseJsonObject;
            this.offers = offers;
        }

        public string PreviousPageToken { get; set; }

        public string NextPageToken { get; set; }

        public List<T> Items { get; set; }
    }
}