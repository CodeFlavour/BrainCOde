using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrainCode.Api.Services;
using System.Collections.Generic;
using BrainCode.Api.Models;

namespace BrainCode.Api.Tests
{
    [TestClass]
    public class SearchServiceTests
    {
        [TestMethod]
        public void Completed()
        {
            SearchService service = new SearchService();
            List<Parameter> searchParameters = new List<Parameter>();
            //searchParameters.Add(new Parameter() { ParameterName = "Pamiêæ", ParameterValue = "16GB" });
            searchParameters.Add(new Parameter() { ParameterName = "Category.ID", ParameterValue = "165" });
            List<Offer> result = service.SearchOffers(null, "htc pamiêæ 16GB", searchParameters).Result;           
        }
    }
}
