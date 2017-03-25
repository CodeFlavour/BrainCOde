using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace BrainCode.Api.Models
{
    public class Offer
    {
        public Offer(JToken item)
        {
            this.ID = (string)item["id"];
            this.Name = (string)item["name"];
            this.BuyNowPrice = (bool)item["buyNow"] == true ? item["prices"]["buyNow"]["amount"].ToObject<decimal?>() : null;
            //if ((bool)item["auction"])
            //{
            //    decimal.TryParse((string)item["prices"]["current"])
            //}
            this.BiddingPrice = (bool)item["auction"] == true ? item["prices"]["current"]["amount"].ToObject<decimal?>() : null;
            this.OfferEndDate = (DateTime?)item["endingAt"];
            this.PhotoUrl = (string)(item["images"][0]["url"]);
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public decimal? BuyNowPrice { get; set; }

        public decimal? BiddingPrice { get; set; }

        public DateTime? OfferEndDate { get; set; }

        public string PhotoUrl { get; set; }
    }
}