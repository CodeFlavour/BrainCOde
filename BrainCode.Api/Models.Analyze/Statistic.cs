using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Models.Analyze
{
    public class Statistic
    {
        public List<Token> Tokens { get; set; }

        public OfferDetails Offer { get; set; }
    }
}
