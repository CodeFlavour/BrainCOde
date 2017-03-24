using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Models
{
    public class OfferDetails
    {
        public List<OfferDetailsAttribute> Attributes { get; set; }

        public List<Category> Categories { get; set; }

        public Prices Prices { get; set; }

        public Quantities Quantities { get; set; }

        public Seller Seller { get; set; }

        public Bids Bids { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int Views { get; set; }

        public OfferDetails()
        {
            Attributes = new List<OfferDetailsAttribute>();
            Categories = new List<Category>();
        }
    }

    public class OfferDetailsAttribute
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
    }

    public class Category
    {
        public string Parent { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Prices
    {
        public decimal? Bid { get; set; }
        public decimal? BuyNow { get; set; }
        public decimal? CheapestShipment { get; set; }
        public decimal? ReservePrice { get; set; }
        public int? ReserverPriceStatus { get; set; }
    }

    public class Quantities
    {
        public int? Available { get; set; }
        public int? Sold { get; set; }
        public int? Type { get; set; }
    }

    public class Seller
    {
        public int? Rating { get; set; }
    }

    public class Bids
    {
        public int? Count { get; set; }
    }
}
