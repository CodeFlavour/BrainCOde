using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Models
{
    public class Offer
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public decimal? BuyNowPrice { get; set; }

        public decimal BiddingPrice { get; set; }

        public DateTime OfferEndDate { get; set; }

        //public byte[] Photo { get; set; }
    }
}
