using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainCode.Api.Models;
using System.Net.Http;
using BrainCode.Api.Services;

namespace BrainCode.Api.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private SearchService searchService;
        //// GET api/values/5
        //[HttpGet("{search}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public SearchController()
        {
            searchService = new SearchService();
        }

        // POST api/values
        [HttpPost]
        public List<Offer> Search([FromBody]string title, string phrase, List<Parameter> parameters)
        {
            var foundOffers = searchService.SearchOffers(title, phrase, parameters).Result;
            //var response = 
            return foundOffers;
        }


        [HttpGet("{GetFilterForCategory}")]
        public async Task<List<FilterDescriptor>> GetFilterDescriptorsForOffer(string id)
        {
            return (await searchService.GetFiltersDataForCategory(id));
        }
    }
}
