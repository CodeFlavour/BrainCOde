﻿using System;
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
        private OfferDetailsService offerDetailService;

        public SearchController()
        {
            searchService = new SearchService();
            offerDetailService = new OfferDetailsService();
        }

        // POST api/values
        [HttpPost]
        public List<Offer> Search([FromBody]string title, string phrase, List<Parameter> parameters)
        {
            var foundOffers = searchService.SearchOffers(title, phrase, parameters).Result;
            //var response = 
            return foundOffers;
        }


        [HttpGet("{GetFilterForOffer}")]
        public async Task<List<FilterDescriptor>> GetFilterDescriptorsForOffer(string id)
        {
            var offerDetails = offerDetailService.GetOfferDetails(id).Result;
            var categoryID = offerDetails.Categories.First(x => x.Parent == "0").Id;
            var newID = "-1";
            while(newID!= categoryID)
            {
                newID = categoryID;
                var category = offerDetails.Categories.FirstOrDefault(x => x.Parent == categoryID);
                if (category != null)
                {
                    categoryID = category.Id;
                }
            }
            var filterDescriptors = searchService.GetFiltersDataForCategory(categoryID).Result;
            List<FilterDescriptor> result = new List<FilterDescriptor>();
            foreach(var category in offerDetails.Attributes)
            {
                var descriptor = filterDescriptors.First(x => x.Name == category.Name);
                result.Add(new FilterDescriptor() { ID = descriptor.ID, Name = descriptor.Name, Values = descriptor.Values.Where(x => category.Attributes.Contains(x.Name)).ToList() });
            }
            return result;
        }
    }
}