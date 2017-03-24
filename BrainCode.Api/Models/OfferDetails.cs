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
}
