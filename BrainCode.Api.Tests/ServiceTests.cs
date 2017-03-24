using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrainCode.Api.Services;
using System.Collections.Generic;
using BrainCode.Api.Models;

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
    }
}