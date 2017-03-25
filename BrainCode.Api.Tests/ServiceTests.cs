using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrainCode.Api.Services;
using System.Collections.Generic;
using BrainCode.Api.Models;
using BrainCode.Api.Models.Analyze;

namespace BrainCode.Api.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void BearerServiceTest()
        {
            BearerService service = new BearerService();
            Header result = service.GetBearerHeader().Result;

            Assert.AreEqual("Authorization", result.Name);
            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        public void OfferDetailsServiceTest()
        {
            OfferDetailsService service = new OfferDetailsService();

            OfferDetails details = service.GetOfferDetails("6754645454").Result;
        }

        [TestMethod]
        public void GetStatisticTest()
        {
            AnalyzeService service = new AnalyzeService(@"C:\Data\stopwords.txt");
            Statistic statistic = service.GetStatistic("6754645454", x => x.Name).Result;
        }

        [TestMethod]
        public void GetStatisticsTest()
        {
            AnalyzeService service = new AnalyzeService(@"C:\Data\stopwords.txt");
            List<Statistic> statistic = service.GetStatistics("htc", 500.50M, 1000.50M).Result;
        }


        [TestMethod]
        public void AnalizeServiceTest()
        {
            AnalyzeService service = new AnalyzeService(@"C:\Data\stopwords.txt");
            List<ResultToken> statistic = service.Analyze("htc", 500.50M, 1000.50M).Result;
            Console.Read();
        }

        [TestMethod]
        public void FilterServiceTest()
        {
            SearchService service = new SearchService();

            List<FilterDescriptor> details = service.GetFiltersDataForCategory("165").Result;
        }
    }
}
