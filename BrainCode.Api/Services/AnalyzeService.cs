using BrainCode.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Services
{
    public class AnalyzeService
    {
        private string _id;
        private OfferDetailsService _offerDetailsService;

        public AnalyzeService(string id)
        {
            _id = id;
            _offerDetailsService = new OfferDetailsService();
        }

        public async Task Analyze()
        {
            OfferDetails offerDetails = await _offerDetailsService.GetOfferDetails(_id);


        }
    }
}
